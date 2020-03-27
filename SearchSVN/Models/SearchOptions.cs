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
			var hashCode = -420364669;

			int hcFiles = 0;
			int hcAuthors = 0;
			Files.ForEach(s => hcFiles += s.GetHashCode());
			Files.ForEach(s => hcAuthors += s.GetHashCode());

			hashCode = hashCode * -1521134295 + hcFiles;
			hashCode = hashCode * -1521134295 + hcAuthors;
			hashCode = hashCode * -1521134295 + EqualityComparer<SvnRevision>.Default.GetHashCode(SearchFromRevision);
			hashCode = hashCode * -1521134295 + EqualityComparer<SvnRevision>.Default.GetHashCode(SearchToRevision);
			hashCode = hashCode * -1521134295 + TreeRevision.GetHashCode();
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Repository);
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(FilenameSubstring);
			hashCode = hashCode * -1521134295 + SearchInContent.GetHashCode();
			hashCode = hashCode * -1521134295 + StopOnCopy.GetHashCode();
			hashCode = hashCode * -1521134295 + ExcludeAuthors.GetHashCode();
			return hashCode;
		}

		public override int GetHashCode()
		{
			var hashCode = GetHashCodeReloadRelevant();
			hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Text);
			hashCode = hashCode * -1521134295 + CaseSensitive.GetHashCode();
			hashCode = hashCode * -1521134295 + UseRegex.GetHashCode();
			hashCode = hashCode * -1521134295 + SearchInRenames.GetHashCode();
			return hashCode;
		}

		public SearchOptions DeepCopy() {
			SearchOptions result = (SearchOptions)this.MemberwiseClone();
			result.Authors = (from a in Authors select a).ToList();
			result.Files = Files = (from a in Files select a).ToList();
			return result;
		}
	}
}
