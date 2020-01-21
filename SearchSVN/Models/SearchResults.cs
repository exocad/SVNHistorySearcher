using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVNHistorySearcher.Models {
	public class SearchResults {

		/// <summary>
		/// Unit should be milliseconds
		/// </summary>
		private double _totalTime = -1;
		public double TotalTime { get { return _totalTime; } set { _totalTime = value; } }

		/// <summary>
		/// Unit should be milliseconds
		/// </summary>
		private double _downloadingTime = -1;
		public double DownloadingTime { get { return _downloadingTime; } set { _downloadingTime = value; } }

		private int _resultCount;
		public int ResultCount { get { return _resultCount; } }

		private string _errorPath = "";
		public string ErrorPath { get { return _errorPath; } }

		private bool _successful;
		public bool Successful { get { return _successful; } }

		private SearchOptions _searchOptions;
		public string SearchString {
			get { return _searchOptions.Text; }
		}

		public bool UseRegex {
			get { return _searchOptions.UseRegex; }
		}

		IList<FoundFile> _files;
		public IList<FoundFile> Files {
			get { return _files; }
		}

		public SearchResults(IList<FoundFile> files, SearchOptions searchOptions, int resultCount, bool successful = true, string errorsPath = "") {
			_successful = successful;
			_files = files;
			_searchOptions = searchOptions;
			_errorPath = errorsPath;
			_resultCount = resultCount;
		}

		public void SetStillMissing(string pathToFile) {
			_errorPath = pathToFile;
		}

		public void SetFailed() {
			_successful = false;
		}
	}
}
