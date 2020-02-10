using SharpSvn;
using System;
using System.Collections.Generic;

namespace SVNHistorySearcher.Models
{

	[Serializable]
	public struct NodeAction
	{
		public long Revision;
		public bool Added;
		public bool Modified;

		public NodeAction(long rev, bool added, bool modified) {
			Revision = rev; Added = added; Modified = modified;
		}
	}

	[Serializable]
	public class AncestorRelation
	{
		public NodeAtTime Ancestor { get; }
		public long CopiedAtRevision { get; }

		public AncestorRelation(NodeAtTime ancestor, long copiedAtRevision) {
			Ancestor = ancestor;
			CopiedAtRevision = copiedAtRevision;
		}

		public override bool Equals(object obj) {
			return ReferenceEquals(obj, Ancestor);
		}

		public override int GetHashCode() {
			return Ancestor.GetHashCode();
		}
	}

	[Serializable]
	public class NodeAtTime
	{
		public string Path { get; }
		public string Name { get { return System.IO.Path.GetFileName(Path); } }
		public IList<NodeAtTime> Children { get; }
		/// <summary>
		/// true means that it's proved to be a folder, false means we don't know
		/// </summary>
		public bool IsFolder { get; private set; } = false;
		/// <summary>
		/// true means that it's proved to be a file, false means we don't know
		/// </summary>
		public bool IsFile { get; private set; } = false;
		public IList<NodeAction> Actions { get; }
		public long AddRevision { get { return Actions[0].Revision; } }
		public long? DeleteRevision { get; private set; }
		public AncestorRelation Ancestor { get; }

		public SvnNodeKind NodeKind {
			get {
				if (IsFolder) {
					return SvnNodeKind.Directory;
				} else if (IsFile) {
					return SvnNodeKind.File;
				} else {
					return SvnNodeKind.Unknown;
				}
			}
		}

		public NodeAtTime(string path, long revision, AncestorRelation ancestor) {
			Path = path;
			Actions = new List<NodeAction> { new NodeAction(revision, true, false) };
			DeleteRevision = null;
			Ancestor = ancestor;
			Children = new List<NodeAtTime>();
		}

		public NodeAtTime(string path, long revision) {
			Path = path;
			Actions = new List<NodeAction> { new NodeAction(revision, true, false) };
			DeleteRevision = null;
			Ancestor = null;
			Children = new List<NodeAtTime>();
		}

		public void AddModification(long revision) {
			if (revision == AddRevision) {
				Actions[0] = new NodeAction(revision, true, true);
			} else {
				Actions.Add(new NodeAction(revision, false, true));
			}
		}

		public void SetDeleted(long revision) {
			DeleteRevision = revision;
			foreach (NodeAtTime n in Children) {
				if (n.DeleteRevision > revision) {
					n.SetDeleted(revision);
				}
			}
		}


		public void AddChild(NodeAtTime child) {
			Children.Add(child);
			SetIsFolder();
		}


		public void SetIsFolder(bool wholeAncestry = true) {
			if (!IsFolder) {
				IsFolder = true;

				if (Ancestor != null && wholeAncestry) {
					Ancestor.Ancestor.SetIsFolder();
				}
			}
		}

		public void SetIsFile(bool wholeAncestry = true) {
			if (!IsFile) {
				IsFile = true;

				if (Ancestor != null && wholeAncestry) {
					Ancestor.Ancestor.SetIsFile();
				}
			}
		}

		/// <summary>
		/// Gets whether the node was deleted before or at that revision
		/// </summary>
		/// <param name="revision"></param>
		/// <returns>True if it was deleted. False if not.</returns>
		public bool DeletedAt(long revision) {
			return DeleteRevision.HasValue && DeleteRevision <= revision;
		}

		/// <summary>
		/// Gets whether the node exists at given revision
		/// </summary>
		/// <param name="revision"></param>
		/// <returns>True if it exists. False if not.</returns>
		public bool ExistsAtRevision(long revision) {
			return revision >= AddRevision && (!DeleteRevision.HasValue || revision < DeleteRevision);
		}
	}
}
