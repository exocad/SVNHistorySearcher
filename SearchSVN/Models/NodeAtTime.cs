using System;
using System.Collections.Generic;
using SharpSvn;

namespace SVNHistorySearcher.Models
{

	[Serializable]
	public struct NodeAction {
		public long Revision;
		public bool Added;
		public bool Modified;

		public NodeAction(long rev, bool added, bool modified) {
			Revision = rev; Added = added; Modified = modified;
		}
	}

	[Serializable]
	public class AncestorRelation {
		NodeAtTime _ancestor;
		long _copiedAtRevision;
		public NodeAtTime Ancestor { get { return _ancestor; } }
		public long CopiedAtRevision { get { return _copiedAtRevision; } }

		public AncestorRelation(NodeAtTime ancestor, long copiedAtRevision) {
			_ancestor = ancestor;
			_copiedAtRevision = copiedAtRevision;
		}

		public override bool Equals(object obj) {
			return ReferenceEquals(obj, _ancestor);
		}

		public override int GetHashCode() {
			return _ancestor.GetHashCode();
		}
	}

	[Serializable]
	public class NodeAtTime {
		string _path;
		IList<NodeAction> _actions;
		AncestorRelation _ancestor;
		long? _deleteRevision;
		IList<NodeAtTime> _children;
		bool _isFolder = false;   // true means that it's proved to be a folder, false means we don't know
		bool _isFile = false;   // true means that it's proved to be a file, false means we don't know

		public string Path { get { return _path; } }
		public string Name { get { return System.IO.Path.GetFileName(_path); } }
		public IList<NodeAtTime> Children { get { return _children; } }
		public bool IsFolder { get { return _isFolder; } }
		public bool IsFile { get { return _isFile; } }
		public IList<NodeAction> Actions { get { return _actions; } }
		public long AddRevision { get { return _actions[0].Revision; } }
		public long? DeleteRevision { get { return _deleteRevision; } }
		public AncestorRelation Ancestor { get { return _ancestor; } }

		public SvnNodeKind NodeKind {
			get {
				if(_isFolder) {
					return SvnNodeKind.Directory;
				} else if (_isFile) {
					return SvnNodeKind.File;
				} else {
					return SvnNodeKind.Unknown;
				}
			}
		}

		public NodeAtTime(string path, long revision, AncestorRelation ancestor) {
			_path = path;
			_actions = new List<NodeAction> { new NodeAction(revision, true, false)};
			_deleteRevision = null;
			_ancestor = ancestor;
			_children = new List<NodeAtTime>();
		}

		public NodeAtTime(string path, long revision) {
			_path = path;
			_actions = new List<NodeAction> { new NodeAction(revision, true, false) };
			_deleteRevision = null;
			_ancestor = null;
			_children = new List<NodeAtTime>();
		}

		public void AddModification(long revision) {
			if (revision == AddRevision) {
				Actions[0] = new NodeAction(revision, true, true);
			} else {
				Actions.Add(new NodeAction(revision, false, true));
			}
		}

		public void SetDeleted(long revision) {
			_deleteRevision = revision;
			foreach (NodeAtTime n in _children) {
				if (n.DeleteRevision > revision) {
					n.SetDeleted(revision);
				}
			}
		}


		public void AddChild(NodeAtTime child) {
			_children.Add(child);
			SetIsFolder();
		}


		public void SetIsFolder(bool wholeAncestry = true) {
			if (!_isFolder) {
				_isFolder = true;

				if (_ancestor != null && wholeAncestry) {
					_ancestor.Ancestor.SetIsFolder();
				}
			}
		}

		public void SetIsFile(bool wholeAncestry = true) {
			if (!_isFile) {
				_isFile = true;

				if (_ancestor != null && wholeAncestry) {
					_ancestor.Ancestor.SetIsFile();
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
