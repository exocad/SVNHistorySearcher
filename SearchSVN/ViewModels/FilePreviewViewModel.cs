using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.IO;
using SVNHistorySearcher.Models;
using ICSharpCode.AvalonEdit;

namespace SVNHistorySearcher.ViewModels
{
	public class FilePreviewViewModel : ViewModel
	{

		MainViewModel mainViewModel;

		OpenedFile _openedFile;

		public FilePreviewViewModel(MainViewModel mainViewModel) {
			this.mainViewModel = mainViewModel;
		}

		public string FileContent {
			get {
				if (_openedFile != null) {
					return _openedFile.Content;
				} else {
					return "";
				}
			}
		}

		public string FileName {
			get {
				if (_openedFile != null) {
					return _openedFile.FileName;
				} else {
					return "";
				}
			}
		}

		public string FilePath {
			get {
				if (_openedFile != null) {
					return _openedFile.FullPath;
				} else {
					return "";
				}
			}
		}

		public string FileLanguage {
			get {
				return ".diff";
			}
		}

		public string HighlightedString {
			get {
				return mainViewModel.SearchResults.SearchResults != null ? mainViewModel.SearchResults.SearchResults.SearchString : "";
			}
			set {
				RaisePropertyChanged("HighlightedString");
			}
		}

		public bool UseRegex {
			get {
				return mainViewModel.SearchResults.SearchResults != null && mainViewModel.SearchResults.SearchResults.UseRegex;
			}
			set {
				RaisePropertyChanged("UseRegex");
			}
		}

		public string Author {
			get {
				if (_openedFile != null) {
					return _openedFile.Author;
				} else {
					return "";
				}
			}
		}

		public string Date {
			get {
				if (_openedFile != null) {
					return _openedFile.Date;
				} else {
					return "";
				}
			}
		}

		public string Message {
			get {
				if (_openedFile != null) {
					return _openedFile.Message;
				} else {
					return "";
				}
			}
		}

		public int CaretOffset {
			get {
				if (_openedFile != null) {
					return _openedFile.CaretOffset;
				} else {
					return 0;
				}
			}
			set {
				if (_openedFile != null) {
					_openedFile.CaretOffset = value;
				}
			}
		}

		public OpenedFile OpenedFile {
			get { return _openedFile; }
			set {
				_openedFile = value;

				RaisePropertyChanged("FileContent");
				RaisePropertyChanged("FileName");
				RaisePropertyChanged("FilePath");
				RaisePropertyChanged("FileLanguage");
				RaisePropertyChanged("CursorPosition");
				RaisePropertyChanged("HighlightedString");
				RaisePropertyChanged("UseRegex");
				RaisePropertyChanged("Author");
				RaisePropertyChanged("Date");
				RaisePropertyChanged("Message");
				RaisePropertyChanged("CaretOffset");
			}
		}

		public void Reset() {
			OpenedFile = null;
		}
	}
}
