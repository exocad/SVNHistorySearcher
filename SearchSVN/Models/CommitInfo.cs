using System;
using System.IO;
using System.Runtime.Serialization;

namespace SVNHistorySearcher.Models
{

	[Serializable]
	public class CommitInfo : ISerializable
	{
		long _revision;
		string _logMessage;
		string _author;
		DateTime _time;

		public long Revision { get { return _revision; } }
		public string LogMessage { get { return _logMessage; } }
		public string Author { get { return _author; } }
		public DateTime Time { get { return _time; } }

		public CommitInfo(long revision, string commitMessage, string author, DateTime date) {
			_revision = revision;
			_logMessage = commitMessage;
			_author = author;
			_time = date;
		}

		protected CommitInfo(SerializationInfo info, StreamingContext context) {
			_revision = info.GetInt64("rev");
			_logMessage = info.GetString("msg");
			_author = info.GetString("auth");
			_time = info.GetDateTime("time");
		}

		public CommitInfo(BinaryReader binaryReader) {
			_revision = binaryReader.ReadInt64();
			if (binaryReader.ReadBoolean()) {
				_logMessage = binaryReader.ReadString();
			} else { _logMessage = null; }
			if (binaryReader.ReadBoolean()) {
				_author = binaryReader.ReadString();
			} else { _author = null; }

			_time = new DateTime(binaryReader.ReadInt64());
		}

		public virtual void GetObjectData(SerializationInfo info, StreamingContext context) {
			info.AddValue("rev", _revision);
			info.AddValue("msg", _logMessage);
			info.AddValue("auth", _author);
			info.AddValue("time", _time);
		}

		public void AddSelfToStream(BinaryWriter binaryWriter) {
			binaryWriter.Write(_revision);
			binaryWriter.Write(_logMessage != null);
			if (_logMessage != null) {
				binaryWriter.Write(_logMessage);
			}
			binaryWriter.Write(_author != null);
			if (_author != null) {
				binaryWriter.Write(_author);
			}
			binaryWriter.Write(_time.Ticks);
		}
	}
}
