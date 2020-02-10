using System;

namespace SVNHistorySearcher.Models
{

	// this class is meant as a quick fix for color coding whether a FoundDiff has another path
	public class FoundDiffWithColorSolution
	{
		bool hasOtherPath;

		public System.Windows.Media.Brush TextColor
		{
			get
			{
				if (hasOtherPath)
				{
					return new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Blue);
				}
				else
				{
					return new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Black);
				}
			}
		}

		public string Name
		{
			get { return FoundDiff.Name; }
		}
		public string FullPath
		{
			get { return FoundDiff.FullPath; }
		}
		public long PrevRevision
		{
			get { return FoundDiff.PrevRevision; }
		}
		public long Revision
		{
			get { return FoundDiff.Revision; }
		}
		public string Author
		{
			get { return FoundDiff.Author; }
		}
		public string Message
		{
			get { return FoundDiff.Message; }
		}
		public DateTime? Date
		{
			get { return FoundDiff.Date; }
		}
		public string Content
		{
			get { return FoundDiff.Content; }
			set { FoundDiff.Content = value; }
		}
		public int ResultCount
		{
			get { return FoundDiff.ResultCount; }
		}
		public string ResultCountString
		{
			get
			{
				return FoundDiff.ResultCountString;
			}
		}
		public DiffInfo DiffInfo
		{
			get { return FoundDiff.DiffInfo; }
		}
		public FoundDiff FoundDiff { get; }
		public bool IsExpanded { get; set; }

		public FoundDiffWithColorSolution(FoundDiff fd, string foundFilePath)
		{
			FoundDiff = fd;
			if (foundFilePath == fd.FullPath)
			{
				hasOtherPath = false;
			}
			else
			{
				hasOtherPath = true;
			}
		}
	}
}
