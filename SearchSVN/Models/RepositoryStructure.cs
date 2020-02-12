using SharpSvn;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace SVNHistorySearcher.Models
{
	public partial class SubversionSearcher
	{
		IDictionary<string, IList<NodeAtTime>> nodes;
		IDictionary<NodeAtTime, ISet<NodeAtTime>> equalAdds; // this stores which nodes have the same content when created
		Table table;

		public IDictionary<long, CommitInfo> Revisions { get; private set; }

		private bool savedTaggedFolders = true;
		ISet<Tuple<string, long>> NodesTaggedAsFolder = new HashSet<Tuple<string, long>>();
		// these variables are kept to avoid having to reload the repositoryLog file when saving the changed "NodesTaggedAsFolder" list. It's a dirty fix
		IList<SimplifiedSvnChangeItem> SimplifiedChangeItems = null;
		IList<CommitInfo> RepositoryRevisions = null;
		// --

		private void BuildRepositoryStructure(IList<CommitInfo> revs, IList<SimplifiedSvnChangeItem> changeItems)
		{
			Revisions = new Dictionary<long, CommitInfo>();
			nodes = new Dictionary<string, IList<NodeAtTime>>();
			equalAdds = new Dictionary<NodeAtTime, ISet<NodeAtTime>>();
			table = new Table(this);

			nodes.Add("", new List<NodeAtTime> { new NodeAtTime("", 0) });

			foreach (var e in revs)
			{
				Revisions.Add(e.Revision, e);
			}

			if (revs.Count > 0) { HeadRevision = revs[revs.Count - 1].Revision; }

			Stopwatch sw = Stopwatch.StartNew();

			long currentRevsion = 0;
			ISet<string> filesCopiedThisRevision = new HashSet<string>();

			foreach (var changeItem in changeItems)
			{

				if (changeItem.Revision != currentRevsion)
				{
					currentRevsion = changeItem.Revision;
					if (changeItem.Revision == revs.Count - 1 || changeItem.Revision % 17 == 0) { Progress.Log("Building repository structure ({0} of {1})", changeItem.Revision, revs.Count - 1); }
					filesCopiedThisRevision = new HashSet<string>();
				}

				string nodePath = changeItem.Path.Substring(1);

				if (changeItem.Action == SvnChangeAction.Modify)
				{
					AddModification(nodePath, currentRevsion, filesCopiedThisRevision.Contains(nodePath));
				}
				else if (changeItem.Action == SvnChangeAction.Add)
				{
					AddAddition(nodePath, changeItem, currentRevsion, ref filesCopiedThisRevision);
					// add to same files
				}
				else if (changeItem.Action == SvnChangeAction.Delete)
				{
					AddDeletion(nodePath, changeItem, currentRevsion);
				}
				else if (changeItem.Action == SvnChangeAction.Replace)
				{
					// investigate replace without copying
					AddDeletion(nodePath, changeItem, currentRevsion);
					AddAddition(nodePath, changeItem, currentRevsion, ref filesCopiedThisRevision);
					// add to same files
				}
				else
				{
					Progress.DebugLog("{0} occured at {1}@{2}", changeItem.Action, nodePath, currentRevsion);
				}
			}


			{
				IList<string> listsToRemove = new List<string>();
				// remove nodes with deleteRevision == addRevision, remove nodesPaths with no nodes, add to table
				foreach (var kv in nodes)
				{

					IList<NodeAtTime> natsToRemove = null;

					foreach (var nat in kv.Value)
					{

						if (nat.DeleteRevision.HasValue && nat.DeleteRevision == nat.AddRevision)
						{
							// happens when replaces happen
							if (natsToRemove == null)
							{
								natsToRemove = new List<NodeAtTime>();
							}
							natsToRemove.Add(nat);
							continue;
						}

						if (nat.IsFolder)
						{
							continue;
						}
						else if (NodesTaggedAsFolder.Count > 0 && NodesTaggedAsFolder.Contains(new Tuple<string, long>(nat.Path, nat.AddRevision)))
						{
							nat.SetIsFolder();
						}
						else
						{
							bool isBinary = FiletypeBlacklist.Contains(Path.GetExtension(nat.Path));

							for (int i = nat.Actions.Count - 1; i > 0; i--)
							{
								table.AddToDict(nat.Actions[i].Revision, kv.Key, isBinary);
							}

							if (nat.Actions[0].Modified)
							{
								table.AddToDict(nat.Actions[0].Revision, kv.Key, isBinary);
							}
							else
							{
								table.AddToDict(nat.Actions[0].Revision, kv.Key, isBinary);
							}
							if (nat.DeleteRevision.HasValue)
							{
								table.AddToDict(nat.DeleteRevision.Value, kv.Key, isBinary);
							}
						}
					}

					if (natsToRemove != null)
					{
						foreach (var n in natsToRemove)
						{
							kv.Value.Remove(n);
						}
					}

					if (kv.Value.Count == 0)
					{
						listsToRemove.Add(kv.Key);
					}
				}

				foreach (var v in listsToRemove)
				{
					nodes.Remove(v);
				}
			}

			{
				IList<NodeAtTime> toRemove = new List<NodeAtTime>();
				// clear all the equalsAdds entries who's Set contain only one entry
				foreach (var kv in equalAdds)
				{
					if (kv.Value.Count <= 1)
					{
						toRemove.Add(kv.Key);
					}
					else
					{
						foreach (var s in kv.Value)
						{
							if (s.IsFolder)
							{
								// if one is a folder, all of them are
								toRemove.Add(kv.Key);
								break;
							}
						}
					}

				}
				foreach (var v in toRemove)
				{
					equalAdds.Remove(v);
				}
			}

			sw.Stop();
			Progress.DebugLog("repository structure building time: {0}ms", sw.Elapsed.TotalMilliseconds);
		}


		private void AddModification(string nodePath, long revision, bool removeFromSameAdds = false)
		{
			NodeAtTime node = GetNodeAtTime(nodePath, revision);

			if (node != null)
			{
				if (removeFromSameAdds)
				{
					ISet<NodeAtTime> set;
					if (equalAdds.TryGetValue(node, out set))
					{
						set.Remove(node);
						equalAdds.Remove(node);
					}
				}

				node.AddModification(revision);

			}
			else
			{
				Progress.DebugLog("Did not find {0}@{1} to add modification to it", nodePath, revision);
			}
		}


		private void AddDeletion(string nodePath, SimplifiedSvnChangeItem changeItem, long revision)
		{
			IList<NodeAtTime> ancli;
			if (!nodes.TryGetValue(nodePath, out ancli) || ancli.Count == 0)
			{
				Progress.DebugLog("Node {0} could not be found", nodePath);
			}
			else
			{
				ancli[ancli.Count - 1].SetDeleted(revision);
			}
		}

		private void AddAddition(string nodePath, SimplifiedSvnChangeItem changeItem, long revision, ref ISet<string> filesCopiedThisRevision)
		{
			NodeAtTime parent = null;
			// get parent
			int t = 0;
			for (int k = nodePath.Length - 1; k >= 0; k--)
			{
				if (nodePath[k] == '/')
				{
					t = k;
					break;
				}
			}
			string parentPath = nodePath.Substring(0, t);
			IList<NodeAtTime> parli;
			if (nodes.TryGetValue(parentPath, out parli))
			{
				if (parli.Count > 0)
				{
					parent = parli[parli.Count - 1];
				}
			}
			else if (!String.IsNullOrEmpty(parentPath))
			{
				Progress.DebugLog("Could not find Parent \"{0}\"", parentPath);
			}
			//-------

			if (changeItem.CopyFromPath != null)
			{
				string cpFromPath = changeItem.CopyFromPath.Length > 1 ? changeItem.CopyFromPath.Substring(1) : "";

				var previousNode = GetNodeAtTime(cpFromPath, changeItem.CopyFromRevision);
				if (previousNode != null)
				{
					AddCopy(nodePath, previousNode, parent, revision, changeItem.CopyFromRevision, ref filesCopiedThisRevision);
				}
				else
				{
					Progress.DebugLog("Ancestor of {0}@{1} not found: {2}@{3}", nodePath, revision, cpFromPath, changeItem.CopyFromRevision);
					return;
				}

			}
			else
			{
				NodeAtTime newlyAdded;

				IList<NodeAtTime> nodesWithSamePath;
				if (!nodes.TryGetValue(nodePath, out nodesWithSamePath))
				{
					nodes[nodePath] = nodesWithSamePath = new List<NodeAtTime>();
				}

				newlyAdded = new NodeAtTime(nodePath, revision);

				if (parent != null)
				{
					parent.AddChild(newlyAdded);
				}

				if (changeItem.NodeKind == SvnNodeKind.Directory)
				{
					newlyAdded.SetIsFolder();
				}
				else if (changeItem.NodeKind == SvnNodeKind.File)
				{
					newlyAdded.SetIsFile();
				}

				nodesWithSamePath.Add(newlyAdded);
			}
		}


		// creates a new copy of NodeAtTime in this tree an links them  // has to be directory
		private NodeAtTime AddCopy(
			string path, NodeAtTime previousNode, NodeAtTime parent,
			long currentRevision, long previousRevision,
			ref ISet<string> filesCopiedThisRevision)
		{

			NodeAtTime currentNode;

			currentNode = new NodeAtTime(path, currentRevision, new AncestorRelation(previousNode, previousRevision));

			if (previousNode.IsFolder)
			{
				currentNode.SetIsFolder(false);

				foreach (var c in previousNode.Children)
				{
					if (c.AddRevision <= previousRevision && (!c.DeleteRevision.HasValue || previousRevision < c.DeleteRevision))
					{

						string relpath = c.Path.Substring(previousNode.Path.Length);
						string newPath = path + relpath;

						AddCopy(newPath, c, currentNode, currentRevision, previousRevision, ref filesCopiedThisRevision);
					}
				}

			}
			else
			{

				if (previousNode.IsFile)
				{
					currentNode.SetIsFile(false);
				}

				// gets put into this list so it can be deleted from the equalAdds list if it's modified in the same revision it's copied
				filesCopiedThisRevision.Add(currentNode.Path);

				if (previousNode.Actions.Count == 1 || previousNode.Actions[1].Revision > previousRevision)
				{
					// if our first content is the same as our parents

					ISet<NodeAtTime> eqli;
					if (!equalAdds.TryGetValue(previousNode, out eqli))
					{
						equalAdds[previousNode] = eqli = new HashSet<NodeAtTime>();
						eqli.Add(previousNode);
					}
					equalAdds[currentNode] = eqli;
					eqli.Add(currentNode);
				}
			}

			if (parent != null)
			{
				parent.AddChild(currentNode);
			}

			IList<NodeAtTime> nodesWithSamePath;
			if (!nodes.TryGetValue(currentNode.Path, out nodesWithSamePath))
			{
				nodes[currentNode.Path] = nodesWithSamePath = new List<NodeAtTime>();
			}
			nodesWithSamePath.Add(currentNode);

			return currentNode;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="path"></param>
		/// <param name="revision"></param>
		/// <returns>null if node does not exist at given revision</returns>
		/// <exception cref="System.ArgumentNullException">If path is null</exception>
		private NodeAtTime GetNodeAtTime(string path, long revision)
		{
			IList<NodeAtTime> ancli;
			if (nodes.TryGetValue(path, out ancli))
			{

				for (int k = ancli.Count - 1; k >= 0; k--)
				{
					if (ancli[k].AddRevision <= revision)
					{

						if (!ancli[k].DeletedAt(revision))
						{
							return ancli[k];
						}
						else
						{
							Progress.DebugLog("NodeAtTime {0}@{1} cannot be found because it's deleted at {2}", path, revision, ancli[k].DeleteRevision);
						}
					}
				}

				if (ancli.Count == 0)
				{
					Progress.DebugLog("There are no entries in the NodeAtTime List at {0}", path);
				}
				else
				{
					Progress.DebugLog("NodeAtTime {0}@{1} cannot be found", path, revision);
				}

			}
			else
			{
				Progress.DebugLog("There is no entry for {0} in RepositoryStructure.nodes", path);
			}

			return null;
		}


		private int GetNodeChecksum(NodeAtTime node, long revision)
		{
			int result = 0;

			foreach (NodeAtTime n in node.Children)
			{
				if (n.ExistsAtRevision(revision))
				{
					result += GetNodeChecksum(n, revision);
				}
			}

			return result;
		}


		void AddDiffsForNode(NodeAtTime node, long startRevision, long endRevision, ref IList<DiffInfo> diffs, ICollection<long> ignoreRevsions)
		{
			if (node.IsFolder)
			{
				return;
			}

			long prevRev = 0;
			long nextRev;


			// finding delete revision of previous node that existed here
			IList<NodeAtTime> li;
			if (nodes.TryGetValue(node.Path, out li))
			{
				for (int j = li.Count - 1; j >= 0; j--)
				{
					if (li[j] != node)
					{
						continue;
					}
					if (j-- > 0)
					{
						prevRev = li[j].DeleteRevision == null ? long.MaxValue : li[j].DeleteRevision.Value;
					}
					break;
				}
			}

			for (int i = 0; i < node.Actions.Count; i++)
			{
				var na = node.Actions[i];

				// revision span
				if (na.Revision < startRevision)
				{
					continue;
				}
				else if (na.Revision > endRevision)
				{
					break;
				}


				// ignoring delete revision because we don't diff deletes
				if (ignoreRevsions.Contains(na.Revision) || node.DeleteRevision.HasValue && na.Revision == node.DeleteRevision)
				{
					continue;
				}

				// finding maximum upper revision
				if (i < node.Actions.Count - 1)
				{
					nextRev = node.Actions[i + 1].Revision - 1;
				}
				else
				{
					nextRev = node.DeleteRevision.HasValue ? node.DeleteRevision.Value - 1 : HeadRevision;
				}

				DiffInfo newDI = null;

				if (prevRev != na.Revision)
				{
					diffs.Add(newDI = new DiffInfo(node.Path, prevRev, na.Revision, nextRev));
				}

				if (newDI != null)
				{
					newDI.SetNodeAtTime(node);
				}

				prevRev = na.Revision;
			}
		}


		IList<DiffInfo> GetFileHistory(string file, long startRevision, long endRevision, ICollection<long> ignoreRevisions, bool stopOnCopy)
		{
			NodeAtTime nod;
			IList<DiffInfo> result = new List<DiffInfo>();

			if ((nod = GetNodeAtTime(file, endRevision)) != null)
			{
				GetFileHistory(nod, startRevision, endRevision, ref result, ignoreRevisions, stopOnCopy);
			}

			return result;
		}


		// used for search by filename
		IList<DiffInfo> GetFileHistory(NodeAtTime nod, long startRevision, long endRevision, ICollection<long> ignoreRevisions, bool stopOnCopy)
		{
			IList<DiffInfo> result = new List<DiffInfo>();

			if (nod != null)
			{
				GetFileHistory(nod, startRevision, endRevision, ref result, ignoreRevisions, stopOnCopy);
			}

			return result;
		}


		void GetFileHistory(NodeAtTime node, long startRevision, long endRevision, ref IList<DiffInfo> history, ICollection<long> ignoreRevisions, bool stopOnCopy)
		{
			if (stopOnCopy || node.Ancestor == null)
			{
				// adding creation as diff
				AddDiffsForNode(node, startRevision, endRevision, ref history, ignoreRevisions);
			}
			else
			{
				// follow node to creation
				AddDiffsForNode(node, startRevision, endRevision, ref history, ignoreRevisions);
				GetFileHistory(node.Ancestor.Ancestor, startRevision, node.Ancestor.CopiedAtRevision, ref history, ignoreRevisions, false);
			}
		}


		public IDictionary<string, IList<MovementInfo>> GetMovementInfos(SearchOptions so)
		{
			if (this.Disposed)
			{
				Progress.DebugLog("GetMovementInfos called on closed SubversionSearcher");
				return null;
			}

			IDictionary<string, IList<MovementInfo>> result = new Dictionary<string, IList<MovementInfo>>();

			foreach (string fname in so.Files)
			{
				result[fname] = GetMovementInfos(fname);
			}

			string toSearch = so.CaseSensitive ? so.FilenameSubstring : so.FilenameSubstring.ToLower();

			if (toSearch != "")
			{
				foreach (var kv in nodes)
				{
					if (result.ContainsKey(kv.Key))
					{
						continue;
					}
					if (so.HeadNodePath != "" && !kv.Key.StartsWith(so.HeadNodePath + '/'))
					{
						continue;
					}

					string fn = so.CaseSensitive ? kv.Key : kv.Key.ToLower();
					if (fn.Contains(toSearch) || toSearch == "*")
					{
						result[kv.Key] = GetMovementInfos(kv.Key);
					}
				}
			}

			return result;
		}


		// concatenates MovementInfos from all files that were at this path
		public IList<MovementInfo> GetMovementInfos(string path)
		{
			if (this.Disposed)
			{
				Progress.DebugLog("GetMovementInfos called on closed SubversionSearcher");
				return null;
			}

			IList<NodeAtTime> li;
			if (nodes.TryGetValue(path, out li))
			{
				IList<MovementInfo> result = new List<MovementInfo>();

				foreach (NodeAtTime n in li)
				{
					foreach (MovementInfo m in GetMovementInfos(n))
					{
						result.Add(m);
					}
				}
				return result;
			}
			return null;
		}


		public IList<MovementInfo> GetMovementInfos(NodeAtTime node)
		{
			if (this.Disposed)
			{
				Progress.DebugLog("GetMovementInfos called on closed SubversionSearcher");
				return null;
			}

			if (node != null)
			{
				IList<MovementInfo> result = new List<MovementInfo>();
				GetMovementInfos(node, HeadRevision, ref result);
				return result;
			}
			else
			{
				return null;
			}
		}

		void GetMovementInfos(NodeAtTime node, long toRevision, ref IList<MovementInfo> list, NodeAtTime initialNode = null)
		{
			// TODO document what initial node means
			if (initialNode == null)
			{
				initialNode = node;
			}
			else if (initialNode == node)
			{
				return;
			}
			if (node.DeleteRevision.HasValue && node.DeleteRevision.Value <= toRevision)
			{
				list.Add(new MovementInfo(MovementAction.Delete, node.Path, node.Path, node.DeleteRevision.Value, node.DeleteRevision.Value));
			}

			if (node.Ancestor == null)
			{
				list.Add(new MovementInfo(MovementAction.Add, node.Path, node.Path, node.AddRevision, node.AddRevision));
			}
			else
			{
				if (node.Ancestor.Ancestor.DeleteRevision.HasValue && node.Ancestor.Ancestor.DeleteRevision.Value == node.AddRevision)
				{
					list.Add(new MovementInfo(MovementAction.Move, node.Ancestor.Ancestor.Path, node.Path, node.Ancestor.CopiedAtRevision, node.AddRevision));
				}
				else
				{
					list.Add(new MovementInfo(MovementAction.Copy, node.Ancestor.Ancestor.Path, node.Path, node.Ancestor.CopiedAtRevision, node.AddRevision));
				}

				GetMovementInfos(node.Ancestor.Ancestor, node.Ancestor.CopiedAtRevision, ref list, initialNode);
			}
		}


		public DiffInfo GetCreation(NodeAtTime nodeAtTime)
		{
			if (this.Disposed)
			{
				Progress.DebugLog("GetCreation called on closed SubversionSearcher");
				return null;
			}

			if (nodeAtTime.IsFolder)
			{
				return null;
			}

			long revA = 0;
			long revC = nodeAtTime.DeleteRevision.HasValue ? nodeAtTime.DeleteRevision.Value - 1 : long.MaxValue;

			if (nodeAtTime.Actions.Count > 1)
			{
				revC = nodeAtTime.Actions[1].Revision - 1;
			}

			IList<NodeAtTime> li;
			if (nodes.TryGetValue(nodeAtTime.Path, out li))
			{
				for (int i = li.Count - 1; i >= 0; i--)
				{
					if (li[i] != nodeAtTime)
					{
						continue;
					}

					if (i > 0)
					{
						i--;
						revA = li[i].DeleteRevision.Value;
					}
					break;
				}
			}
			var newDI = new DiffInfo(nodeAtTime.Path, revA, nodeAtTime.AddRevision, revC);
			newDI.SetNodeAtTime(nodeAtTime);
			return newDI;
		}


		/// <summary>
		/// finds out the path and revision of all diffs needed for this search
		/// </summary>
		/// <param name="filesOfInterest"></param>
		/// <param name="searchOptions"></param>
		/// <param name="diffInfoFileRelations"></param>
		/// <returns></returns>
		public IList<DiffInfo> GetDiffInfos(ICollection<string> filesOfInterest, SearchOptions searchOptions, out IDictionary<DiffInfo, IList<string>> diffInfoFileRelations)
		{
			diffInfoFileRelations = new Dictionary<DiffInfo, IList<string>>();

			if (this.Disposed)
			{
				Progress.DebugLog("GetDiffInfos called on closed SubversionSearcher");
				return null;
			}

			long startRevisionNumber = 0;
			long endRevisionNumber = long.MaxValue;
			long treeRevisionNumber = -1;

			if (searchOptions.SearchFromRevision.Revision != -1)
			{
				// revision number was entered
				startRevisionNumber = searchOptions.SearchFromRevision.Revision;
			}
			else
			{
				for (int i = 1; i < Revisions.Count; i++)
				{
					if (Revisions[i].Time >= searchOptions.SearchFromRevision.Time)
					{
						startRevisionNumber = Revisions[i - 1].Revision;
						break;
					}
				}
			}

			if (searchOptions.SearchToRevision.Revision != -1)
			{
				// revision number was entered
				endRevisionNumber = searchOptions.SearchToRevision.Revision;
			}
			else
			{
				for (int i = Revisions.Count - 2; i >= 0; i--)
				{
					if (Revisions[i].Time <= searchOptions.SearchToRevision.Time)
					{
						endRevisionNumber = Revisions[i + 1].Revision;
						break;
					}
				}
			}

			if (searchOptions.TreeRevision.Revision != -1)
			{
				treeRevisionNumber = searchOptions.TreeRevision.Revision;
			}
			else
			{
				treeRevisionNumber = endRevisionNumber;
			}


			ICollection<long> ignoreRevisions = new HashSet<long>();
			if (searchOptions.Authors.Count > 0)
			{
				foreach (CommitInfo r in Revisions.Values)
				{
					if (r.Author != null && !(searchOptions.Authors.Contains(r.Author.ToLower()) ^ searchOptions.ExcludeAuthors))
					{
						ignoreRevisions.Add(r.Revision);
					}
				}
			}


			// adding the files that were selected in the checkbox tree
			foreach (string fname in filesOfInterest)
			{
				foreach (DiffInfo di in GetFileHistory(fname, startRevisionNumber, endRevisionNumber, ignoreRevisions, searchOptions.StopOnCopy))
				{

					IList<string> li;
					if (diffInfoFileRelations.TryGetValue(di, out li) == false)
					{
						diffInfoFileRelations[di] = li = new List<string>();
					}
					li.Add(fname);
				}
			}


			// add files that contain substring in name
			if (!String.IsNullOrEmpty(searchOptions.FilenameSubstring))
			{

				foreach (KeyValuePair<string, IList<NodeAtTime>> kv in nodes)
				{

					if (searchOptions.HeadNodePath != "" && !kv.Key.StartsWith(searchOptions.HeadNodePath + '/'))
					{
						continue;
					}

					var stringInFname = searchOptions.FilenameSubstring.ToUpperInvariant();

					if ((searchOptions.FilenameSubstring == "*" && !FiletypeBlacklist.Contains(Path.GetExtension(kv.Key).ToLower())) || kv.Key.ToUpperInvariant().Contains(stringInFname))
					{
						foreach (NodeAtTime n in kv.Value)
						{
							foreach (DiffInfo di in GetFileHistory(n, startRevisionNumber, endRevisionNumber, ignoreRevisions, true))
							{
								IList<string> li;
								if (diffInfoFileRelations.TryGetValue(di, out li) == false)
								{
									diffInfoFileRelations[di] = li = new List<string>();
								}
								if (!li.Contains(kv.Key))
								{
									li.Add(kv.Key);
								}
							}
						}
					}
				}

			}

			Utils.Vardump<DiffInfo>("relevantDiffs.txt", diffInfoFileRelations.Keys, (di) =>
			{
				string result = String.Format("r{0,5} {1}", di.RevB, di.Path);
				return result;
			});

			return diffInfoFileRelations.Keys.ToList();
		}


		/// <summary>
		/// Gets the commit Info (Revision, author, description, date) of a certain revision number
		/// </summary>
		/// <param name="revision">revision to get</param>
		/// <returns>the commit info or null if repository revision doesn't exist</returns>
		public CommitInfo GetRevision(long revision)
		{
			if (this.Disposed)
			{
				Progress.DebugLog("GetRevision called on closed SubversionSearcher");
				return null;
			}

			CommitInfo r;
			if (Revisions.TryGetValue(revision, out r))
			{
				return r;
			}
			else
			{
				return null;
				//return new CommitInfo(revision, "", "", DateTime.Now);
			}
		}

		public CommitInfo GetRevision(DateTime date)
		{
			if (this.Disposed)
			{
				Progress.DebugLog("GetRevision called on closed SubversionSearcher");
				return null;
			}

			for (long i = Revisions.Count - 1; i >= 0; i--)
			{
				if (Revisions[i].Time <= date)
				{
					return Revisions[i];
				}
			}

			for (long i = 0; i < Revisions.Count; i++)
			{
				if (Revisions[i].Time >= date)
				{
					return Revisions[i];
				}
			}

			return null;
		}


		private static string GetLogCacheFilename(string repoUrl)
		{
			return Path.Combine(Settings.GetRepositoryFolder(repoUrl), "svnlog");
		}


		private class NodeDiffAmount
		{
			public int TextFileAmount = 0;
			public int BinaryFileAmount = 0;
			public NodeDiffAmount Parent;
			public ICollection<NodeDiffAmount> Children = new List<NodeDiffAmount>();

			public NodeDiffAmount(NodeDiffAmount parent)
			{
				Parent = parent;
			}

			public void AddToTextFileCounter()
			{
				TextFileAmount++;
				if (Parent != null)
				{
					Parent.AddToTextFileCounter();
				}
			}
			public void AddToBinaryFileCounter()
			{
				BinaryFileAmount++;
				if (Parent != null)
				{
					Parent.AddToBinaryFileCounter();
				}
			}
		}


		/// <summary>
		/// Used for creating diff queue. Contains information about the amount of files that will be in each received when diffing each node at each revision
		/// </summary>
		private class Table
		{
			private Dictionary<Tuple<long, string>, NodeDiffAmount> dict = new Dictionary<Tuple<long, string>, NodeDiffAmount>();
			private SubversionSearcher subversionSearcher;

			public Table(SubversionSearcher searcher)
			{
				subversionSearcher = searcher;
			}

			public void AddToDict(long revision, string path, bool binary)
			{

				NodeDiffAmount nda = new NodeDiffAmount(null);
				dict[new Tuple<long, string>(revision, path)] = nda;

				NodeDiffAmount previous = nda;
				string next = path;
				while (next != "")
				{
					string parentPath = next = Utils.GetParentPath(next);

					NodeDiffAmount parent;
					if (dict.TryGetValue(new Tuple<long, string>(revision, parentPath), out parent))
					{

						previous.Parent = parent;
						parent.Children.Add(previous);
						break;

					}
					else
					{
						dict[new Tuple<long, string>(revision, parentPath)] = parent = new NodeDiffAmount(null);

						previous.Parent = parent;
						parent.Children.Add(previous);
						previous = parent;
					}
				}

				if (binary)
				{
					nda.AddToBinaryFileCounter();
				}
				else
				{
					nda.AddToTextFileCounter();
				}
			}


			public NodeDiffAmount GetNodeDiffAmount(long revision, string path)
			{
				NodeDiffAmount nda;
				if (dict.TryGetValue(new Tuple<long, string>(revision, path), out nda))
				{
					return nda;
				}
				else
				{
					return null;
				}
			}
		}
	}
}
