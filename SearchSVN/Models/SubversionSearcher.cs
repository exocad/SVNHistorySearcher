/*

This file is part of the tool "SVNHistorySearcher" is licensed under the "Apache License Version 2.0", see APACHE-LICENSE-2.0.txt and http://www.apache.org/licenses/LICENSE-2.0.html
The tool "SVNHistorySearcher" was developed in the company exocad GmbH by the author Ion Paciu in 2019.

                Apache License
                           Version 2.0, January 2004
                        http://www.apache.org/licenses/

   TERMS AND CONDITIONS FOR USE, REPRODUCTION, AND DISTRIBUTION

   1. Definitions.

      "License" shall mean the terms and conditions for use, reproduction,
      and distribution as defined by Sections 1 through 9 of this document.

      "Licensor" shall mean the copyright owner or entity authorized by
      the copyright owner that is granting the License.

      "Legal Entity" shall mean the union of the acting entity and all
      other entities that control, are controlled by, or are under common
      control with that entity. For the purposes of this definition,
      "control" means (i) the power, direct or indirect, to cause the
      direction or management of such entity, whether by contract or
      otherwise, or (ii) ownership of fifty percent (50%) or more of the
      outstanding shares, or (iii) beneficial ownership of such entity.

      "You" (or "Your") shall mean an individual or Legal Entity
      exercising permissions granted by this License.

      "Source" form shall mean the preferred form for making modifications,
      including but not limited to software source code, documentation
      source, and configuration files.

      "Object" form shall mean any form resulting from mechanical
      transformation or translation of a Source form, including but
      not limited to compiled object code, generated documentation,
      and conversions to other media types.

      "Work" shall mean the work of authorship, whether in Source or
      Object form, made available under the License, as indicated by a
      copyright notice that is included in or attached to the work
      (an example is provided in the Appendix below).

      "Derivative Works" shall mean any work, whether in Source or Object
      form, that is based on (or derived from) the Work and for which the
      editorial revisions, annotations, elaborations, or other modifications
      represent, as a whole, an original work of authorship. For the purposes
      of this License, Derivative Works shall not include works that remain
      separable from, or merely link (or bind by name) to the interfaces of,
      the Work and Derivative Works thereof.

      "Contribution" shall mean any work of authorship, including
      the original version of the Work and any modifications or additions
      to that Work or Derivative Works thereof, that is intentionally
      submitted to Licensor for inclusion in the Work by the copyright owner
      or by an individual or Legal Entity authorized to submit on behalf of
      the copyright owner. For the purposes of this definition, "submitted"
      means any form of electronic, verbal, or written communication sent
      to the Licensor or its representatives, including but not limited to
      communication on electronic mailing lists, source code control systems,
      and issue tracking systems that are managed by, or on behalf of, the
      Licensor for the purpose of discussing and improving the Work, but
      excluding communication that is conspicuously marked or otherwise
      designated in writing by the copyright owner as "Not a Contribution."

      "Contributor" shall mean Licensor and any individual or Legal Entity
      on behalf of whom a Contribution has been received by Licensor and
      subsequently incorporated within the Work.

   2. Grant of Copyright License. Subject to the terms and conditions of
      this License, each Contributor hereby grants to You a perpetual,
      worldwide, non-exclusive, no-charge, royalty-free, irrevocable
      copyright license to reproduce, prepare Derivative Works of,
      publicly display, publicly perform, sublicense, and distribute the
      Work and such Derivative Works in Source or Object form.

   3. Grant of Patent License. Subject to the terms and conditions of
      this License, each Contributor hereby grants to You a perpetual,
      worldwide, non-exclusive, no-charge, royalty-free, irrevocable
      (except as stated in this section) patent license to make, have made,
      use, offer to sell, sell, import, and otherwise transfer the Work,
      where such license applies only to those patent claims licensable
      by such Contributor that are necessarily infringed by their
      Contribution(s) alone or by combination of their Contribution(s)
      with the Work to which such Contribution(s) was submitted. If You
      institute patent litigation against any entity (including a
      cross-claim or counterclaim in a lawsuit) alleging that the Work
      or a Contribution incorporated within the Work constitutes direct
      or contributory patent infringement, then any patent licenses
      granted to You under this License for that Work shall terminate
      as of the date such litigation is filed.

   4. Redistribution. You may reproduce and distribute copies of the
      Work or Derivative Works thereof in any medium, with or without
      modifications, and in Source or Object form, provided that You
      meet the following conditions:

      (a) You must give any other recipients of the Work or
          Derivative Works a copy of this License; and

      (b) You must cause any modified files to carry prominent notices
          stating that You changed the files; and

      (c) You must retain, in the Source form of any Derivative Works
          that You distribute, all copyright, patent, trademark, and
          attribution notices from the Source form of the Work,
          excluding those notices that do not pertain to any part of
          the Derivative Works; and

      (d) If the Work includes a "NOTICE" text file as part of its
          distribution, then any Derivative Works that You distribute must
          include a readable copy of the attribution notices contained
          within such NOTICE file, excluding those notices that do not
          pertain to any part of the Derivative Works, in at least one
          of the following places: within a NOTICE text file distributed
          as part of the Derivative Works; within the Source form or
          documentation, if provided along with the Derivative Works; or,
          within a display generated by the Derivative Works, if and
          wherever such third-party notices normally appear. The contents
          of the NOTICE file are for informational purposes only and
          do not modify the License. You may add Your own attribution
          notices within Derivative Works that You distribute, alongside
          or as an addendum to the NOTICE text from the Work, provided
          that such additional attribution notices cannot be construed
          as modifying the License.

      You may add Your own copyright statement to Your modifications and
      may provide additional or different license terms and conditions
      for use, reproduction, or distribution of Your modifications, or
      for any such Derivative Works as a whole, provided Your use,
      reproduction, and distribution of the Work otherwise complies with
      the conditions stated in this License.

   5. Submission of Contributions. Unless You explicitly state otherwise,
      any Contribution intentionally submitted for inclusion in the Work
      by You to the Licensor shall be under the terms and conditions of
      this License, without any additional terms or conditions.
      Notwithstanding the above, nothing herein shall supersede or modify
      the terms of any separate license agreement you may have executed
      with Licensor regarding such Contributions.

   6. Trademarks. This License does not grant permission to use the trade
      names, trademarks, service marks, or product names of the Licensor,
      except as required for reasonable and customary use in describing the
      origin of the Work and reproducing the content of the NOTICE file.

   7. Disclaimer of Warranty. Unless required by applicable law or
      agreed to in writing, Licensor provides the Work (and each
      Contributor provides its Contributions) on an "AS IS" BASIS,
      WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or
      implied, including, without limitation, any warranties or conditions
      of TITLE, NON-INFRINGEMENT, MERCHANTABILITY, or FITNESS FOR A
      PARTICULAR PURPOSE. You are solely responsible for determining the
      appropriateness of using or redistributing the Work and assume any
      risks associated with Your exercise of permissions under this License.

   8. Limitation of Liability. In no event and under no legal theory,
      whether in tort (including negligence), contract, or otherwise,
      unless required by applicable law (such as deliberate and grossly
      negligent acts) or agreed to in writing, shall any Contributor be
      liable to You for damages, including any direct, indirect, special,
      incidental, or consequential damages of any character arising as a
      result of this License or out of the use or inability to use the
      Work (including but not limited to damages for loss of goodwill,
      work stoppage, computer failure or malfunction, or any and all
      other commercial damages or losses), even if such Contributor
      has been advised of the possibility of such damages.

   9. Accepting Warranty or Additional Liability. While redistributing
      the Work or Derivative Works thereof, You may choose to offer,
      and charge a fee for, acceptance of support, warranty, indemnity,
      or other liability obligations and/or rights consistent with this
      License. However, in accepting such obligations, You may act only
      on Your own behalf and on Your sole responsibility, not on behalf
      of any other Contributor, and only if You agree to indemnify,
      defend, and hold each Contributor harmless for any liability
      incurred by, or claims asserted against, such Contributor by reason
      of your accepting any such warranty or additional liability.

   END OF TERMS AND CONDITIONS

   APPENDIX: How to apply the Apache License to your work.

      To apply the Apache License to your work, attach the following
      boilerplate notice, with the fields enclosed by brackets "[]"
      replaced with your own identifying information. (Don't include
      the brackets!)  The text should be enclosed in the appropriate
      comment syntax for the file format. We also recommend that a
      file or class name and description of purpose be included on the
      same "printed page" as the copyright notice for easier
      identification within third-party archives.

   Copyright [2019] [exocad GmbH, Julius-Reiber-Str.37, 64293 Darmstadt, Germany]

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.


*/

using SharpSvn;
using SharpSvn.Security;
using SVNHistorySearcher.Common;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace SVNHistorySearcher.Models
{
	public partial class SubversionSearcher
	{

		long totalBytesDownloaded = 0;

		/// <summary>
		/// groups diffs that have the same content
		/// </summary>
		private ConcurrentDictionary<DiffInfo, ISet<DiffInfo>> equalDiffs;

		private HashSet<DiffInfo> totalExpected;

		public const string DEBUGFOLDER = @"debug";
		string username;
		string password;
		bool useCredentials;
		int maxThreads;

		/// <summary>
		/// Threads involved in searching (loadDiffs, takeRelevant) use this flag
		/// </summary>
		public bool InSearch
		{
			get { return _inSearch.Get(); }
		}
		private AtomicBoolean _inSearch = new AtomicBoolean(true);

		/// <summary>
		/// true if Searcher was disposed
		/// </summary>
		public bool Disposed
		{
			get { return _disposed.Get(); }
		}
		private AtomicBoolean _disposed = new AtomicBoolean(false);

		IList<Thread> runningThreads;
		ConcurrentDictionary<Process, byte> runningProcesses;

		/// <summary>
		/// Root path of the repository with trailing '/'
		/// </summary>
		public string RepositoryUrl { get; }
		/// <summary>
		/// Latest Revision in this repository
		/// </summary>
		public long HeadRevision { get; private set; } = 0;

		/// <summary>
		/// File extensions that should not be searched or downloaded. (probably because they are binary)
		/// </summary>
		public ISet<String> FiletypeBlacklist = new HashSet<string>();

		LuceneIndexer indexer;

		/// <summary>
		/// Initializes SubversionSearcher. Will use Tortoise Credentials Cache.
		/// </summary>
		/// <param name="rawUrl">Any Url inside the repository</param>
		/// <exception cref="System.Exception"></exception>
		public SubversionSearcher(string rawUrl) : this(rawUrl, null, null) { }


		/// <summary>
		/// Initializes SubversionSearcher. Will use given credentials.
		/// </summary>
		/// <param name="rawUrl">Any Url inside the repository</param>
		/// <param name="username">Username to use</param>
		/// <param name="password">Password to use</param>
		/// <exception cref="System.Exception"></exception>
		public SubversionSearcher(string rawUrl, string username, string password)
		{
			maxThreads = Settings.Instance.MaxThreads;

			runningProcesses = new ConcurrentDictionary<Process, byte>();

			useCredentials = username != null && password != null;
			this.username = username;
			this.password = password;

			runningThreads = new List<Thread>();

			SvnClient client = GetFreshSvnClient();

			ISet<string> bla = new HashSet<string>(Settings.Instance.FileExtensionBlacklist);

			foreach (string s in bla)
			{
				FiletypeBlacklist.Add(s);
			}

			RepositoryUrl = GetRepositoryBase(rawUrl);

			Thread t = new Thread(() => { LoadRepositoryStructure(client); });
			t.Start();
			runningThreads.Add(t);

			bool initIndexerSuccess = true;
			Thread tt = new Thread(() =>
			{
				try
				{
					indexer = new LuceneIndexer(RepositoryUrl);
				}
				catch (Exception ex)
				{
					initIndexerSuccess = false;
					Progress.ErrorLog(ex);
				}
			});
			tt.Start();
			runningThreads.Add(tt);

			foreach (var v in runningThreads)
			{
				v.Join();
			}

			if (!initIndexerSuccess)
			{
				Progress.Log("Failed to initialize indexer. See error.log");
				this.Close();
			}
		}


		~SubversionSearcher()
		{
			if (!savedTaggedFolders)
			{
				SaveLogToFile(GetLogCacheFilename(RepositoryUrl), SimplifiedChangeItems, RepositoryRevisions, NodesTaggedAsFolder);
				savedTaggedFolders = true;
			}
			Settings.ClearTemporaryFiles();
			Close();
		}

		public void Close()
		{
			CancelSearch();
			this._disposed.Set(true);
			if (indexer != null)
			{
				indexer.Dispose();
			}
		}


		/// <summary>
		/// Checks if the specified path exists.
		/// tries to correct for character casing if it doesn't.
		/// </summary>
		/// <returns>Corrected Head node path. (relative to repository root path.</returns>
		/// <exception cref="System.Exception">If the path does not start with this SubversionSearcher's RepositoryUrl</exception>
		public string GetLowestExistingHeadNodePath(string rawUrl, long revision)
		{
			if (RepositoryUrl.Trim('/').Length + 1 >= rawUrl.Trim('/').Length)
			{
				// the URL that was typed in in the same as the rawUrl
				return "";
			}

			string expectedHeadNode = rawUrl.Substring(RepositoryUrl.Trim('/').Length + 1).Trim('/');

			if (GetNodeAtTime(expectedHeadNode, revision) != null)
			{
				// no correction needs to be done
				return expectedHeadNode;
			}

			// the path specified does not exist. -> try to correct for character casing

			int goodNodes = 0;

			string[] nodes = expectedHeadNode.Split('/');
			for (int i = 0; i < nodes.Length; i++)
			{
				string parentPath = String.Join("/", nodes, 0, i);
				string currentPath = String.Join("/", nodes, 0, i + 1);

				if (GetNodeAtTime(currentPath, revision) == null)
				{

					var list = GetChildrenInHierarchy(parentPath, revision);

					bool foundOne = false;
					bool foundMany = false;
					foreach (var e in list)
					{
						var f = e.Item1.Substring(parentPath.Length).Trim('/');
						var g = f.ToLower();
						if (g == nodes[i].ToLower())
						{
							if (!foundOne)
							{
								nodes[i] = f;
								goodNodes++;
								foundOne = true;
							}
							else
							{
								foundMany = true;
								goodNodes--;
								break;
							}

						}
					}

					if (!foundOne || foundMany)
					{
						break;
					}

				}
				else
				{
					goodNodes++;
				}
			}

			return String.Join("/", nodes, 0, goodNodes);
		}


		/// <summary>
		/// Stops all running threads and processes involved in the search
		/// </summary>
		public void CancelSearch()
		{
			_inSearch.Set(false);
			if (runningThreads != null)
			{
				Progress.Log("Cancelling Search");
				foreach (var p in runningProcesses)
				{
					p.Key.StandardInput.Close();
				}
				foreach (Thread t in runningThreads)
				{
					t.Abort();
				}
				Thread.Sleep(500);
				foreach (var p in runningProcesses)
				{
					p.Key.Kill();
				}
				foreach (Thread t in runningThreads)
				{
					t.Join();
				}
			}
			currentlyLoading.Set(false);
			GC.Collect();

			Progress.Reset();
		}



		private class StreamDisposingConcurrentQueue : ConcurrentQueue<Tuple<Stream, DiffRequest>>
		{
			~StreamDisposingConcurrentQueue()
			{
				foreach (var t in this)
				{
					if (t != null && t.Item1 != null)
						t.Item1.Dispose();
				}
			}
		}


		AtomicBoolean currentlyLoading = new AtomicBoolean(false);
		/// <summary>
		/// Loads necessary diffs from subversion server. Does not allow to be called from multiple threads
		/// </summary>
		/// <param name="forceSingleRequests">does not try to make large request that contain multiple diffs</param>
		/// <returns>true if successful. falses if not</returns>
		bool Load(SearchOptions searchOptions,
			ref IDictionary<string, IList<MovementInfo>> movementInfos,
			ref IDictionary<DiffInfo, IList<string>> diffInfoFileRelation,
			bool forceSingleRequests = false)
		{

			totalBytesDownloaded = 0;

			if (currentlyLoading.CompareAndSet(false, true) == false)
			{
				return false;
			}

			ISet<string> filesOfInterest = new HashSet<string>();

			foreach (string f in searchOptions.Files)
			{
				// removing binaries
				if (FiletypeBlacklist.Contains(Path.GetExtension(f).ToLower()) == false)
				{
					filesOfInterest.Add(f);
				}
			}

			movementInfos = GetMovementInfos(searchOptions);

			if (searchOptions.SearchInContent)
			{
				GetDiffInfos(filesOfInterest, searchOptions, out diffInfoFileRelation);
			}
			else
			{
				diffInfoFileRelation = new Dictionary<DiffInfo, IList<string>>();
			}

			// ##############################

			if (searchOptions.SearchInContent)
			{
				ConcurrentQueue<DiffRequest> diffQueue;
				ConcurrentQueue<Tuple<Stream, DiffRequest>> takeRelevantQueue = new StreamDisposingConcurrentQueue();
				ManualResetEvent somethingInTakeRelevantQueue = new ManualResetEvent(false);

				CreateDiffQueue(diffInfoFileRelation, out diffQueue, false, forceSingleRequests);

				bool complete = true;
				foreach (var kv in diffInfoFileRelation)
				{

					if (!totalExpected.Contains(kv.Key) && !equalDiffs.ContainsKey(kv.Key) && !indexer.HasDiff(kv.Key))
					{
						Progress.DebugLog("Missing from Requests: {0}", kv.Key);
						complete = false;
					}
				}
				if (complete)
				{
					Progress.DebugLog("DiffRequests seem to contain every desired diff");
				}

				Console.WriteLine("Diffs To Do: {0}", diffQueue == null ? 0 : diffQueue.Count);

				Stopwatch dlsw = new Stopwatch();
				dlsw.Start();

				// Starting LoadDiff Threads
				int ldThreadAmount = Math.Min(diffQueue != null ? diffQueue.Count : 0, maxThreads);

				Utils.Vardump<DiffRequest>("diffRequests.txt", diffQueue, (dr) => { return dr.ToString(); });

				runningThreads = new List<Thread>();
				Console.WriteLine("starting {0} Diff Threads", ldThreadAmount);

				Progress.Log(String.Format("Fetching {0} unified diffs from subversion server...", diffQueue != null ? diffQueue.Count : 0));

				IList<Thread> runningFetchingThreads = new List<Thread>();

				for (int i = 0; i < ldThreadAmount; i++)
				{
					int icopy = i;
					Thread t = new Thread(() => LoadDiffsUsingSharpSvn(diffQueue, takeRelevantQueue, somethingInTakeRelevantQueue));

					runningThreads.Add(t);
					runningFetchingThreads.Add(t);
					t.Start();
				}

				AtomicBoolean stillFetching = new AtomicBoolean(true);

				int takeRelevantThreadAmout = Math.Max(1, ldThreadAmount / 5);
				for (int i = 0; i < takeRelevantThreadAmout; i++)
				{
					Thread t = new Thread(() => { TakeRelevantTask(stillFetching, takeRelevantQueue, somethingInTakeRelevantQueue); });
					runningThreads.Add(t);
					t.Start();
				}


				// checks if there are still fetching threads and start a new one if one died somehow
				while (diffQueue.Count > 0)
				{
					Progress.Log(String.Format("Fetching {0} unified diffs from subversion server...", diffQueue != null ? diffQueue.Count : 0));
					Thread.Sleep(500);

					bool hasWorkers = false;
					foreach (Thread t in runningFetchingThreads)
					{
						if (!t.Join(10))
						{
							hasWorkers = true;
							break;
						}
					}

					if (!hasWorkers)
					{

						if (!InSearch)
						{
							break;
						}

						Progress.DebugLog("had to start a fetching thread");

						int icopy = runningFetchingThreads.Count;

						Thread t = new Thread(() => LoadDiffsUsingSharpSvn(diffQueue, takeRelevantQueue, somethingInTakeRelevantQueue));

						runningThreads.Add(t);
						runningFetchingThreads.Add(t);
						t.Start();
					}

				}

				foreach (Thread t in runningFetchingThreads)
				{
					t.Join();
				}

				stillFetching.Set(false);

				foreach (Thread t in runningThreads)
				{
					t.Join();
				}
			}

			Progress.DebugLog("Total Bytes downloaded: {0}", totalBytesDownloaded);

			GC.Collect();

			currentlyLoading.CompareAndSet(true, false);
			return true;
		}


		private static int currentUsedFileNumber = 0;
		/// <summary>
		/// Creates and gets a temporary file.
		/// </summary>
		/// <returns></returns>
		private static FileStream GetTempFile()
		{
			while (true)
			{
				int number = Interlocked.Increment(ref currentUsedFileNumber);
				string fname = string.Format("tmpstr{0}.tmp", number);

				try
				{
					FileStream result = new FileStream(Utils.JoinPathsWin(Settings.TempPath, fname), FileMode.Create, FileAccess.ReadWrite);
					return result;
				}
				catch
				{
					continue;
				}
			}
		}

		/// <summary>
		/// Worker that loads DiffsRequests in diffQueue using sharpsvn and pushes results to takeRelevantQueue
		/// </summary>
		/// <param name="diffQueue">input queue</param>
		/// <param name="takeRelevantQueue">output queue</param>
		/// <param name="somethingInTakeRelevantQueue">ManualResetEvent that is set when something was pushed to takeRelevantQueue</param>
		void LoadDiffsUsingSharpSvn(
			ConcurrentQueue<DiffRequest> diffQueue,
			ConcurrentQueue<Tuple<Stream, DiffRequest>> takeRelevantQueue,
			ManualResetEvent somethingInTakeRelevantQueue)
		{

			try
			{
				SvnClient client = GetFreshSvnClient();
				DiffRequest diffRequest;

				while (diffQueue.TryDequeue(out diffRequest))
				{

					try
					{
						Stream errorStream = new MemoryStream();
						SvnDiffArgs args = new SvnDiffArgs()
						{
							CopiesAsAdds = true,
							NoDeleted = true,
							NoProperties = true,
							NoAdded = false,
							ErrorStream = errorStream,
							IgnoreAncestry = true
						};

						Stream stream = GetTempFile();

						client.Diff(RepositoryUrl + diffRequest.Path, new SvnRevisionRange(diffRequest.RevA, diffRequest.RevB), args, stream);

						if (errorStream.Length > 0)
						{
							// outputting error stream if there is one
							errorStream.Position = 0;
							StreamReader r = new StreamReader(errorStream);

							string argsUsed = "";
							foreach (var o in args.DiffArguments)
							{
								argsUsed += o + ' ';
							}

							string eStr = String.Format("Error diffing {0}, Args Used: {1}\n{2}", diffRequest, argsUsed, r.ReadToEnd());
							Progress.DebugLog(eStr);
							Progress.ErrorLog(eStr);

						}
						else if (stream.Length == 0)
						{
							// re-enqueueing diffs as single requests or tagging as folder if possible

							Progress.AddFinishedWork(diffRequest.ContainedDiffs.Count);

							if (diffRequest.ContainedDiffs.Count == 1)
							{

								DiffInfo diff = diffRequest.ContainedDiffs.First();

								if (diffRequest.RevA == diff.RevA)
								{
									if (diff.NodeAtTime != null && !diff.NodeAtTime.IsFile)
									{
										TagFolder(diff);
									}
									else
									{
										// propery change in file -> add empty diff to db
										indexer.AddToIndex(diff, new MemoryStream(), null);
									}
								}
								else
								{
									diffQueue.Enqueue(new DiffRequest(diff.Path, diff.RevA, diff.RevB, new List<DiffInfo> { diff }));
									Progress.AddTotalWork();
								}

							}
							else
							{
								foreach (var diff in diffRequest.ContainedDiffs)
								{
									diffQueue.Enqueue(new DiffRequest(diff.Path, diff.RevA, diff.RevB, new List<DiffInfo> { diff }));
									Progress.AddTotalWork();
								}
							}

						}
						else
						{
							Interlocked.Add(ref totalBytesDownloaded, stream.Length);

							takeRelevantQueue.Enqueue(new Tuple<Stream, DiffRequest>(stream, diffRequest));
							somethingInTakeRelevantQueue.Set();
						}

					}
					catch (ThreadAbortException ex)
					{
						throw ex;
					}
					catch (Exception ex)
					{
						Progress.ErrorLog(ex);
					}

					if (!InSearch)
					{
						break;
					}

				}

				Progress.DebugLog("Load Diffs Task shut down");
				Console.WriteLine("Load Diffs Task shut down");
			}
			catch (ThreadAbortException)
			{
				Thread.ResetAbort();
			}
		}


		/// <summary>
		/// worker that parses combined diffs from queue and stores diffs in Indexer
		/// </summary>
		/// <param name="stillFetching">has to be set when diffs are still downloading</param>
		/// <param name="queue">input queue</param>
		/// <param name="somethingNewInQueue">Is reset if queue is empty</param>
		private void TakeRelevantTask(AtomicBoolean stillFetching, ConcurrentQueue<Tuple<Stream, DiffRequest>> queue, ManualResetEvent somethingNewInQueue)
		{
			try
			{
				while (InSearch && (stillFetching.Get() || queue.Count > 0))
				{

					while (!somethingNewInQueue.WaitOne(200) && stillFetching.Get())
					{
						if (!InSearch)
						{
							return;
						}
					}

					Tuple<Stream, DiffRequest> tup;

					while (queue.TryDequeue(out tup))
					{

						if (!InSearch)
						{
							break;
						}

						using (tup.Item1)
						{
							try
							{
								TakeRelevant(tup.Item1, tup.Item2);
							}
							catch (ThreadAbortException ex)
							{
								throw ex;
							}
							catch (Exception ex)
							{
								Progress.ErrorLog(ex);
							}
						}
					}

					somethingNewInQueue.Reset();
					if (queue.Count > 0)
					{
						somethingNewInQueue.Set();
					}
				}
			}
			catch (ThreadAbortException)
			{
				Thread.ResetAbort();
			}
			catch (Exception ex)
			{
				Progress.ErrorLog(ex);
			}
		}


		/// <summary>
		/// Parses fullStream and and adds diffs to indexer
		/// </summary>
		/// <param name="fullStream"></param>
		/// <param name="diffRequest"></param>
		private void TakeRelevant(Stream fullStream, DiffRequest diffRequest)
		{

			if (diffRequest.ContainedDiffs.Count == 0)
			{
				return;
			}

			IDictionary<string, DiffInfo> contained = new Dictionary<string, DiffInfo>();

			foreach (var c in diffRequest.ContainedDiffs)
			{

				if (c.Path == diffRequest.Path)
				{
					contained.Add(Path.GetFileName(c.Path), c);
				}
				else if (diffRequest.Path == "")
				{
					contained.Add(c.Path, c);
				}
				else
				{
					string path = c.Path.Substring(diffRequest.Path.Length + 1, c.Path.Length - diffRequest.Path.Length - 1);
					contained.Add(path, c);
				}
			}
			int initialContained = contained.Count;

			fullStream.Position = 0;
			StreamReader reader = new StreamReader(fullStream);

			int foundFiles = 0;

			DiffInfo currentDiff = null;
			Stream currentDiffStream = null;
			StreamWriter smallWriter = null;

			Action<DiffInfo, Stream> addCurrent = new Action<DiffInfo, Stream>((di, str) =>
			{
				ISet<DiffInfo> eq;
				equalDiffs.TryGetValue(di, out eq);
				indexer.AddToIndex(di, str, eq);
			});

			string line;
			while ((line = reader.ReadLine()) != null)
			{

				if (line.Length > "Index: ".Length && line.StartsWith("Index: "))
				{
					foundFiles++;

					if (currentDiff != null)
					{
						addCurrent(currentDiff, currentDiffStream);
					}

					string foundName = line.Substring("Index: ".Length).Trim();

					if (contained.TryGetValue(foundName, out currentDiff))
					{
						currentDiffStream = new MemoryStream();
						smallWriter = new StreamWriter(currentDiffStream) { AutoFlush = true };
						contained.Remove(foundName);

					}
					else if (foundName == "." && diffRequest.ContainedDiffs.Count == 1)
					{
						var di = diffRequest.ContainedDiffs.First();
						Progress.DebugLog("Detected Folder: {0}@{1}", di.Path, di.RevB);
						TagFolder(di);
						currentDiffStream = null;
						smallWriter = null;

					}
					else
					{
						currentDiffStream = null;
						smallWriter = null;
						//Progress.DebugLog("File {0} is not expected anywhere", foundName);
					}
				}

				if (smallWriter != null)
				{
					smallWriter.WriteLine(line);
				}
			}

			if (currentDiff != null)
			{
				addCurrent(currentDiff, currentDiffStream);
			}

			if (contained.Count != 0)
			{
#if DEBUG
				Progress.DebugLog("Amount of files found differs from the expected amount, read at: {0}.txt", contained.GetHashCode());
				using (Stream fs = new FileStream(Utils.JoinPathsWin(Settings.BadDiffStreamsPath, contained.GetHashCode().ToString() + ".txt"), FileMode.Create, FileAccess.Write))
				{
					StreamWriter wri = new StreamWriter(fs) { AutoFlush = true };
					foreach (var c in diffRequest.ContainedDiffs)
					{
						wri.WriteLine(c);
					}
					wri.WriteLine("Stream Length: {0}", fullStream.Length);
					fullStream.Position = 0;
					fullStream.CopyTo(fs);
				}
#endif
				Progress.AddFailedRequest();
			}

#if DEBUG
			if (foundFiles > initialContained * 3)
			{
				Utils.WriteStreamToFile(Utils.JoinPathsWin(Settings.BadDiffStreamsPath, String.Format("r_{0}_{1}_{2}.txt", diffRequest.RevB, foundFiles, initialContained)), fullStream);
			}
#endif

			string toLog = String.Format("Stream Length: {0,11}  Found Files: {1,5}  Useful Files: {2,5}   {3,7}   Revision: {4,5}  {5}",
				fullStream.Length, foundFiles, initialContained, contained.Count != 0 ? "ERROR" : "SUCCESS", diffRequest.RevB, diffRequest.Path);
			Console.WriteLine(toLog);
			Progress.DebugLog(toLog);
			Progress.AddFinishedWork(initialContained);
		}

		#region Create Diff queue

		private class SingleSpan
		{
			public int Start = 0;
			public int Length = 0;

			public void AddTo(int amount)
			{
				Length += amount;
			}

			public void SetStart(int position)
			{
				Start = position;
			}
			public void SetStart(IList<DiffInfo> breadBase)
			{
				Start = breadBase.Count;
			}
		}

		/// <summary>
		/// creates a diff request queue
		/// </summary>
		/// <param name="diffInfoFileRelation"></param>
		/// <param name="diffQueue"></param>
		/// <param name="notrash"></param>
		/// <param name="forceSingeleRequests"></param>
		private void CreateDiffQueue(
			IDictionary<DiffInfo, IList<string>> diffInfoFileRelation,
			out ConcurrentQueue<DiffRequest> diffQueue,
			bool notrash,
			bool forceSingeleRequests = false)
		{

			totalExpected = new HashSet<DiffInfo>();
			equalDiffs = new ConcurrentDictionary<DiffInfo, ISet<DiffInfo>>();
			diffQueue = new ConcurrentQueue<DiffRequest>();

			if (forceSingeleRequests)
			{
				CreateDiffQueueWithSingleRequests(diffInfoFileRelation, diffQueue);
				return;
			}

			ISet<DiffInfo> willHaveDiffs = new HashSet<DiffInfo>();

			Dictionary<long, IList<DiffInfo>> diffInfoByRevision = new Dictionary<long, IList<DiffInfo>>();
			Dictionary<Tuple<long, string>, SingleSpan> nodeToSpan = new Dictionary<Tuple<long, string>, SingleSpan>();
			Dictionary<long, IList<DiffInfo>> bread = new Dictionary<long, IList<DiffInfo>>();

			foreach (var kv in diffInfoFileRelation)
			{

				if (!indexer.HasDiff(kv.Key))
				{

					IList<DiffInfo> li;
					if (!diffInfoByRevision.TryGetValue(kv.Key.RevB, out li))
					{
						diffInfoByRevision[kv.Key.RevB] = li = new List<DiffInfo>();
					}
					li.Add(kv.Key);
				}
			}

			// alle diffs, die schon im Index sind rausgefiltert

			// in ein Dictionary mit Revision als Key und Liste von Diffs als Value

			IList<KeyValuePair<long, IList<DiffInfo>>> list = new List<KeyValuePair<long, IList<DiffInfo>>>();

			foreach (var e in diffInfoByRevision)
			{
				list.Add(e);
			}
			list = list.OrderBy(kv => kv.Key).ToList();

			// dictionary sortiert nach revision (Liste mit Tuple<revision, liste<Diff>>)

			foreach (var kv in list)
			{

				// für jede Revision, in der wir Diffs brauchen, die noch nicht im Indexer sind

				Progress.Log("Creating diff queue... Revision {0}  DiffRequests: {1}", kv.Key, diffQueue.Count);

				var diffAxis = kv.Value.OrderBy(t => t.Path).ToList(); // diffInfos of this revision sorted alphabetically

				var breadBase = new List<DiffInfo>();
				var tree = new Dictionary<string, ICollection<string>>();

				// Node-Namen und Kinderliste

				bread.Add(kv.Key, breadBase);

				for (int i = 0; i < diffAxis.Count; i++)
				{

					// für jede Diff in dieser Revision, alphabetisch sortiert, damit man besser einen Baum aufbauen kann

					if (!willHaveDiffs.Contains(diffAxis[i]))
					{

						// für alle Diffs, deren Inhalt wir nicht schon durch eine identische Diff bekommen

						var split = diffAxis[i].Path.Split('/');
						string currentPath = "";
						string parentPath = null;

						for (int j = -1; j < split.Length; j++)
						{
							if (j > 0)
							{
								currentPath += '/' + split[j];
							}
							else if (j == 0)
							{
								currentPath += split[j];
							}

							SingleSpan mt;
							var key = new Tuple<long, string>(kv.Key, currentPath);
							if (!nodeToSpan.TryGetValue(key, out mt))
							{
								nodeToSpan[key] = mt = new SingleSpan();
								mt.SetStart(breadBase);
							}
							mt.AddTo(1);

							// building tree
							if (parentPath != null)
							{
								ICollection<string> li;
								if (!tree.TryGetValue(parentPath, out li))
								{
									tree[parentPath] = li = new List<string>();
								}

								if (!li.Contains(currentPath))
								{
									li.Add(currentPath);
								}
							}
							parentPath = currentPath;

							if (!tree.ContainsKey(currentPath))
							{
								tree.Add(currentPath, new List<string>());
							}
						}

						breadBase.Add(diffAxis[i]);

						if (diffAxis[i].NodeAtTime != null)
						{

							ISet<DiffInfo> dis = new HashSet<DiffInfo>();
							ISet<NodeAtTime> nodli;
							if (equalAdds.TryGetValue(diffAxis[i].NodeAtTime, out nodli))
							{
								foreach (var nat in nodli)
								{

									var creation = GetCreation(nat);
									if (creation != null)
									{
										dis.Add(creation);
										equalDiffs.TryAdd(creation, dis);
										willHaveDiffs.Add(creation);
									}
									else
									{
										// only happens if this node is a folder
										// none of the nodes in equal diffs need to be diffed
									}
								}
							}
						}
					}

				}


				IList<DiffRequest> res;
				if (notrash)
				{
					res = Rigatoni(diffAxis, breadBase, tree, nodeToSpan, table, kv.Key, "", 1f, 0);
				}
				else
				{
					res = Rigatoni(diffAxis, breadBase, tree, nodeToSpan, table, kv.Key, "");
				}

				if (res != null && res.Count > 0)
				{
					foreach (var dr in res)
					{
						if (dr.ContainedDiffs.Count > 0)
						{
							diffQueue.Enqueue(dr);
							Progress.AddTotalWork(dr.ContainedDiffs.Count);

							foreach (var c in dr.ContainedDiffs)
							{
								totalExpected.Add(c);
							}
						}
					}
				}
			}
		}

		/// <summary>
		/// There is no easy way to explain this. It's a recursive part of CreateDiffQueue
		/// It goes down the tree until the ration of good to unnecessary diffs is good enough
		/// </summary>
		/// <param name="diffAxis"></param>
		/// <param name="breadBase"></param>
		/// <param name="tree"></param>
		/// <param name="nodeToSpan"></param>
		/// <param name="table"></param>
		/// <param name="revision"></param>
		/// <param name="path"></param>
		/// <param name="minimumGoodToBadRatio"></param>
		/// <param name="maxRest"></param>
		/// <returns></returns>
		private IList<DiffRequest> Rigatoni(
			IList<DiffInfo> diffAxis,
			IList<DiffInfo> breadBase,
			IDictionary<string, ICollection<string>> tree,
			IDictionary<Tuple<long, string>, SingleSpan> nodeToSpan,
			Table table,
			long revision,
			string path,
			float minimumGoodToBadRatio = 0.55f,
			int maxRest = 4)
		{

			float binaryFileWeight = 0.3f;

			SingleSpan mt;
			if (nodeToSpan.TryGetValue(new Tuple<long, string>(revision, path), out mt) && mt.Length > 0)
			{
				NodeDiffAmount nda = table.GetNodeDiffAmount(revision, path);

				IList<DiffRequest> result = new List<DiffRequest>();

				var children = tree[path];

				if (children.Count == 0 ||
					(children.Count > 1 && ((float)mt.Length / (nda.TextFileAmount + nda.BinaryFileAmount * binaryFileWeight) >= minimumGoodToBadRatio ||
					mt.Length + maxRest >= (nda.TextFileAmount + nda.BinaryFileAmount * binaryFileWeight))))
				{

					IList<DiffInfo> contained = new List<DiffInfo>();

					for (int k = mt.Start; k < mt.Start + mt.Length; k++)
					{
						contained.Add(breadBase[k]);
					}

					result.Add(new DiffRequest(path, revision - 1, revision, contained));
				}
				else
				{

					foreach (var n in children)
					{
						foreach (var d in Rigatoni(diffAxis, breadBase, tree, nodeToSpan, table, revision, n, minimumGoodToBadRatio, maxRest))
						{
							result.Add(d);
						}
					}
				}

				return result;
			}
			return null;
		}

		/// <summary>
		/// DiffRequests to given diffQueue
		/// </summary>
		/// <param name="diffQueue"></param>
		private void CreateDiffQueueWithSingleRequests(IDictionary<DiffInfo, IList<string>> diffInfoFileRelation, ConcurrentQueue<DiffRequest> diffQueue)
		{

			foreach (var kv in diffInfoFileRelation)
			{
				if (!indexer.HasDiff(kv.Key))
				{
					diffQueue.Enqueue(new DiffRequest(kv.Key.Path, kv.Key.RevB - 1, kv.Key.RevB, new List<DiffInfo> { kv.Key }, true));
					totalExpected.Add(kv.Key);
					Progress.AddTotalWork();
				}
			}
		}

		#endregion


		/// <summary>
		/// Saves SVN log to a file.
		/// Produces file can be parsed by LoadLogFromFile()
		/// </summary>
		/// <param name="changeItems">List of changeItems</param>
		/// <param name="commitInfos">List of commit infos</param>
		/// <param name="taggedAsFolder">List of Nodes that are tagged as folders</param>
		private void SaveLogToFile(string filename, IList<SimplifiedSvnChangeItem> changeItems, IList<CommitInfo> commitInfos, ISet<Tuple<string, long>> taggedAsFolder)
		{
			Stream fs;
			try
			{
				using (fs = new FileStream(filename, FileMode.Create, FileAccess.ReadWrite))
				{
					fs.Position = 32;

					BinaryWriter writer = new BinaryWriter(fs);
					writer.Write(commitInfos.Count);
					writer.Write(changeItems.Count);
					writer.Write(taggedAsFolder.Count);


					foreach (var item in commitInfos)
					{
						item.AddSelfToStream(writer);
					}
					foreach (var item in changeItems)
					{
						item.AddSelfToStream(writer);
					}
					foreach (var t in taggedAsFolder)
					{
						writer.Write(t.Item2);
						writer.Write(t.Item1);
					}

					fs.Position = 32;
					SHA256 sha = SHA256.Create();
					byte[] calculatedHash = sha.ComputeHash(fs);
					fs.Position = 0;
					fs.Write(calculatedHash, 0, calculatedHash.Length);
				}
			}
			catch (Exception ex)
			{
				Progress.ErrorLog(ex);
				return;
			}
		}

		/// <summary>
		/// Loads SVN log from file that was produces by SaveLogToFile().
		/// </summary>
		/// <param name="changeItems"></param>
		/// <param name="revisions"></param>
		/// <param name="nodesTaggedAsFolder"></param>
		/// <returns></returns>
		private long LoadLogFromFile(string filename, out IList<SimplifiedSvnChangeItem> changeItems, out IList<CommitInfo> revisions, out ISet<Tuple<string, long>> nodesTaggedAsFolder)
		{
			Stopwatch sw = new Stopwatch();
			sw.Start();
			Progress.Log("loading log from file");

			changeItems = new List<SimplifiedSvnChangeItem>();
			revisions = new List<CommitInfo>();
			nodesTaggedAsFolder = new HashSet<Tuple<string, long>>();

			if (!File.Exists(filename))
			{
				return 0;
			}
			try
			{
				using (var fs = new FileStream(filename, FileMode.Open, FileAccess.ReadWrite))
				{
					if (fs.Length > 32)
					{
						byte[] readHash = new byte[32];
						fs.Position = 0;
						fs.Read(readHash, 0, readHash.Length);
						fs.Position = readHash.Length;
						SHA256 sha = SHA256.Create();
						byte[] calculated = sha.ComputeHash(fs);

						if (!calculated.SequenceEqual(readHash))
						{
							fs.SetLength(0);
							return 0;
						}

						fs.Position = readHash.Length;
						BinaryReader reader = new BinaryReader(fs);
						int revisionCount = reader.ReadInt32();
						int changeItemCount = reader.ReadInt32();
						int taggedFolderCount = reader.ReadInt32();

						for (int i = 0; i < revisionCount; i++)
						{
							revisions.Add(new CommitInfo(reader));
						}
						for (int i = 0; i < changeItemCount; i++)
						{
							changeItems.Add(new SimplifiedSvnChangeItem(reader));
						}
						for (int i = 0; i < taggedFolderCount; i++)
						{
							long revision = reader.ReadInt64();
							string path = reader.ReadString();
							nodesTaggedAsFolder.Add(new Tuple<string, long>(path, revision));
						}
					}
				}
				sw.Stop();
				Progress.Log("finished loading log from file");
				Progress.DebugLog("Loading log from file time: {0}ms", sw.Elapsed.TotalMilliseconds);

				if (revisions.Count > 0)
				{
					return revisions[revisions.Count - 1].Revision;
				}
				else
				{
					return 0;
				}
			}
			catch (Exception ex)
			{
				Progress.ErrorLog(ex);

				changeItems = new List<SimplifiedSvnChangeItem>();
				revisions = new List<CommitInfo>();
			}

			return 0;
		}


		private void LoadRepositoryStructure(SvnClient client)
		{
			IList<CommitInfo> revisions;
			IList<SimplifiedSvnChangeItem> changeItems;
			long cachedLogUntil = LoadLogFromFile(GetLogCacheFilename(RepositoryUrl), out changeItems, out revisions, out NodesTaggedAsFolder);

			Collection<SvnLogEventArgs> revs;
			SvnLogArgs args = new SvnLogArgs()
			{
				StrictNodeHistory = false,
				Range = new SvnRevisionRange(new SvnRevision(cachedLogUntil), SvnRevision.Head),

			};

			Progress.Log("Fetching log...");

			try
			{
				Stopwatch sw = new Stopwatch();
				sw.Start();
				bool success = client.GetLog(new Uri(RepositoryUrl), args, out revs);
				sw.Stop();
				//Progress.DebugLog("log time: {0}ms ({1} Revisions from cache; {2} fetched)", sw.Elapsed.TotalMilliseconds, cachedLogUntil, revs.Count);

				if (success)
				{
					if (cachedLogUntil > 0)
					{
						revs.RemoveAt(0);
					}

					foreach (var e in revs)
					{
						if (e != null)
						{
							revisions.Add(new CommitInfo(e.Revision, e.LogMessage, e.Author, e.Time));

							if (e.ChangedPaths != null)
							{
								foreach (var i in e.ChangedPaths)
								{
									changeItems.Add(new SimplifiedSvnChangeItem(e.Revision, i.Path, i.Action, i.NodeKind, i.CopyFromPath, i.CopyFromRevision));
								}
							}
						}
					}

					SimplifiedChangeItems = changeItems;
					RepositoryRevisions = revisions;
					SaveLogToFile(GetLogCacheFilename(RepositoryUrl), changeItems, revisions, NodesTaggedAsFolder);

					BuildRepositoryStructure(revisions, changeItems);
				}
				else
				{
					Progress.Log("Failed to fetch log");
					Progress.ErrorLog("Failed to fetch log {0}", RepositoryUrl);
				}
			}
			catch (Exception ex)
			{
				Progress.ErrorLog("Failed to fetch Log: \r\n{0}", ex);
			}
		}


		SvnClient GetFreshSvnClient()
		{
			SvnClient result = new SvnClient();


			if (useCredentials)
			{
				result.Authentication.Clear();
				result.Authentication.DefaultCredentials = new System.Net.NetworkCredential(username, password);
			}

			result.Authentication.SslServerTrustHandlers += delegate (object sender, SvnSslServerTrustEventArgs e)
			{
				e.AcceptedFailures = e.Failures;
				e.Save = true;
			};

			return result;
		}


		/// <summary>
		/// speeds up the process if one searches in the same files as last time.
		/// </summary>
		int lastSearchOptionLoaded = 0;
		IDictionary<DiffInfo, IList<string>> diffInfoFileRelations = null;
		IDictionary<string, IList<MovementInfo>> movementInfos = null;

		/// <summary>
		/// Main search function
		/// </summary>
		/// <returns>null if search was cancelled or loading failed. otherwise: SearchResults object</returns>
		public SearchResults Search(SearchOptions searchOptions)
		{
			if (this.Disposed)
			{
				Progress.DebugLog("Search called on closed SubversionSearcher");
				return null;
			}
			_inSearch.Set(true);

			Progress.Reset();

			Stopwatch swTotal = Stopwatch.StartNew();

			Stopwatch swLoad = Stopwatch.StartNew();
			bool hasToReload = lastSearchOptionLoaded == 0 || diffInfoFileRelations == null || movementInfos == null || lastSearchOptionLoaded != searchOptions.GetHashCodeReloadRelevant();

			bool isComplete = true;
			int retriesLeft = 2;
			IList<DiffInfo> missing = new List<DiffInfo>();
			bool loadSucceded = true;
			while (hasToReload)
			{
				isComplete = true;

				if (loadSucceded = Load(searchOptions, ref movementInfos, ref diffInfoFileRelations, retriesLeft == 1))
				{

					missing = new List<DiffInfo>();
					foreach (var kv in diffInfoFileRelations)
					{
						if (!indexer.HasDiff(kv.Key))
						{
							if (!NodesTaggedAsFolder.Contains(new Tuple<string, long>(kv.Key.Path, kv.Key.RevB)))
							{
								Progress.DebugLog("Still missing {0}", kv.Key);
								missing.Add(kv.Key);
								isComplete = false;
							}
						}
					}

					Utils.Vardump<DiffInfo>(String.Format("missing_retriesLeft{0}.txt", retriesLeft), missing, (d) => d.ToString());

				}
				else
				{
					isComplete = false;
				}

				if (isComplete)
				{
					break;
				}
				else
				{
					if (retriesLeft-- > 0)
					{
						Progress.DebugLog("retrying");
						hasToReload = true;
					}
					else
					{
						break;
					}
				}
			}

			if (!loadSucceded)
			{
				return null;
			}
			lastSearchOptionLoaded = searchOptions.GetHashCodeReloadRelevant();

			if (!this.InSearch)
			{
				return null;
			}



			ISet<string> filesContainingTextInFileName = new HashSet<string>();
			Task t = new Task(() =>
			{
				if (searchOptions.SearchInRenames)
				{
					foreach (KeyValuePair<string, IList<MovementInfo>> kv in movementInfos)
					{
						if (SearchNameHistory(kv.Value, searchOptions))
						{
							filesContainingTextInFileName.Add(kv.Key);
						}
					}
				}
			});
			t.Start();

			Progress.Log("Searching...");
			ISet<DiffInfo> toSearch = new HashSet<DiffInfo>(diffInfoFileRelations.Keys);

			ConcurrentBag<DiffInfo> notFound;
			var filesContainingTextInContent = indexer.SearchIndex(searchOptions, toSearch, out notFound);
			if (notFound.Count > 0)
			{
				isComplete = false;
			}

			t.Wait();

			Progress.Log("Loading results...");
			int resultCount;
			var rs = GetFoundFiles(searchOptions, diffInfoFileRelations, movementInfos, filesContainingTextInFileName, filesContainingTextInContent, out resultCount);
			SearchResults result = new SearchResults(rs, searchOptions, resultCount);

			if (!isComplete || Progress.GetFailedRequests() > 0)
			{

				Progress.DebugLog("Search might be incomplete: \r\n\t{0} failed requests\r\n\tSome diffInfos are still missing: {1}", Progress.GetFailedRequests(), !isComplete);
				Progress.Log(Progress.GetLogMessage() + "; Search might be incomplete");

				var filename = Utils.JoinPathsWin(Settings.TempPath, String.Format("failedSearch{0}.txt", DateTime.Now.ToString("yyyyMMddHHmmss")));
				try
				{
					using (var str = new FileStream(filename, FileMode.Create, FileAccess.ReadWrite))
					{
						var wri = new StreamWriter(str) { AutoFlush = true };

						wri.WriteLine("The following diffs could not be fetched from the server, you can ignore this if you know these paths are folders:\r\n\r\n{0,-15}{1}", "Revision", "Path");
						foreach (var e in missing)
						{
							wri.WriteLine("{0,15}   {1}", e.RevB, e.Path);
						}

						bool first = true;
						foreach (var e in notFound)
						{
							if (!missing.Contains(e))
							{
								if (first)
								{
									wri.WriteLine("The following diffs were downloaded but could not be searched, this list should never contain anything:\r\n\r\n{0,-15}{1}", "Revision", "Path");
									first = false;
								}
								wri.WriteLine("{0,15}   {1}", e.RevB, e.Path);
							}
						}
					}
				}
				catch
				{

				}

				result.SetStillMissing(filename);
				result.SetFailed();
			}

			Progress.ResetExceptLog();

			swTotal.Stop();
			result.TotalTime = swTotal.Elapsed.TotalMilliseconds;

			return result;
		}


		public string ReadSingleDiff(DiffInfo file)
		{
			if (this.Disposed)
			{
				Progress.DebugLog("ReadSingleDiff called on closed SubversionSearcher");
				return "";
			}
			int docId;
			return indexer.GetDiff(file, out docId);
		}


		private IList<FoundFile> GetFoundFiles(
			SearchOptions searchOptions,
			IDictionary<DiffInfo, IList<string>> diffInfoFileRelations,
			IDictionary<string, IList<MovementInfo>> movementInfos,
			ISet<string> filesContainingTextInFileName,
			ConcurrentDictionary<DiffInfo, int> filesContainingTextInContent,
			out int count)
		{

			count = 0;
			IDictionary<string, FoundFile> ffiles = new Dictionary<string, FoundFile>();

			if (searchOptions.SearchInContent)
			{
				// Adding results from diffs
				if (filesContainingTextInContent != null && filesContainingTextInContent.Count() > 0)
				{

					var diSorted = filesContainingTextInContent.OrderByDescending(t => t.Key.RevB);
					foreach (KeyValuePair<DiffInfo, int> dil in diSorted)
					{

						dil.Key.SetRevisionInfo(GetRevision(dil.Key.RevB));
						FoundDiff fd = new FoundDiff(Path.GetFileName(dil.Key.Path), dil.Key.Path, dil.Key, dil.Value);
						count++;

						IList<string> filesReferencingDI;
						if (diffInfoFileRelations.TryGetValue(dil.Key, out filesReferencingDI))
						{

							foreach (string file in filesReferencingDI)
							{

								IList<MovementInfo> mis = null;
								if (!movementInfos.TryGetValue(file, out mis))
								{
									mis = GetMovementInfos(file);
								}

								FoundFile ff;
								if (!ffiles.TryGetValue(file, out ff))
								{
									ffiles[file] = ff = new FoundFile(Path.GetFileName(file), RepositoryUrl, file, mis, false);
								}
								ff.AddRevision(fd);
							}
						}
					}
				}
			}


			if (searchOptions.SearchInRenames)
			{
				// Adding nodes where results have been found in the name history
				foreach (var nodeName in filesContainingTextInFileName)
				{
					FoundFile ff;
					if (ffiles.TryGetValue(nodeName, out ff))
					{
						ff.FoundResultInFileNames = true;
					}
					else
					{
						bool isFolder = false;
						string shownName = ""; // Directories end with a slash
						for (int i = nodeName.Length - 1; i >= 0; i--)
						{
							if (nodeName[i] == '/')
							{

								if (i < nodeName.Length - 1)
								{
									shownName = nodeName.Substring(i + 1);
									break;
								}
								else
								{
									isFolder = true;
								}

							}
						}

						ff = new FoundFile(shownName, RepositoryUrl, nodeName, movementInfos[nodeName], isFolder);
						ff.FoundResultInFileNames = true;
						ffiles.Add(nodeName, ff);
					}
				}
			}

			// order by filename
			return ffiles.OrderBy(t => Path.GetFileName(t.Key)).ToDictionary((keyItem) => keyItem.Key, (valueItem) => valueItem.Value).Values.ToList();
		}

		private IDictionary<string, IList<string>> GetPartialHierarchyFromFolderTree(long revision)
		{
			var result = new Dictionary<string, IList<string>>();

			using (var stream = new FileStream(String.Format(@"C:\Users\iop\Desktop\testHie\revision{0}.txt", revision), FileMode.Open, FileAccess.Read))
			{
				string line;
				stream.Position = 0;
				var reader = new StreamReader(stream, Encoding.GetEncoding(1252));

				result.Add("", new List<string>());

				while ((line = reader.ReadLine()) != null)
				{
					var path = line.Trim('/');
					var split = path.Split('/');
					var parent = String.Join("/", split, 0, split.Length - 1);
					IList<string> li;
					if (!result.TryGetValue(parent, out li))
					{
						Progress.ErrorLog("this should never happen");
					}
					li.Add(path);
					result.Add(path, new List<string>());
				}
			}
			return result;
		}

		/// <summary>
		/// Gets the child nodes of this path at a certain revision. Uses Repository structure, that was built from SVN Log.
		/// </summary>
		/// <param name="path">path of which to get children</param>
		/// <param name="revision">revision at which to get children</param>
		/// <param name="recursive">whether to get children recursivly</param>
		/// <returns>returns null list if the node doesn't exist or the subversion searcher is closed</returns>
		public IList<Tuple<string, SvnNodeKind>> GetChildrenInHierarchy(string path, long revision, bool recursive = false)
		{
			if (this.Disposed)
			{
				Progress.DebugLog("Called GetChindrenInHierarchy on closed SubversionSearcher");
				return null;
			}
			IList<bool> cl;
			return GetChildrenInHierarchy(path, revision, out cl, false, recursive);
		}


		/// <summary>
		/// Gets the child nodes of this path at a certain revision. Uses Repository structure, that was built from SVN Log.
		/// </summary>
		/// <param name="path">path of which to get children</param>
		/// <param name="revision">revision at which to get children</param>
		/// <param name="hasChildList">a list that contains a bool that indicates if the node at the same index in the return list has children itself</param>
		/// <param name="getChildList">whether to fill out the hasChildList</param>
		/// <param name="recursive">whether to get children recursivly</param>
		/// <returns>returns null list if the node doesn't exist or the subversion searcher is closed</returns>
		public IList<Tuple<string, SvnNodeKind>> GetChildrenInHierarchy(string path, long revision, out IList<bool> hasChildList, bool getChildList, bool recursive = false)
		{
			hasChildList = null;

			if (this.Disposed)
			{
				Progress.DebugLog("Called GetChindrenInHierarchy on closed SubversionSearcher");
				return null;
			}

			IList<NodeAtTime> li = null;
			if (nodes == null || path == null || !nodes.TryGetValue(path, out li) || li == null)
			{
				return null;
			}

			IList<Tuple<string, SvnNodeKind>> res = null;
			Queue<NodeAtTime> queue = new Queue<NodeAtTime>();
			for (int i = li.Count - 1; i >= 0; i--)
			{
				if (li[i].AddRevision > revision)
				{
					continue;
				}
				if (li[i].DeleteRevision.HasValue && li[i].DeleteRevision.Value <= revision)
				{
					break;
				}
				queue.Enqueue(li[i]);
				res = new List<Tuple<string, SvnNodeKind>>();
				if (getChildList)
				{
					hasChildList = new List<bool>();
				}
				break;
			}

			while (queue.Count > 0)
			{
				var nat = queue.Dequeue();

				if (nat.Children != null)
				{
					foreach (var child in nat.Children)
					{
						if (child.ExistsAtRevision(revision))
						{

							if (getChildList)
							{
								// finding out whether this child has children so we can make it expandable in the tree view
								bool hasAtLeastOneChild = false;
								if (child.Children != null)
								{
									foreach (var c in child.Children)
									{
										if (c.AddRevision >= revision && (!c.DeleteRevision.HasValue || c.DeleteRevision > revision))
										{
											hasAtLeastOneChild = true;
											break;
										}
									}
								}
								hasChildList.Add(hasAtLeastOneChild);
							}

							res.Add(new Tuple<string, SvnNodeKind>(child.Path, child.NodeKind));
							if (recursive)
							{
								queue.Enqueue(child);
							}
						}
					}
				}
			}

			return res;
		}


		/// <summary>
		/// Checks if given path exists at given revision
		/// </summary>
		/// <param name="path">given path</param>
		/// <param name="revision">given revision</param>
		/// <returns>true if it exists, false if it doesn't exist or the SubversionSearcher is closed.</returns>
		public bool PathExistsAtRevision(string path, long revision)
		{
			return GetNodeAtTime(path, revision) != null;
		}


		/// <summary>
		/// Checks out a file from the subversion server and saves it to the cache path
		/// </summary>
		/// <param name="path">path of the file relative to repository root</param>
		/// <param name="revision">revision</param>
		/// <param name="filePath">Path where the file was saved</param>
		/// <returns>true if the file could be fetched. false if it couldn't be fetched.</returns>
		public bool GetFileAtRevision(string path, long revision, out string filePath)
		{
			string hash = Utils.CalculateMD5Hash(DateTime.Now.ToString() + path + revision);
			string folderPath = Utils.JoinPathsWin(Settings.CachePath, hash + "_r" + revision);

			if (!Directory.Exists(folderPath))
			{
				try
				{
					Directory.CreateDirectory(folderPath);
				}
				catch (Exception ex)
				{
					Progress.ErrorLog("Failed to create Directory {0}:\r\n{1}", folderPath, ex);

				}
			}

			filePath = folderPath + '\\' + Path.GetFileName(path);

			if (PathExistsAtRevision(path, revision))
			{
				try
				{
					SvnUriTarget target = new SvnUriTarget(RepositoryUrl + path, revision);

					SvnExportArgs args = new SvnExportArgs();
					args.Overwrite = true;

					if (GetFreshSvnClient().Export(target, filePath, args))
					{
						return true;
					}
					else
					{
						throw new Exception(String.Format("Error occured when fetching revision {0} :(\n", revision));
					}
				}
				catch (SvnRepositoryIOException ex)
				{
					FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write);
					fs.Close();
					Progress.ErrorLog(ex);
				}

			}
			else
			{
				FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write);
				fs.Close();
			}

			return false;
		}


		public List<string> GetFullNodeList(IList<Tuple<string, bool>> nodesWithRecursiveInfo, long revision)
		{
			List<string> result = new List<string>();

			foreach (Tuple<string, bool> n in nodesWithRecursiveInfo)
			{
				if (n.Item2)
				{

					bool first = true;

					var children = GetChildrenInHierarchy(n.Item1, revision, true);
					if (children != null)
					{
						foreach (var tuple in children)
						{

							var s = tuple.Item1;

							if (!first)
							{
								if (s.Length > 0 && s[s.Length - 1] == '/')
								{
									result.Add(s.Substring(0, s.Length - 1));
								}
								else
								{
									result.Add(s);
								}
							}
							first = false;
						}
					}
					else
					{
						Progress.DebugLog("{0} was not found at revision {1}", n.Item1, revision);
					}

				}
				result.Add(n.Item1);
			}

			return result;
		}

		/// <summary>
		/// Finds the base url of the repository.
		/// </summary>
		/// <param name="anyUrl">Any Url inside the repository.</param>
		/// <returns>Base Url</returns>
		/// <exception cref="System.Exception">If the repository base could not be found.</exception>
		string GetRepositoryBase(string anyUrl)
		{
			if (String.IsNullOrEmpty(anyUrl))
			{
				throw new System.Exception(String.Format("RepositoryUrl empty: \"{0}\"", anyUrl));
			}
			else
			{
				try
				{
					SvnClient client = GetFreshSvnClient();
					Uri repRoot = client.GetRepositoryRoot(new Uri(anyUrl));

					if (repRoot != null)
					{
						return repRoot.ToString().TrimEnd('/') + '/';
					}

				}
				catch (Exception ex)
				{
					Progress.ErrorLog(ex);
				}
			}

			Progress.Log("Could not get Repository Base");
			throw new System.Exception("Could not get Repository Base");
		}


		private bool SearchNameHistory(IList<MovementInfo> movements, SearchOptions options)
		{

			if (movements != null)
			{

				if (options.UseRegex)
				{

					Regex pattern = new Regex(options.Text, options.CaseSensitive ? 0 : RegexOptions.IgnoreCase);

					foreach (MovementInfo mi in movements)
					{
						if (pattern.IsMatch(mi.OldName) || pattern.IsMatch(mi.NewName))
							return true;
					}

				}
				else
				{
					string st = options.CaseSensitive ? options.Text : options.Text.ToUpperInvariant();

					foreach (MovementInfo mi in movements)
					{
						if (mi != null)
						{

							if (options.CaseSensitive)
							{
								if (mi.OldName.Contains(st) || mi.NewName.Contains(st))
								{
									return true;
								}
							}
							else
							{
								if (mi.OldName.ToUpperInvariant().Contains(st) || mi.NewName.ToUpperInvariant().Contains(st))
								{
									return true;
								}
							}

						}
					}
				}
			}

			return false;
		}


		public class AuthenticationInfo
		{
			public bool Successful { get; private set; }
			public Exception ThrownException { get; private set; }
			public String ExceptionMessage { get; private set; }

			private AuthenticationInfo(bool successful, Exception exception)
			{
				Successful = successful;
				ThrownException = exception;
				ExceptionMessage = exception?.Message;
			}
			public static AuthenticationInfo GetSuccessful()
			{
				return new AuthenticationInfo(true, null);
			}
			public static AuthenticationInfo GetFailed(Exception exception)
			{
				return new AuthenticationInfo(false, exception);
			}
		}

		public static AuthenticationInfo CheckCredentials(string anyUrl, string username, string password)
		{

			try
			{
				SvnClient client = new SvnClient();
				client.Authentication.Clear();
				client.Authentication.DefaultCredentials = new System.Net.NetworkCredential(username, password);

				client.Authentication.SslServerTrustHandlers += delegate (object sender, SvnSslServerTrustEventArgs e)
				{
					e.AcceptedFailures = e.Failures;
					e.Save = true;
				};

				SvnInfoEventArgs info;
				client.GetInfo(SvnTarget.FromString(anyUrl), out info);

				return AuthenticationInfo.GetSuccessful();
			}
			catch (Exception ex)
			{
				Progress.ErrorLog(ex);
				return AuthenticationInfo.GetFailed(ex);
			}
		}

		public static AuthenticationInfo HasCredentials(string anyUrl)
		{

			try
			{
				SvnClient client = new SvnClient();
				client.Authentication.SslServerTrustHandlers += delegate (object sender, SvnSslServerTrustEventArgs e)
				{
					e.AcceptedFailures = e.Failures;
					e.Save = true;
				};

				SvnInfoEventArgs info;
				bool r = client.GetInfo(SvnTarget.FromString(anyUrl), out info);

				return AuthenticationInfo.GetSuccessful();
			}
			catch (Exception ex)
			{
				Progress.ErrorLog(ex);
				return AuthenticationInfo.GetFailed(ex);
			}
		}


		void TagFolder(DiffInfo diffInfo)
		{
			Progress.DebugLog("Tagged folder: {0}@{1}", diffInfo.Path, diffInfo.RevB);
			IList<NodeAtTime> li;
			if (nodes.TryGetValue(diffInfo.Path, out li))
			{
				for (int i = li.Count - 1; i >= 0; i--)
				{
					if (li[i].AddRevision > diffInfo.RevB)
					{
						continue;
					}
					li[i].SetIsFolder();
					NodesTaggedAsFolder.Add(new Tuple<string, long>(li[i].Path, li[i].AddRevision));
					savedTaggedFolders = false;
					break;
				}
			}
		}


		class DiffRequest
		{
			public string Path { get; }
			public long RevA { get; }
			public long RevB { get; }
			public ICollection<DiffInfo> ContainedDiffs { get; }
			public bool CopiesAsAdd { get; }
			public bool MightHaveIssue { get; set; }

			public DiffRequest(string path, long revA, long revB, ICollection<DiffInfo> containedDiffs, bool copiesAsAdd = true)
			{
				Path = path; RevA = revA; RevB = revB; ContainedDiffs = containedDiffs; CopiesAsAdd = copiesAsAdd; MightHaveIssue = false;
			}

			public IList<KeyValuePair<string, DiffInfo>> GetRelativePaths()
			{
				IList<KeyValuePair<string, DiffInfo>> result = new List<KeyValuePair<string, DiffInfo>>();

				foreach (DiffInfo d in ContainedDiffs)
				{
					string relativePath = d.Path.Substring(Path.Length, d.Path.Length - Path.Length);
					result.Add(new KeyValuePair<string, DiffInfo>(relativePath, d));
				}
				return result;
			}

			public override string ToString()
			{
				return String.Format("Path: {0} r{1}:{2}, CopiesAsAdds: {3}, diffs: {4}", Path, RevA, RevB, CopiesAsAdd, ContainedDiffs.Count);
			}
		}

		/// <summary>
		///	Checks whether the given SubversionSearcher can be used
		/// </summary>
		/// <param name="subversionSearcher">given SubversionSearcher</param>
		/// <returns>true if it's not null and not closed</returns>
		public static bool IsReady(SubversionSearcher subversionSearcher)
		{
			return subversionSearcher != null && !subversionSearcher.Disposed;
		}


		#region testing methods

		/// <summary>
		/// Generates fake Diff content for testing purposes
		/// </summary>
		/// <param name="diffQueue">input queue</param>
		/// <param name="takeRelevantQueue">output queue</param>
		/// <param name="somethingInTakeRelevantQueue">ManualResetEvent that is set when something was pushed to takeRelevantQueue</param>
		void LoadDiffsFake(
			ConcurrentQueue<DiffRequest> diffQueue,
			ConcurrentQueue<Tuple<Stream, DiffRequest>> takeRelevantQueue,
			ManualResetEvent somethingInTakeRelevantQueue)
		{

			DiffRequest diffRequest;

			while (diffQueue.TryDequeue(out diffRequest))
			{

				IDictionary<string, DiffInfo> contained = new Dictionary<string, DiffInfo>();

				foreach (var c in diffRequest.ContainedDiffs)
				{
					if (c.Path == diffRequest.Path)
					{
						contained.Add(Path.GetFileName(c.Path), c);
					}
					else if (diffRequest.Path == "")
					{
						contained.Add(c.Path, c);
					}
					else
					{
						string path = c.Path.Substring(diffRequest.Path.Length + 1, c.Path.Length - diffRequest.Path.Length - 1);
						contained.Add(path, c);
					}
				}

				Stream stream = GetTempFile();
				StreamWriter writer = new StreamWriter(stream) { AutoFlush = true };

				foreach (var kv in contained)
				{
					writer.WriteLine("Index: {0}\r\nThis is fake content\r\nDiffInfo:\r\n{1}\r\nUsed DiffRequest:\r\n{2}", kv.Key, kv.Value, diffRequest);
				}

				takeRelevantQueue.Enqueue(new Tuple<Stream, DiffRequest>(stream, diffRequest));
				somethingInTakeRelevantQueue.Set();

				if (!InSearch)
				{
					break;
				}
			}
		}

		#endregion
	}
}