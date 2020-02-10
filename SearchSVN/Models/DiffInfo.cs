using System;
using System.IO;

namespace SVNHistorySearcher.Models
{
	[Serializable]
	public class DiffInfo
	{
		string _path;
		long _revA;
		long _revB = -1;
		long _revC = long.MinValue;
		CommitInfo _revBRevision;
		public bool CanBeEmpty = false;
		[NonSerialized] NodeAtTime _nodeAtTime;

		public NodeAtTime NodeAtTime { get { return _nodeAtTime; } }
		public string Path { get { return _path; } }
		public string Filename { get { return System.IO.Path.GetFileName(_path); } }
		public long RevA { get { return _revA; } }
		public long RevB { get { return _revB; } }
		public long RevC { get { return Math.Max(RevB, _revC); } }

		public string Content { get; set; }

		public string Author
		{
			get
			{
				if (_revBRevision != null)
				{
					return _revBRevision.Author;
				}
				else
				{
					return "";
				}
			}
		}
		public string Message
		{
			get
			{
				if (_revBRevision != null)
				{
					return _revBRevision.LogMessage;
				}
				else
				{
					return "";
				}
			}
		}
		public DateTime? Date
		{
			get
			{
				if (_revBRevision != null)
				{
					return _revBRevision.Time;
				}
				else
				{
					return null;
				}
			}
		}

		public void SetNodeAtTime(NodeAtTime node)
		{
			this._nodeAtTime = node;
		}

		// No ErrorHandling
		public DiffInfo(BinaryReader binaryReader)
		{
			_path = binaryReader.ReadString();
			_revB = binaryReader.ReadInt64();
			_revA = -1;
			_revC = -1;
		}

		public DiffInfo(string path, long revA, long revB, long revC)
		{
			_path = path;
			_revA = revA;
			_revB = revB;
			_revC = revC;
		}

		public DiffInfo(string path, long revB) : this(path, -1, revB, -1)
		{
			_path = path;
			_revB = revB;
		}

		public void AddSelfToStream(BinaryWriter writer)
		{
			writer.Write(_path);
			writer.Write(_revB);
		}

		public void SetRevisionInfo(CommitInfo revision)
		{
			this._revBRevision = revision;
		}


		public static bool operator ==(DiffInfo a, DiffInfo b)
		{
			if (ReferenceEquals(a, b) || (!ReferenceEquals(a, null) && !ReferenceEquals(b, null) && a._path == b._path && a.RevB == b.RevB))
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public static bool operator !=(DiffInfo a, DiffInfo b)
		{
			return !(a == b);
		}

		public override int GetHashCode()
		{
			int h = 20;
			return (h * 3) + RevB.GetHashCode() + _path.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			if (obj is DiffInfo && (DiffInfo)obj == this)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public override string ToString()
		{
			return String.Format("{0}@{1} ({2}, {3}, {4})", Path, RevB, RevA, RevB, RevC);
		}
	}
}
