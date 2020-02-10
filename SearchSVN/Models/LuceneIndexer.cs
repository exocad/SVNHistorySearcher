using Lucene.Net.Analysis;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.Search;
using Lucene.Net.Store;
using SVNHistorySearcher.Common;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Directory = Lucene.Net.Store.Directory;

namespace SVNHistorySearcher.Models
{

	// this Indexer is tied to a repository
	public class LuceneIndexer : IDisposable
	{

		ConcurrentDictionary<DiffInfo, int> diffsInCache; // contains the diffs that are really saved in cache
		ConcurrentDictionary<int, IList<DiffInfo>> docIDtoDiffs;

		private int withUnknownDocumentId = 0; /* it's faster to dump the diffsInCache dictionary and load it again with a MatchAllQuery,
		than trying to get the documentIDs of many files individually*/
		private int uncommitedDiffs = 0;

		ConcurrentDictionary<DiffInfo, DiffInfo> equalContent;  // Key: a diff that is not in the index but has the same Content as Key

		private Analyzer Analyzer;
		private Directory LuceneIndexDirectory;
		private IndexWriter Writer;
		private string IndexPath;
		private string EqualDiffsFile;


		AtomicBoolean IsActive = new AtomicBoolean(false);

		public LuceneIndexer(string repositoryUrl) {
			IndexPath = DataSaver.GetRepositoryFolder(repositoryUrl);
			EqualDiffsFile = Utils.JoinPathsWin(IndexPath, "ecfile");
			IndexPath = Utils.JoinPathsWin(IndexPath, Utils.CalculateMD5Hash(repositoryUrl.ToLower()).Substring(0, 8));

			LoadEqualContent(out equalContent);

			Analyzer = new CaseInsensitiveWhitespaceAnalyzer();

			LuceneIndexDirectory = FSDirectory.Open(IndexPath);
			Writer = new IndexWriter(LuceneIndexDirectory, Analyzer, IndexWriter.MaxFieldLength.UNLIMITED);

			IsActive.Set(true);

			RelistDiffsInCache();
			Progress.DebugLog("Opened with {0} diffs in Index", diffsInCache.Count);
		}

		~LuceneIndexer() {
			Dispose(false);
		}

		public void Dispose() {
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected void Dispose(bool bo) {
			SaveEqualContent();
			IsActive.Set(false);
			if (Writer != null) {
				Writer.Dispose();
			}
			if (LuceneIndexDirectory != null) {
				LuceneIndexDirectory.Dispose();
			}
			if (Analyzer != null) {
				Analyzer.Dispose();
			}
		}


		public ConcurrentDictionary<DiffInfo, int> MultithreadedSearch(SearchOptions searchOptions, ISet<DiffInfo> diffsToSearch, out ConcurrentBag<DiffInfo> notFound) {
			PresearchCommit();
			ConcurrentDictionary<DiffInfo, int> result = new ConcurrentDictionary<DiffInfo, int>();
			ConcurrentQueue<Tuple<DiffInfo, int>> queue = new ConcurrentQueue<Tuple<DiffInfo, int>>();

			ConcurrentBag<DiffInfo> notFoundPrep = new ConcurrentBag<DiffInfo>();

			Regex pattern = null;

			// regex instantiation should never fail because it was tested before
			if (searchOptions.UseRegex)
				pattern = new Regex(searchOptions.Text, searchOptions.CaseSensitive ? 0 : RegexOptions.IgnoreCase);

			long searchedTrough = 0;

			AtomicBoolean running = new AtomicBoolean(true);
			// stops immediatly after queue is empty
			Action worker = () => {
				using (IndexSearcher searcher = new IndexSearcher(LuceneIndexDirectory, true)) {
					Tuple<DiffInfo, int> diff;

					while (running.Get() || queue.Count > 0) {
						while (queue.TryDequeue(out diff)) {

							string text = null;

							int docId = diff.Item2;
							if (docId > -1) {
								try {
									text = searcher.Doc(docId).Get("content");
								} catch {
									Progress.DebugLog("Failed terribly at getting {0} from Index docId: {1}", diff.Item1, diff.Item2);
								}
							} else {
								text = GetDiff(diff.Item1, out docId);
							}

							if (text == null || text == "") {
								Progress.DebugLog("Text is null {0}, docId: {1}", diff.Item1, diff.Item2);
								notFoundPrep.Add(diff.Item1);
								continue;
							}

							Interlocked.Add(ref searchedTrough, 1);


							bool foundSomething = searchOptions.UseRegex ?
								Utils.BestSearch(text, pattern) :
								Utils.BestSearch(text, searchOptions.Text, searchOptions.CaseSensitive);

							if (foundSomething) {
								IList<DiffInfo> li;
								if (docIDtoDiffs.TryGetValue(docId, out li)) {
									foreach (var e in li) {
										if (!diffsToSearch.Contains(e)) {
											continue;
										}
										if (!result.TryAdd(e, 1)) {
											Progress.DebugLog("Failed to add {0} to results", diff.Item1);
										}
									}
								} else {
									Progress.DebugLog("Doc ID {0} was not found in docIDtoDiffs", docId);
								}
							}
						}
					}
				}
			};



			IList<Task> tasks = new List<Task>();
			int tasksToStart = Math.Max((int)(Math.Min(diffsToSearch.Count / 5, 10) + 0.5f), 1);

			for (int i = 0; i < tasksToStart; i++) {
				Task t;
				tasks.Add(t = new Task(worker));
				t.Start();
			}

			HashSet<int> willSearch = new HashSet<int>();

			foreach (var di in diffsToSearch) {
				int docId;
				if (!diffsInCache.TryGetValue(di, out docId)) {
					docId = -2;
				}

				if (!willSearch.Contains(docId)) {
					willSearch.Add(docId);
					queue.Enqueue(new Tuple<DiffInfo, int>(di, docId));
				}
			}
			running.Set(false);
			Task.WaitAll(tasks.ToArray());

			Progress.DebugLog("Searched through {0} diffs", searchedTrough);

			// copy from notFoundPrep to notFound
			notFound = notFoundPrep;

			return result;
		}


		public ConcurrentDictionary<DiffInfo, int> SearchIndex(SearchOptions searchOptions, ISet<DiffInfo> diffsToSearch, out ConcurrentBag<DiffInfo> notFound) {
			return MultithreadedSearch(searchOptions, diffsToSearch, out notFound);
		}

		private void RelistDiffsInCache() {
			SaveEqualContent();
			withUnknownDocumentId = 0;
			var docidtodiffs = new ConcurrentDictionary<int, IList<DiffInfo>>();
			var result = new ConcurrentDictionary<DiffInfo, int>();

			IndexSearcher searcher = new IndexSearcher(LuceneIndexDirectory, true);

			var query = new MatchAllDocsQuery();
			var topDocs = searcher.Search(query, int.MaxValue);
			var hits = topDocs.ScoreDocs;

			foreach (var hit in hits) {
				var doc = searcher.Doc(hit.Doc);

				long revB = long.Parse(doc.Get("revision"));
				string path = doc.Get("path");

				DiffInfo di = new DiffInfo(path, revB);
				result.TryAdd(di, hit.Doc);
				docidtodiffs.TryAdd(hit.Doc, new List<DiffInfo> { di });
			}

			IList<DiffInfo> toRemove = new List<DiffInfo>();

			foreach (var kv in equalContent) {
				int did;
				if (result.TryGetValue(kv.Value, out did)) {
					IList<DiffInfo> li;
					if (docidtodiffs.TryGetValue(did, out li)) {
						li.Add(kv.Key);
					}
				} else {
					Progress.DebugLog("DiffInfo {0} should be linked to {1} but {1} was not found in diffsInCache", kv.Key, kv.Value);
					toRemove.Add(kv.Key);
				}
			}

			foreach (var e in toRemove) {
				DiffInfo dc;
				equalContent.TryRemove(e, out dc);
			}

			docIDtoDiffs = docidtodiffs;
			diffsInCache = result;
		}


		/// <summary>
		/// gets diff content by finding the doc id
		/// </summary>
		/// <param name="diffInfo"></param>
		/// <param name="fromDocID"></param>
		/// <returns></returns>
		public string GetDiff(DiffInfo diffInfo, out int fromDocID) {
			fromDocID = -3;

			IndexSearcher searcher = new IndexSearcher(LuceneIndexDirectory, true);

			DiffInfo di;
			if (!equalContent.TryGetValue(diffInfo, out di)) {
				di = diffInfo;
			}

			int docId;
			if (diffsInCache.TryGetValue(di, out docId) && docId > -1) {

				diffsInCache[di] = docId;
				fromDocID = docId;
				return searcher.Doc(docId).Get("content");

			} else {
				Query query = new WildcardQuery(new Term("combined", String.Format("{0}@{1}", di.Path, di.RevB)));
				var topDocs = searcher.Search(query, int.MaxValue);
				var hits = topDocs.ScoreDocs;

				if (hits.Length != 1) {
					Progress.DebugLog("Found {0} diffs by the name of {1} instead of 1", hits.Length, String.Format("{0}@{1}", di.Path, di.RevB));
				}

				foreach (var hit in hits) {
					var doc = searcher.Doc(hit.Doc);
					diffsInCache[di] = hit.Doc;
					fromDocID = hit.Doc;
					return doc.Get("content");
				}
			}

			return null;
		}

		public bool HasDiff(DiffInfo di) {
			return (diffsInCache.ContainsKey(di) || equalContent.ContainsKey(di));
		}


		// returns document id
		private int AddToIndex(DiffInfo diffInfo, string content) {
			int docId;
			if (diffsInCache.TryGetValue(diffInfo, out docId)) {
				return docId;
			} else {
				docId = -1;
			}


			Document doc = new Document();

			doc.Add(new Field("combined",
				String.Format("{0}@{1}", diffInfo.Path, diffInfo.RevB),
				Field.Store.NO,
				Field.Index.NOT_ANALYZED));

			doc.Add(new Field("revision",
				diffInfo.RevB.ToString(),
				Field.Store.YES,
				Field.Index.NOT_ANALYZED));

			doc.Add(new Field("path",
				diffInfo.Path,
				Field.Store.YES,
				Field.Index.NOT_ANALYZED));

			doc.Add(new Field("content",
				content,
				Field.Store.YES,
				Field.Index.ANALYZED));

			Writer.AddDocument(doc);
			withUnknownDocumentId++;

			diffsInCache.TryAdd(diffInfo, docId);

			if (++uncommitedDiffs > 100 && IsActive) {
				uncommitedDiffs = 0;
				Writer.Commit();
			}

			return docId;
		}

		public void AddToIndex(DiffInfo diffInfo, Stream stream, ISet<DiffInfo> equalDiffs) {
			stream.Position = 0;
			StreamReader sr = new StreamReader(stream);
			string content = sr.ReadToEnd();
			stream.Close();

			if (equalDiffs == null) {
				AddToIndex(diffInfo, content);
			} else {

				DiffInfo inCache = null;

				bool alreadyContains = false;
				foreach (var e in equalDiffs) {
					int docID;
					if (diffsInCache.TryGetValue(e, out docID)) {
						alreadyContains = true;
						inCache = e;
						break;
					}
				}

				if (!alreadyContains) {
					AddToIndex(inCache = diffInfo, content);

				}
				foreach (var e in equalDiffs) {
					if (e != inCache) {
						equalContent.TryAdd(e, diffInfo);
					}
				}
			}

		}


		// needs to be called to make index searchable
		public void PresearchCommit() {
			if (uncommitedDiffs > 0 && IsActive) {
				uncommitedDiffs = 0;

				Writer.Commit();
			}
			RelistDiffsInCache();
		}


		private void LoadEqualContent(out ConcurrentDictionary<DiffInfo, DiffInfo> ec) {
			ec = new ConcurrentDictionary<DiffInfo, DiffInfo>();

			var filename = EqualDiffsFile;

			if (File.Exists(filename)) {
				try {
					using (var fs = new FileStream(filename, FileMode.Open, FileAccess.ReadWrite)) {
						if (fs.Length > 32) {
							byte[] readHash = new byte[32];
							fs.Position = 0;
							fs.Read(readHash, 0, readHash.Length);
							fs.Position = readHash.Length;
							SHA256 sha = SHA256.Create();
							byte[] calculated = sha.ComputeHash(fs);

							if (!calculated.SequenceEqual(readHash)) {
								fs.SetLength(0);
								return;
							}

							fs.Position = readHash.Length;
							BinaryReader reader = new BinaryReader(fs);
							int rowsCount = reader.ReadInt32();

							for (int i = 0; i < rowsCount; i++) {
								ec.TryAdd(new DiffInfo(reader), new DiffInfo(reader));
							}
						}
					}
				} catch { }
			}
		}

		private void SaveEqualContent() {
			string filename = EqualDiffsFile;
			Stream fs;
			try {
				using (fs = new FileStream(filename, FileMode.Create, FileAccess.ReadWrite)) {
					fs.Position = 32;

					BinaryWriter writer = new BinaryWriter(fs);
					int i;
					writer.Write(i = equalContent.Count);

					foreach (var kv in equalContent) {
						if (i-- <= 0) {
							break;
						}
						kv.Key.AddSelfToStream(writer);
						kv.Value.AddSelfToStream(writer);
					}

					fs.Position = 32;
					SHA256 sha = SHA256.Create();
					byte[] calculatedHash = sha.ComputeHash(fs);
					fs.Position = 0;
					fs.Write(calculatedHash, 0, calculatedHash.Length);
				}
			} catch (Exception ex) {
				Progress.ErrorLog(ex);
				return;
			}
		}

		private class CaseInsensitiveWhitespaceAnalyzer : Analyzer
		{
			public override TokenStream TokenStream(string fieldName, TextReader reader) {
				TokenStream t = null;
				t = new WhitespaceTokenizer(reader);
				t = new LowerCaseFilter(t);

				return t;
			}
		}

	}
}
