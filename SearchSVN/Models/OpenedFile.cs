using System;

namespace SVNHistorySearcher.Models
{
	public class OpenedFile
	{
		IViewable _viewable;
		int _caretOffset;

		public string FullPath {
			get { return _viewable.FullPath; }
		}
		public long PrevRevision {
			get { return _viewable.PrevRevision; }
		}
		public long Revision {
			get { return _viewable.Revision; }
		}
		public string Author {
			get { return _viewable.Author; }
		}
		public string Message {
			get { return _viewable.Message; }
		}
		public string Date {
			get {
				if (_viewable.Date != null)
					return ((DateTime)_viewable.Date).ToString("dd.MM.yyyy H:mm");
				else
					return "";
			}
		}
		public string FileName {
			get { return _viewable.Name; }
		}
		public string Content {
			get { return _viewable.Content; }
			set { _viewable.Content = value; }
		}
		public int CaretOffset {
			get { return _caretOffset; }
			set {
				_caretOffset = value;
			}
		}


		public OpenedFile(IViewable file, int caretOffset) {
			_viewable = file;
			_caretOffset = caretOffset;
		}
	}
}
