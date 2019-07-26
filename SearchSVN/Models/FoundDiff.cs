using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SVNHistorySearcher.Models {
	
	// Diff _file
	public class FoundDiff : IViewable {
		string _fileName;
		string _fullPath;
		string _content;
		int _resultCount;
		DiffInfo _diffInfo;

		public string Name {
			get { return _fileName; }
		}
		public string FullPath {
			get { return _fullPath; }
		}
		public long PrevRevision {
			get { return _diffInfo.RevA; }
		}
		public long Revision {
			get { return _diffInfo.RevB; }
		}
		public string Author {
			get { return _diffInfo.Author; }
		}
		public string Message {
			get { return _diffInfo.Message; }
		}
		public DateTime? Date {
			get { return _diffInfo.Date; }
		}
		public string Content {
			get { return _content; }
			set { _content = value; }
		}
		public int ResultCount {
			get { return _resultCount; }
		}
		public string ResultCountString {
			get {
				return String.Format("{0} result{1}", _resultCount, (_resultCount > 1 ? "s" : ""));
			}
		}
		public DiffInfo DiffInfo {
			get { return _diffInfo; }
		}

		public FoundDiff(string fileName, string fullPath, DiffInfo diffInfo, int resultAmount) {
			_fileName = fileName;
			_fullPath = fullPath;
			_resultCount = resultAmount;
			_diffInfo = diffInfo;
		}
	}
}
