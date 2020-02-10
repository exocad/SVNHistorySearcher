using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.IO;
using System.Security;
using System.Collections;
using System.Xml.Serialization;
using System.Xml;
using System.Xml.Schema;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;

namespace SVNHistorySearcher.Models
{
	public class Settings
	{

		private static Settings _instance = null;
		public static Settings Instance
		{
			get
			{
				if (_instance == null)
					Initialize();
				return _instance;
			}
		}

		public static readonly string RootPath = Path.GetFullPath(@".\");
		public static readonly string SavingPath = Utils.JoinPathsWin(RootPath, "data");
		public static readonly string CachePath = Utils.JoinPathsWin(SavingPath, "cache");
		public static readonly string TempPath = Utils.JoinPathsWin(SavingPath, "temp");
		public static readonly string BadDiffStreamsPath = Utils.JoinPathsWin(SavingPath, "BadDiffStreams");
		public static readonly string RepositoriesFolder = Utils.JoinPathsWin(SavingPath, "Repositories");
		public static readonly string SettingsFilePath = Utils.JoinPathsWin(SavingPath, "settings.xml");

		public bool LoadPreviousRepositoryOnStartup { get; set; }
		public string PreviousRepositoryUrl { get; set; }
		public int RepositoryHistoryLength { get; set; }
		public List<string> RecentRepositories { get; set; }
		public string TortoisePath { get; set; }
		public int MaxThreads { get; set; }
		public List<string> FileExtensionBlacklist { get; set; }
		public string Username { get; set; }
		
		[XmlIgnore]
		public string Password
		{
			get
			{
				if (EncryptedPassword != null)
				{
					byte[] entropy = Encoding.Unicode.GetBytes("I am a passphrase :)");
					byte[] originalText = ProtectedData.Unprotect(EncryptedPassword, entropy, DataProtectionScope.CurrentUser);
					return Encoding.Unicode.GetString(originalText);
				}
				return null;
			}
			set
			{
				if (EncryptedPassword != null)
				{
					for (int i = 0; i < EncryptedPassword.Length; i++)
					{
						EncryptedPassword[i] = 0;
					}
				}

				if (value != null)
				{
					byte[] entropy = Encoding.Unicode.GetBytes("I am a passphrase :)");
					byte[] plaintext = Encoding.Unicode.GetBytes(value);
					EncryptedPassword = ProtectedData.Protect(plaintext, entropy, DataProtectionScope.CurrentUser);
				}
			}
		}

		public byte[] EncryptedPassword { get; set; }

		private static string settingsVersion = "2";

		static void Initialize()
		{
			CreateDirectories();
			ClearTemporaryFiles();

			if (!File.Exists(SettingsFilePath))
			{
				var assembly = System.Reflection.Assembly.GetExecutingAssembly();
				var fileName = assembly.GetManifestResourceNames().Single(str => str.EndsWith("settings.xml"));
				using (Stream resourceStream = assembly.GetManifestResourceStream(fileName))
				{
					resourceStream.Position = 0;
					StreamReader sr = new StreamReader(resourceStream);
					string text = sr.ReadToEnd().Replace("[VERSION]", settingsVersion);
					File.WriteAllText(SettingsFilePath, text);
				}
			}
			_instance = Load(SettingsFilePath);
		}

		public static void Save()
		{
			CreateDirectories();
			Instance.SaveToFile(SettingsFilePath);
		}

		private static Settings Load(string fileName)
		{
			using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
			{
				return Load(fs);
			}
		}

		private static Settings Load(Stream stream)
		{
			System.Xml.Serialization.XmlSerializer formatter = new System.Xml.Serialization.XmlSerializer(typeof(Settings));
			Settings instance = null;
			using (StreamReader sr = new StreamReader(stream))
			{
				instance = (Settings)formatter.Deserialize(sr);
			}
			return instance;
		}

		private void SaveToFile(string fileName)
		{
			System.Xml.Serialization.XmlSerializer ser = new System.Xml.Serialization.XmlSerializer(typeof(Settings));

			try
			{
				using (FileStream fs = new FileStream(fileName, FileMode.Create))
				{
					ser.Serialize(fs, this);
				}
			}
			catch (Exception e)
			{
				System.Console.WriteLine("An error occurred:" + Environment.NewLine + e.ToString());
			}
		}


		public static void CreateDirectories()
		{
			Directory.CreateDirectory(SavingPath);
			Directory.CreateDirectory(CachePath);
			Directory.CreateDirectory(TempPath);
			Directory.CreateDirectory(RepositoriesFolder);
#if DEBUG
			Directory.CreateDirectory(BadDiffStreamsPath);
#endif
		}


		private static bool ClearDirectory(string path)
		{
			bool successful = true;
			if (Directory.Exists(path))
			{
				foreach (string s in Directory.GetDirectories(path))
				{
					try
					{
						Directory.Delete(s, true);
					}
					catch
					{
						successful = false;
					}
				}

				foreach (string s in Directory.GetFiles(path))
				{
					try
					{
						File.Delete(s);
					}
					catch
					{
						successful = false;
					}
				}
			}
			return successful;
		}

		String SecureStringToString(SecureString value)
		{
			IntPtr valuePtr = IntPtr.Zero;
			try
			{
				valuePtr = Marshal.SecureStringToGlobalAllocUnicode(value);
				return Marshal.PtrToStringUni(valuePtr);
			}
			finally
			{
				Marshal.ZeroFreeGlobalAllocUnicode(valuePtr);
			}
		}

		public static void ClearTemporaryFiles()
		{
			ClearDirectory(CachePath);
			ClearDirectory(TempPath);
			ClearDirectory(BadDiffStreamsPath);
		}

		public static string GetRepositoryFolder(string repositoryUrl)
		{
			string result = "";
			foreach (char c in repositoryUrl.ToLower())
			{
				if (Char.IsLetterOrDigit(c))
				{
					result += c;
				}
			}
			result = Utils.JoinPathsWin(Settings.RepositoriesFolder, result + Utils.CalculateMD5Hash(repositoryUrl.ToLower()).Substring(0, 8));
			return result;
		}
	}
}
