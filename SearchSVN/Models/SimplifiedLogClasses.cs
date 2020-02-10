using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpSvn;
using System.Runtime.Serialization;
using System.IO;

namespace SVNHistorySearcher.Models
{
	[Serializable]
	public class SimplifiedSvnChangeItem : ISerializable
	{
		public long Revision { get; }
		public SvnChangeAction Action { get; }
		public string Path { get; }
		public string CopyFromPath { get; } = null;
		public long CopyFromRevision { get; } = 0;
		public SvnNodeKind NodeKind { get; }

		public SimplifiedSvnChangeItem(long revision, string path, SvnChangeAction action, SvnNodeKind nodeKind) {
			Revision = revision; Path = path; Action = action; NodeKind = nodeKind;
		}

		public SimplifiedSvnChangeItem(long revision, string path, SvnChangeAction action, SvnNodeKind nodeKind, string copyFromPath, long copyFromRevision)
			: this(revision, path, action, nodeKind) {
			CopyFromPath = copyFromPath;
			CopyFromRevision = copyFromRevision;
		}

		protected SimplifiedSvnChangeItem(SerializationInfo info, StreamingContext context) {
			Revision = info.GetInt64("rev");
			CopyFromRevision = info.GetInt64("cfr");
			Path = info.GetString("path");
			CopyFromPath = info.GetString("cfp");
			byte nodki = info.GetByte("nodki");
			byte act = info.GetByte("act");

			switch (nodki) {
				case 1: NodeKind = SvnNodeKind.Directory; break;
				case 2: NodeKind = SvnNodeKind.File; break;
				case 3: NodeKind = SvnNodeKind.SymbolicLink; break;
				case 4: NodeKind = SvnNodeKind.None; break;
				case 5: NodeKind = SvnNodeKind.Unknown; break;
				default: NodeKind = SvnNodeKind.Unknown; break;
			}

			switch (act) {
				case 1: Action = SvnChangeAction.Add; break;
				case 2: Action = SvnChangeAction.Modify; break;
				case 3: Action = SvnChangeAction.Replace; break;
				case 4: Action = SvnChangeAction.Delete; break;
				default: Action = SvnChangeAction.None; break;
			}
		}

		public SimplifiedSvnChangeItem(BinaryReader binaryReader) {
			Revision = binaryReader.ReadInt64();
			if (binaryReader.ReadBoolean()) { Path = binaryReader.ReadString(); } else { Path = null; }
			if (binaryReader.ReadBoolean()) { CopyFromPath = binaryReader.ReadString(); } else { CopyFromPath = null; }
			CopyFromRevision = binaryReader.ReadInt64();
			byte act = binaryReader.ReadByte();
			byte nodki = binaryReader.ReadByte();

			switch (nodki) {
				case 1: NodeKind = SvnNodeKind.Directory; break;
				case 2: NodeKind = SvnNodeKind.File; break;
				case 3: NodeKind = SvnNodeKind.SymbolicLink; break;
				case 4: NodeKind = SvnNodeKind.None; break;
				case 5: NodeKind = SvnNodeKind.Unknown; break;
				default: NodeKind = SvnNodeKind.Unknown; break;
			}

			switch (act) {
				case 1: Action = SvnChangeAction.Add; break;
				case 2: Action = SvnChangeAction.Modify; break;
				case 3: Action = SvnChangeAction.Replace; break;
				case 4: Action = SvnChangeAction.Delete; break;
				default: Action = SvnChangeAction.None; break;
			}
		}

		public virtual void GetObjectData(SerializationInfo info, StreamingContext context) {

			byte nodki = 0;
			switch (NodeKind) {
				case SvnNodeKind.Directory: nodki = 1; break;
				case SvnNodeKind.File: nodki = 2; break;
				case SvnNodeKind.SymbolicLink: nodki = 3; break;
				case SvnNodeKind.None: nodki = 4; break;
				case SvnNodeKind.Unknown: nodki = 5; break;
			}

			byte act = 0;
			switch (Action) {
				case SvnChangeAction.Add: act = 1; break;
				case SvnChangeAction.Modify: act = 2; break;
				case SvnChangeAction.Replace: act = 3; break;
				case SvnChangeAction.Delete: act = 4; break;
			}

			info.AddValue("rev", Revision);
			info.AddValue("path", Path);
			info.AddValue("cfp", CopyFromPath);
			info.AddValue("cfr", CopyFromRevision);
			info.AddValue("act", act);
			info.AddValue("nodki", nodki);
		}

		public void AddSelfToStream(BinaryWriter binaryWriter) {
			byte nodki = 0;
			switch (NodeKind) {
				case SvnNodeKind.Directory: nodki = 1; break;
				case SvnNodeKind.File: nodki = 2; break;
				case SvnNodeKind.SymbolicLink: nodki = 3; break;
				case SvnNodeKind.None: nodki = 4; break;
				case SvnNodeKind.Unknown: nodki = 5; break;
			}

			byte act = 0;
			switch (Action) {
				case SvnChangeAction.Add: act = 1; break;
				case SvnChangeAction.Modify: act = 2; break;
				case SvnChangeAction.Replace: act = 3; break;
				case SvnChangeAction.Delete: act = 4; break;
			}

			binaryWriter.Write(Revision);

			binaryWriter.Write(Path != null);
			if (Path != null) { binaryWriter.Write(Path); }

			binaryWriter.Write(CopyFromPath != null);
			if (CopyFromPath != null) { binaryWriter.Write(CopyFromPath); }

			binaryWriter.Write(CopyFromRevision);
			binaryWriter.Write(act);
			binaryWriter.Write(nodki);
		}
	}
}
