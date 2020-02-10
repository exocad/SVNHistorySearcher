using System.IO;

namespace SVNHistorySearcher.Models
{

	public enum MovementAction
	{
		Delete,
		Add,
		Copy,
		Move
	}

	public class MovementInfo
	{
		public MovementAction Action { get; }

		public string OldName { get { return Path.GetFileName(OldPath); } }
		public string OldPath { get; }

		public string NewName { get { return Path.GetFileName(NewPath); } }
		public string NewPath { get; }
		public long OldRevision { get; }
		public long NewRevision { get; }

		public MovementInfo(MovementAction action, string oldPath, string newPath, long oldRevision, long newRevision)
		{
			Action = action;
			OldPath = oldPath;
			NewPath = newPath;
			OldRevision = oldRevision;
			NewRevision = newRevision;
		}
	}
}
