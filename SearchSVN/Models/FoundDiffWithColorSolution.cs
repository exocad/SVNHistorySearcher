using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVNHistorySearcher.Models {

	// this class is meant as a quick fix for color coding whether a FoundDiff has another path
	public class FoundDiffWithColorSolution {
		FoundDiff foundDiff;
		bool hasOtherPath;

		public System.Windows.Media.Brush TextColor {
			get {
				if (hasOtherPath) {
					return new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Blue);
				} else {
					return new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Black);
				}
			}
		}

		public string Name {
			get { return foundDiff.Name; }
		}
		public string FullPath {
			get { return foundDiff.FullPath; }
		}
		public long PrevRevision {
			get { return foundDiff.PrevRevision; }
		}
		public long Revision {
			get { return foundDiff.Revision; }
		}
		public string Author {
			get { return foundDiff.Author; }
		}
		public string Message {
			get { return foundDiff.Message; }
		}
		public DateTime? Date {
			get { return foundDiff.Date; }
		}
		public string Content {
			get { return foundDiff.Content; }
			set { foundDiff.Content = value; }
		}
		public int ResultCount {
			get { return foundDiff.ResultCount; }
		}
		public string ResultCountString {
			get {
				return foundDiff.ResultCountString;
			}
		}
		public DiffInfo DiffInfo {
			get { return foundDiff.DiffInfo; }
		}
		public FoundDiff FoundDiff {
			get { return foundDiff; }
		}
		public bool IsExpanded { get; set; }

		public FoundDiffWithColorSolution(FoundDiff fd, string foundFilePath){
			foundDiff = fd;
			if (foundFilePath == fd.FullPath) {
				hasOtherPath = false;
			} else {
				hasOtherPath = true;
			}
		}
	}
}
