using System;

namespace SVNHistorySearcher.Models
{
	public class FoundDiff : IViewable
	{
		public string Name { get; }
		public string FullPath { get; }
		public long PrevRevision
		{
			get { return DiffInfo.RevA; }
		}
		public long Revision
		{
			get { return DiffInfo.RevB; }
		}
		public string Author
		{
			get { return DiffInfo.Author; }
		}
		public string Message
		{
			get { return DiffInfo.Message; }
		}
		public DateTime? Date
		{
			get { return DiffInfo.Date; }
		}
		public string Content { get; set; }
		public int ResultCount { get; }
		public string ResultCountString
		{
			get
			{
				return String.Format("{0} result{1}", ResultCount, (ResultCount > 1 ? "s" : ""));
			}
		}
		public DiffInfo DiffInfo { get; }

		public FoundDiff(string fileName, string fullPath, DiffInfo diffInfo, int resultAmount)
		{
			Name = fileName;
			FullPath = fullPath;
			ResultCount = resultAmount;
			DiffInfo = diffInfo;
		}
	}
}
