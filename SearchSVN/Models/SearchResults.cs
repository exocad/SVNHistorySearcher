using System.Collections.Generic;

namespace SVNHistorySearcher.Models
{
	public class SearchResults
	{
		public double? TotalTime { get; set; } = null;
		public double? DownloadingTime { get; set; } = null;
		public int ResultCount { get; }
		public string ErrorPath { get; private set; } = "";
		public bool Successful { get; private set; }

		public SearchOptions SearchOptions { get; private set; }
		public string SearchString
		{
			get { return SearchOptions.Text; }
		}

		public bool UseRegex
		{
			get { return SearchOptions.UseRegex; }
		}

		public IList<FoundFile> Files { get; }

		public SearchResults(IList<FoundFile> files, SearchOptions searchOptions, int resultCount, bool successful = true, string errorsPath = "")
		{
			Successful = successful;
			Files = files;
			SearchOptions = searchOptions;
			ErrorPath = errorsPath;
			ResultCount = resultCount;
		}

		public void SetStillMissing(string pathToFile)
		{
			ErrorPath = pathToFile;
		}

		public void SetFailed()
		{
			Successful = false;
		}
	}
}
