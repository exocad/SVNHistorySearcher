using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpSvn;

namespace SVNHistorySearcher.Models {
	public class SearchOptions {
		public IList<string> Files = new List<string>(); // contains folders aswell
		public IList<string> Authors = new List<string>();
		public SvnRevision SearchFromRevision;
		public SvnRevision SearchToRevision;
		public SvnRevision TreeRevision;
		public string Text = "";
		public string Repository = "";

		/// <summary>
		/// The path relative to the repository root, in which to search in all files containing
		/// FilenameSubstring
		/// </summary>
		public string HeadNodePath = "";
		public string FilenameSubstring = "";
		public bool CaseSensitive = false;
		public bool SearchInRenames = true;
		public bool SearchInContent = true;
		public bool StopOnCopy = false;
		public bool ExcludeAuthors = false;


		public int GetHashCodeReloadRelevant() {
			int result = 11;
			if (Files != null) {
				foreach (var f in Files) {
					result += f.GetHashCode();
				}
			}
			if (Authors != null) {
				foreach (var f in Authors) {
					result += f.GetHashCode();
				}
			}
			result += 1 * (SearchFromRevision != null ? SearchFromRevision.GetHashCode() : 1);
			result += 2 * (SearchToRevision != null ? SearchToRevision.GetHashCode() : 1);
			result += 3 * (TreeRevision != null ? TreeRevision.GetHashCode() : 1);
			result += 5 * (Repository != null ? Repository.GetHashCode() : 1);
			result += 7 * (FilenameSubstring != null ? FilenameSubstring.GetHashCode() : 1);
			result += 11*(SearchInContent.GetHashCode() + 1);
			result += 13*(StopOnCopy.GetHashCode() + 1);
			result += 17*(ExcludeAuthors.GetHashCode() + 1);
			return result;
		}


		public int GetHashCode() {
			int result = GetHashCodeReloadRelevant();
			result += 19*(Text != null ? Text.GetHashCode() : 1);
			result += 23*(CaseSensitive.GetHashCode() + 1);
			result += 29*(SearchInRenames.GetHashCode() + 1);
			return result;
		}
	}
}
