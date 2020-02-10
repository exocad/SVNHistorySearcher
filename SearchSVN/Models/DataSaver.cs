using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.IO;

namespace SVNHistorySearcher.Models
{
	public static class DataSaver
	{

		static XDocument doc;
		public static string RootPath = Path.GetFullPath(@".\");
		public static string SavingPath = Utils.JoinPathsWin(RootPath, "data");
		public static string CachePath = Utils.JoinPathsWin(SavingPath, "cache");
		public static string TempPath = Utils.JoinPathsWin(SavingPath, "temp");
		public static string BadDiffStreamsPath = Utils.JoinPathsWin(SavingPath, "BadDiffStreams");
		public static string RepositoriesFolder = Utils.JoinPathsWin(SavingPath, "Repositories");
		public static string SettingsFilePath = Utils.JoinPathsWin(SavingPath, "settings.xml");


		public static bool LoadPreviousRepositoryOnStartup;
		public static string PreviousRepositoryUrl;
		public static int RepositoryHistoryLength;
		public static IList<string> RecentRepositories;
		public static string TortoisePath;
		public static int MaxThreads;
		public static IList<string> FileExtensionBlacklist;
		public static string Username;
		public static string Password {
			get {
				return StringCipher.Decrypt(_password, _passphrase);
			}
			set {
				if (value != null) {
					_password = StringCipher.Encrypt(value, _passphrase);
				}
			}
		}
		private static string _password;

		static bool _hasValidUsername = false;
		static bool _hasValidPassword = false;

		private static string _passphrase = "i am a passphrase :)";
		private static string settingsVersion = "1.06";

		static DataSaver() {
			CreateDirectories();
			ClearTemporaryFiles();

			LoadDefaults();

			// try to load from existing file
			if (File.Exists(SettingsFilePath)) {
				// load from existing file
				try {
					var lf = XDocument.Load(SettingsFilePath);

					if (lf.Root.Name != "Settings") {
						var oldPath = SettingsFilePath + "_old" + DateTime.Now;
						File.Copy(SettingsFilePath, oldPath);
					} else {
						doc = lf;
						LoadFromDoc(doc);
					}

				} catch (Exception ex) {
					Progress.ErrorLog(ex);
				}
			}
		}


		private static void LoadFromDoc(XDocument doc) {
			XElement e;
			int ti;

			if ((e = doc.Root.Element("PreviousRepositoryUrl")) != null) {
				PreviousRepositoryUrl = e.Value.Trim();
			}


			if ((e = doc.Root.Element("RepositoryHistoryLength")) != null && int.TryParse(e.Value.Trim(), out ti)) {
				RepositoryHistoryLength = ti;
			}


			if ((e = doc.Root.Element("TortoisePath")) != null) {
				TortoisePath = e.Value.Trim();
			}

			if ((e = doc.Root.Element("MaxFetchingThreads")) != null && int.TryParse(e.Value.Trim(), out ti)) {
				MaxThreads = ti;
			}


			if ((e = doc.Root.Element("RecentRepositories")) != null) {
				RecentRepositories = new List<string>();
				foreach (var a in doc.Root.Element("RecentRepositories").Elements("Url")) {
					RecentRepositories.Add(a.Value.Trim());
				}
			}


			if ((e = doc.Root.Element("FileExtensionBlacklist")) != null) {
				FileExtensionBlacklist = new List<string>();
				foreach (var a in doc.Root.Element("FileExtensionBlacklist").Elements("e")) {
					FileExtensionBlacklist.Add(a.Value.Trim());
				}
			}


			if ((e = doc.Root.Element("Username")) != null) {
				Username = e.Value;
				_hasValidUsername = true;
			}
			if ((e = doc.Root.Element("Password")) != null) {
				_password = e.Value;
				_hasValidPassword = true;
			}


			if ((e = doc.Root.Element("LoadPreviousRepositoryOnStartup")) != null) {
				string loadPrevious = e.Value.Trim().ToLower();
				LoadPreviousRepositoryOnStartup = (loadPrevious == "yes" || loadPrevious == "y" || loadPrevious == "true");
			}

		}

		/// <summary>
		/// Loads defaults directly from settings.xml in the assembly
		/// </summary>
		private static void LoadDefaults() {
			var assembly = System.Reflection.Assembly.GetExecutingAssembly();
			var fileName = assembly.GetManifestResourceNames().Single(str => str.EndsWith("settings.xml"));

			using (Stream resourceStream = assembly.GetManifestResourceStream(fileName)) {
				resourceStream.Position = 0;
				StreamReader sr = new StreamReader(resourceStream);
				string text = sr.ReadToEnd().Replace("[VERSION]", settingsVersion);
				MemoryStream stream = new MemoryStream();
				StreamWriter sw = new StreamWriter(stream) { AutoFlush = true };
				sw.Write(text);

				stream.Position = 0;

				doc = XDocument.Load(stream);
			}

			PreviousRepositoryUrl = doc.Root.Element("PreviousRepositoryUrl").Value;
			RepositoryHistoryLength = int.Parse(doc.Root.Element("RepositoryHistoryLength").Value);
			TortoisePath = doc.Root.Element("TortoisePath").Value;
			MaxThreads = int.Parse(doc.Root.Element("MaxFetchingThreads").Value);

			string loadPrevious = doc.Root.Element("LoadPreviousRepositoryOnStartup").Value.Trim().ToLower();
			LoadPreviousRepositoryOnStartup = (loadPrevious == "yes" || loadPrevious == "y" || loadPrevious == "true");

			Username = "";
			Password = "";

			RecentRepositories = new List<string>();
			foreach (var a in doc.Root.Element("RecentRepositories").Elements("Url")) {
				RecentRepositories.Add(a.Value.Trim());
			}

			FileExtensionBlacklist = new List<string>();
			foreach (var a in doc.Root.Element("FileExtensionBlacklist").Elements("e")) {
				FileExtensionBlacklist.Add(a.Value.Trim());
			}
		}


		public static void Save() {
			CreateDirectories();

			if (doc != null) {

				XElement e;

				if ((e = doc.Root.Element("PreviousRepositoryUrl")) != null) {
					e.Value = PreviousRepositoryUrl;
				} else {
					doc.Root.Add(new XElement("PreviousRepositoryUrl", PreviousRepositoryUrl));
				}


				if ((e = doc.Root.Element("LoadPreviousRepositoryOnStartup")) != null) {
					e.Value = LoadPreviousRepositoryOnStartup ? "yes" : "no";
				} else {
					doc.Root.Add(new XElement("LoadPreviousRepositoryOnStartup", LoadPreviousRepositoryOnStartup ? "yes" : "no"));
				}


				if ((e = doc.Root.Element("RepositoryHistoryLength")) != null) {
					e.Value = RepositoryHistoryLength.ToString();
				} else {
					doc.Root.Add(new XElement("RepositoryHistoryLength", RepositoryHistoryLength));
				}


				if ((e = doc.Root.Element("TortoisePath")) != null) {
					e.Value = TortoisePath;
				} else {
					doc.Root.Add(new XElement("TortoisePath", TortoisePath));
				}

				if ((e = doc.Root.Element("MaxFetchingThreads")) != null) {
					e.Value = MaxThreads.ToString();
				} else {
					doc.Root.Add(new XElement("MaxFetchingThreads", MaxThreads));
				}


				if ((e = doc.Root.Element("RecentRepositories")) != null) {
					foreach (var a in e.Elements("Url").ToList()) {
						a.Remove();
					}

					foreach (var a in RecentRepositories) {
						e.Add(new XElement("Url", a));
					}

				} else {
					var head = new XElement("RecentRepositories");
					foreach (var a in RecentRepositories) {
						head.Add(new XElement("Url", a));
					}
					doc.Root.Add(head);
				}


				if ((e = doc.Root.Element("FileExtensionBlacklist")) != null) {
					var fb = new HashSet<string>(FileExtensionBlacklist);
					var hs = new HashSet<string>();

					foreach (var a in e.Elements("e").ToList()) {
						if (fb.Contains(a.Value)) {
							hs.Add(a.Value);
						} else {
							a.Remove();
						}
					}

					foreach (var a in FileExtensionBlacklist) {
						if (!hs.Contains(a)) {
							e.Add(new XElement("e", a));
						}
					}

				} else {
					var head = new XElement("FileExtensionBlacklist");
					foreach (var a in FileExtensionBlacklist) {
						head.Add(new XElement("e", a));
					}
				}


				if (_hasValidUsername) {
					if ((e = doc.Root.Element("Username")) != null) {
						e.Value = Username;
					} else {
						doc.Root.Add("Username", Username);
					}
				}
				if (_hasValidPassword) {
					if ((e = doc.Root.Element("Password")) != null) {
						e.Value = _password;
					} else {
						doc.Root.Add("Password", _password);
					}
				}

				doc.Save(SettingsFilePath);
			}
		}


		public static void CreateDirectories() {
			Directory.CreateDirectory(SavingPath);
			Directory.CreateDirectory(CachePath);
			Directory.CreateDirectory(TempPath);
			Directory.CreateDirectory(RepositoriesFolder);
#if DEBUG
			Directory.CreateDirectory(BadDiffStreamsPath);
#endif
		}


		private static bool ClearDirectory(string path) {
			bool successful = true;
			if (Directory.Exists(path)) {
				foreach (string s in Directory.GetDirectories(path)) {
					try {
						Directory.Delete(s, true);
					} catch {
						successful = false;
					}
				}

				foreach (string s in Directory.GetFiles(path)) {
					try {
						File.Delete(s);
					} catch {
						successful = false;
					}
				}
			}
			return successful;
		}

		public static void ClearTemporaryFiles() {
			ClearDirectory(CachePath);
			ClearDirectory(TempPath);
			ClearDirectory(BadDiffStreamsPath);
		}

		public static string GetRepositoryFolder(string repositoryUrl) {
			string result = "";
			foreach (char c in repositoryUrl.ToLower()) {
				if (Char.IsLetterOrDigit(c)) {
					result += c;
				}
			}
			result = Utils.JoinPathsWin(DataSaver.RepositoriesFolder, result + Utils.CalculateMD5Hash(repositoryUrl.ToLower()).Substring(0, 8));
			return result;
		}
	}
}
