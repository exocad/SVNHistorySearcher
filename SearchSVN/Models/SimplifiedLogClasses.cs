using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpSvn;
using System.Runtime.Serialization;
using System.IO;

namespace SVNHistorySearcher.Models {
	[Serializable]
	public class SimplifiedSvnChangeItem : ISerializable {
		private long _revision;
		private SvnChangeAction _action;
		private string _path;
		private string _copyFromPath = null;
		private long _copyFromRevision = 0;
		private SvnNodeKind _nodeKind;

		public long Revision { get { return _revision; } }
		public SvnChangeAction Action { get { return _action; } }
		public string Path { get { return _path; } }
		public string CopyFromPath { get { return _copyFromPath; } }
		public long CopyFromRevision { get { return _copyFromRevision; } }
		public SvnNodeKind NodeKind { get { return _nodeKind; } }

		public SimplifiedSvnChangeItem(long revision, string path, SvnChangeAction action, SvnNodeKind nodeKind) {
			_revision = revision; _path = path; _action = action; _nodeKind = nodeKind;
		}

		public SimplifiedSvnChangeItem(long revision, string path, SvnChangeAction action, SvnNodeKind nodeKind, string copyFromPath, long copyFromRevision)
			: this(revision, path, action, nodeKind) {
			_copyFromPath = copyFromPath;
			_copyFromRevision = copyFromRevision;
		}

		protected SimplifiedSvnChangeItem(SerializationInfo info, StreamingContext context) {
			_revision = info.GetInt64("rev");
			_copyFromRevision = info.GetInt64("cfr");
			_path = info.GetString("path");
			_copyFromPath = info.GetString("cfp");
			byte nodki = info.GetByte("nodki");
			byte act = info.GetByte("act");

			switch(nodki) {
				case 1: _nodeKind = SvnNodeKind.Directory; break;
				case 2: _nodeKind = SvnNodeKind.File; break;
				case 3: _nodeKind = SvnNodeKind.SymbolicLink; break;
				case 4: _nodeKind = SvnNodeKind.None; break;
				case 5: _nodeKind = SvnNodeKind.Unknown; break;
				default: _nodeKind = SvnNodeKind.Unknown; break;
			}

			switch(act) {
				case 1: _action = SvnChangeAction.Add; break;
				case 2: _action = SvnChangeAction.Modify; break;
				case 3: _action = SvnChangeAction.Replace; break;
				case 4: _action = SvnChangeAction.Delete; break;
				default: _action = SvnChangeAction.None; break;
			}
		}

		public SimplifiedSvnChangeItem(BinaryReader binaryReader) {
			_revision = binaryReader.ReadInt64();
			if (binaryReader.ReadBoolean()) { _path = binaryReader.ReadString(); } else { _path = null; }
			if (binaryReader.ReadBoolean()) { _copyFromPath = binaryReader.ReadString(); } else { _copyFromPath = null; }
			_copyFromRevision = binaryReader.ReadInt64();
			byte act = binaryReader.ReadByte();
			byte nodki = binaryReader.ReadByte();

			switch(nodki) {
				case 1: _nodeKind = SvnNodeKind.Directory; break;
				case 2: _nodeKind = SvnNodeKind.File; break;
				case 3: _nodeKind = SvnNodeKind.SymbolicLink; break;
				case 4: _nodeKind = SvnNodeKind.None; break;
				case 5: _nodeKind = SvnNodeKind.Unknown; break;
				default: _nodeKind = SvnNodeKind.Unknown; break;
			}

			switch(act) {
				case 1: _action = SvnChangeAction.Add; break;
				case 2: _action = SvnChangeAction.Modify; break;
				case 3: _action = SvnChangeAction.Replace; break;
				case 4: _action = SvnChangeAction.Delete; break;
				default: _action = SvnChangeAction.None; break;
			}
		}
  
		public virtual void GetObjectData(SerializationInfo info, StreamingContext context) {

			byte nodki = 0;
			switch(_nodeKind) {
				case SvnNodeKind.Directory: nodki = 1; break;
				case SvnNodeKind.File: nodki = 2; break;
				case SvnNodeKind.SymbolicLink: nodki = 3; break;
				case SvnNodeKind.None: nodki = 4; break;
				case SvnNodeKind.Unknown: nodki = 5; break;
			}

			byte act = 0;
			switch(_action) {
				case SvnChangeAction.Add: act = 1; break;
				case SvnChangeAction.Modify: act = 2; break;
				case SvnChangeAction.Replace: act = 3; break;
				case SvnChangeAction.Delete: act = 4; break;
			}

			info.AddValue("rev", _revision);
			info.AddValue("path", _path);
			info.AddValue("cfp", _copyFromPath);
			info.AddValue("cfr", _copyFromRevision);
			info.AddValue("act", act);
			info.AddValue("nodki", nodki);
		}

		public void AddSelfToStream(BinaryWriter binaryWriter) {
			byte nodki = 0;
			switch(_nodeKind) {
				case SvnNodeKind.Directory: nodki = 1; break;
				case SvnNodeKind.File: nodki = 2; break;
				case SvnNodeKind.SymbolicLink: nodki = 3; break;
				case SvnNodeKind.None: nodki = 4; break;
				case SvnNodeKind.Unknown: nodki = 5; break;
			}

			byte act = 0;
			switch(_action) {
				case SvnChangeAction.Add: act = 1; break;
				case SvnChangeAction.Modify: act = 2; break;
				case SvnChangeAction.Replace: act = 3; break;
				case SvnChangeAction.Delete: act = 4; break;
			}

			binaryWriter.Write(_revision);
			
			binaryWriter.Write(_path != null);
			if(_path != null) { binaryWriter.Write(_path); }

			binaryWriter.Write(_copyFromPath != null);
			if (_copyFromPath != null) { binaryWriter.Write(_copyFromPath); }

			binaryWriter.Write(_copyFromRevision);
			binaryWriter.Write(act);
			binaryWriter.Write(nodki);
		}
	}
}
