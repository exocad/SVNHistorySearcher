using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVNHistorySearcher.Models {

	// A file
	public class FoundFile : IViewable{
		string _name;
		string _fullPath;
		IList<FoundDiff> _revisions;
		IList<MovementInfo> movementInfos;
		bool isFolder = false;
		string _cachedContent = null;
		bool _foundResultInFileNames = false;

		public bool IsExpanded { get; set; }
		public long PrevRevision { get { return 0; } }
		public long Revision { get { return 0; } }
		public string Author { get { return ""; } }
		public string Message { get { return ""; } }
		public DateTime? Date { get { return DateTime.Now; } }
		public string Content { 
			get {
				if (_cachedContent != null) {
					return _cachedContent;
				}

				string nodeType = isFolder ? "Folder" : "File";
				string result = nodeType + " History:\r\n";

				if (movementInfos != null) {
					foreach (MovementInfo mi in movementInfos) {
						string oldName = mi.OldName;
						string newName = mi.NewName;
						string oldPath = mi.OldPath.Substring(0, mi.OldPath.Length - oldName.Length);
						string newPath = mi.NewPath.Substring(0, mi.NewPath.Length - newName.Length);
						string newFullPath = newPath + newName;
						string oldFullPath = oldPath + oldName;

						switch (mi.Action) {
							case MovementAction.Add:
								result += String.Format("Rev. {0, 5} Added {2}  \"{1}\"\r\n\r\n", mi.NewRevision, newFullPath, nodeType);
								break;
							case MovementAction.Copy:
								result += String.Format("Rev. {0, 5} Copied \"{1}\" from \"{2}\" at revision {3}\r\n\r\n", mi.NewRevision, newFullPath, oldFullPath, mi.OldRevision);
								break;
							case MovementAction.Delete:
								result += String.Format("Rev. {0, 5} Deleted \"{1}\" ( This {2} might have been moved/renamed )\r\n", mi.NewRevision, newFullPath, nodeType);
								break;
							case MovementAction.Move:
								if (oldPath != newPath) {
									if (oldName != newName) {
										// renamed and moved
										result += String.Format("Rev. {0, 5} Moved from  \"{1}\" to \"{2}\"  and renamed to {3}\r\n", mi.NewRevision, oldFullPath, newFullPath, newName);
									} else {
										// only moved
										result += String.Format("Rev. {0, 5} Moved from  \"{1}\" to \"{2}\"\r\n", mi.NewRevision, oldFullPath, newFullPath);
									}
								} else {
									if (oldName != newName) {
										// only renamed
										result += String.Format("Rev. {0, 5} Renamed \"{3}\"  from  {1} to \"{2}\"\r\n", mi.NewRevision, oldName, newName, nodeType);
									}
								}
								break;
						}
					}
				} else {
					result = "No Movement info could be found ( should not happen )";
				}

				_cachedContent = result;

				return result;
			}
			set { }
		}


		public string Name {
			get { return _name; }
		}
		public string FullPath {
			get { return _fullPath; }
		}
		public IList<FoundDiffWithColorSolution> Items {
			get {
				IList<FoundDiffWithColorSolution> res = new List<FoundDiffWithColorSolution>();
				for (int i = 0; i < _revisions.Count; i++) {
					res.Add(new FoundDiffWithColorSolution(_revisions[i], _fullPath));
				}
				return res;
			}
		}
		public int ResultCount {
			get { return _revisions.Count(); }
		}
		public string ResultCountString {
			get {
				//return String.Format("{0} result{1} in {2}{1} ", _revisions.Count(), (_revisions.Count() > 1 ? "s" : ""), FoundResultInFileNames ? "name" : "revision");
				return "";
			}
		}
		public bool FoundResultInFileNames {
			get {
				return _foundResultInFileNames;
			}
			set {
				_foundResultInFileNames = value;
			}
		}
		public System.Windows.Media.Brush TextColor {
			get {
				if (FoundResultInFileNames) {
					return new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Green);
				} else {
					return new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Black);
				}
			}
		}
		public System.Windows.Media.Brush BackgroundColor {
			get {

				if (movementInfos != null && movementInfos.Count > 0 && movementInfos[0].Action == MovementAction.Delete) {
					return new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 102, 102));
				} else {
					return new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.White);
				}
			}
		}

		public FoundFile(string name, string repositoryUrl, string fullPath, IList<MovementInfo> movementInfos, bool isFolder) {
			this._name = name;
			this._fullPath = fullPath;
			this._revisions = new List<FoundDiff>();
			this.movementInfos = movementInfos;
			this.isFolder = isFolder;
		}

		public void AddRevision(FoundDiff diff) {
			_revisions.Add(diff);
		}
	}
}
