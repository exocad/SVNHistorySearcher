using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SVNHistorySearcher.Models {

	public enum MovementAction {
		Delete,
		Add,
		Copy,
		Move
	}

	public class MovementInfo {
		private MovementAction _action;
		public MovementAction Action { get { return _action; } }
		private string _oldPath;
		public string OldName { get { return Path.GetFileName(_oldPath); } }
		public string OldPath { get { return _oldPath; } }
		private string _newPath;
		public string NewName { get { return Path.GetFileName(_newPath); } }
		public string NewPath { get { return _newPath; } }
		private long _oldRevision;
		public long OldRevision { get { return _oldRevision; } }
		private long _newRevision;
		public long NewRevision { get { return _newRevision; } }

		public MovementInfo(MovementAction action, string oldPath, string newPath, long oldRevision, long newRevision) {
			_action = action;
			_oldPath = oldPath;
			_newPath = newPath;
			_oldRevision = oldRevision;
			_newRevision = newRevision;
		}
	}
}
