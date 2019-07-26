using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SVNHistorySearcher.Models {
	public interface IViewable {
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
