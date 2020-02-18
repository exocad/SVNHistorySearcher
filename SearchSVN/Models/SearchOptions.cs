using SharpSvn;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace SVNHistorySearcher.Models
{
	public class SearchOptions
	{
		[XmlIgnore]
		public List<string> Files = new List<string>(); // contains folders as well
		public List<string> Authors = new List<string>();
		[XmlIgnore]
		public SvnRevision SearchFromRevision;
		[XmlIgnore]
		public SvnRevision SearchToRevision;
		[XmlIgnore]
		public long? TreeRevision;
		[XmlIgnore]
		public string Text = "";
		[XmlIgnore]
		public string Repository = "";

		/// <summary>
		/// The path relative to the repository root, in which to search in all files containing
		/// FilenameSubstring
		/// </summary>
		[XmlIgnore]
		public string HeadNodePath = "";
		public string FilenameSubstring = "";
		public bool CaseSensitive = false;
		public bool UseRegex = false;
		public bool SearchInRenames = true;
		public bool SearchInContent = true;
		public bool StopOnCopy = false;
		public bool ExcludeAuthors = false;


		public SearchOptions()
		{
			SearchFromRevision = new SvnRevision(new System.DateTime(1999, 02, 25, 0, 0, 0, 0, System.DateTimeKind.Utc));
			SearchToRevision = new SvnRevision(SvnRevisionType.Head);
		}

		public int GetHashCodeReloadRelevant()
		{
			int result = 11;
			if (Files != null)
			{
				foreach (var f in Files)
				{
					result += f.GetHashCode();
				}
			}
			if (Authors != null)
			{
				foreach (var f in Authors)
				{
					result += f.GetHashCode();
				}
			}
			result += 1 * (SearchFromRevision != null ? SearchFromRevision.GetHashCode() : 1);
			result += 2 * (SearchToRevision != null ? SearchToRevision.GetHashCode() : 1);
			result += 3 * (TreeRevision != null ? TreeRevision.GetHashCode() : 1);
			result += 5 * (Repository != null ? Repository.GetHashCode() : 1);
			result += 7 * (FilenameSubstring != null ? FilenameSubstring.GetHashCode() : 1);
			result += 11 * (SearchInContent.GetHashCode() + 1);
			result += 13 * (StopOnCopy.GetHashCode() + 1);
			result += 17 * (ExcludeAuthors.GetHashCode() + 1);
			return result;
		}


		public override int GetHashCode()
		{
			int result = GetHashCodeReloadRelevant();
			result += 19 * (Text != null ? Text.GetHashCode() : 1);
			result += 23 * (CaseSensitive.GetHashCode() + 1);
			result += 29 * (SearchInRenames.GetHashCode() + 1);
			result += 31 * (UseRegex.GetHashCode() + 1);
			return result;
		}

		public SearchOptions DeepCopy() {
			SearchOptions result = (SearchOptions)this.MemberwiseClone();
			result.Authors = (from a in Authors select a).ToList();
			result.Files = Files = (from a in Files select a).ToList();
			return result;
		}
	}
}
