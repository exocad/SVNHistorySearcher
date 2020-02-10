using System;

namespace SVNHistorySearcher.Models
{
	public interface IViewable
	{
		string FullPath { get; }
		long PrevRevision { get; }
		long Revision { get; }
		string Author { get; }
		string Message { get; }
		DateTime? Date { get; }
		string Name { get; }
		string Content { get; set; }
		//int FoundSomething { get; }
	}
}
