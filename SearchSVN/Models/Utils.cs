using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace SVNHistorySearcher.Models
{
	public static class Utils
	{
		public static string CalculateMD5Hash(string input)
		{
			MD5 md5 = System.Security.Cryptography.MD5.Create();
			byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
			byte[] hash = md5.ComputeHash(inputBytes);
			StringBuilder sb = new StringBuilder();

			for (int i = 0; i < hash.Length; i++)
			{
				sb.Append(hash[i].ToString("X2"));
			}
			return sb.ToString();
		}

		public static void CopyStream(Stream input, Stream output, long bytes)
		{
			byte[] buffer = new byte[32768];
			int read;
			while (bytes > 0 &&
				   (read = input.Read(buffer, 0, Math.Min(buffer.Length, (int)(bytes % int.MaxValue)))) > 0)
			{
				output.Write(buffer, 0, read);
				bytes -= read;
			}
		}

		public static void CopyStream(Stream input, Stream output, int bytes)
		{
			byte[] buffer = new byte[32768];
			int read;
			while (bytes > 0 &&
				   (read = input.Read(buffer, 0, Math.Min(buffer.Length, bytes))) > 0)
			{
				output.Write(buffer, 0, read);
				bytes -= read;
			}
		}

		/// <summary>
		/// Creates a file and copies a Stream into it
		/// </summary>
		/// <param name="filename">file name</param>
		/// <param name="stream">stream</param>
		/// <returns>True if successful. False if not.</returns>
		public static bool WriteStreamToFile(string filename, Stream stream)
		{
			string c;
			return WriteStreamToFile(filename, stream, out c);
		}

		/// <summary>
		/// Creates a file and copies a Stream into it
		/// </summary>
		/// <param name="filename">file name</param>
		/// <param name="stream">stream</param>
		/// <param name="checksum">MD5 checksum as lowercase hex</param>
		/// <returns>True if successful. False if not.</returns>
		public static bool WriteStreamToFile(string filename, Stream stream, out string checksum)
		{

			try
			{
				long prevPos = stream.Position;
				stream.Position = 0;

				using (var fs = new FileStream(filename, FileMode.Create, FileAccess.ReadWrite))
				{
					StreamWriter writer = new StreamWriter(fs)
					{
						AutoFlush = true
					};

					stream.CopyTo(fs);

					fs.Position = 0;

					using (var md5 = MD5.Create())
					{
						var hash = md5.ComputeHash(fs);
						checksum = BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
					}
				}

				stream.Position = prevPos;
			}
			catch
			{
				checksum = null;
				return false;
			}
			return true;
		}


		/// <summary>
		/// Creates a file and writes a string to it
		/// </summary>
		/// <param name="filename">file name</param>
		/// <param name="text">string</param>
		/// <returns>true if successful. False if not.</returns>
		public static bool WriteTextToFile(string filename, string text)
		{
			bool successful = true;
			try
			{
				using (var fs = new FileStream(filename, FileMode.Create, FileAccess.Write))
				{
					var swri = new StreamWriter(fs) { AutoFlush = true };
					swri.Write(text);
				}
			}
			catch (Exception ex)
			{
				Progress.ErrorLog(ex);
				successful = false;
			}
			return successful;
		}


		public static void Vardump<T>(string filename, IEnumerable<T> variable, Func<T, string> outputFunction)
		{
#if DEBUG
			try
			{
				string outputPath = SubversionSearcher.DEBUGFOLDER + @"\vardump";
				Directory.CreateDirectory(outputPath);
				using (var str = new FileStream(outputPath + @"\" + filename, FileMode.Create, FileAccess.Write))
				{
					var sw = new StreamWriter(str);
					foreach (T element in variable)
					{
						sw.WriteLine(outputFunction(element));
					}
				}
			}
			catch (Exception ex)
			{
				Progress.ErrorLog(ex);
			}
#endif
		}

		/// <summary>
		/// <para>Returns the list nodes of this path</para>
		/// e.g. "folder1/folder2/folder3" -> { "folder1", "folder2", "folder3" }
		/// </summary>
		/// <param name="path"></param>
		/// <returns></returns>
		public static IList<string> GetNodesInPath(string path)
		{
			return new List<string>(path.Trim('/').Split('/'));
		}


		/// <summary>
		/// Searches for a string inside a text. Ignores lines that don't start with '+' or '-'
		/// Is fast for texts that don't contain the pattern at all
		/// </summary>
		/// <param name="text">text to search in</param>
		/// <param name="pattern">string to search for</param>
		/// <param name="caseSensitive"></param>
		/// <returns></returns>
		public static bool BestSearch(string text, string pattern, bool caseSensitive)
		{
			if (caseSensitive)
			{
				return text.IndexOf(pattern, StringComparison.Ordinal) >= 0 && FastSearchWithPlusMinus(text, pattern, StringComparison.Ordinal);
			}
			else
			{
				return text.IndexOf(pattern, StringComparison.OrdinalIgnoreCase) >= 0 && FastSearchWithPlusMinus(text, pattern, StringComparison.OrdinalIgnoreCase);
			}
		}

		/// <summary>
		/// Searches for a regex a text. Ignores lines that don't start with '+' or '-'
		/// Is fast for texts that don't contain the pattern at all
		/// </summary>
		/// <param name="text">text to search in</param>
		/// <param name="pattern">Regex object to search with to search for</param>
		/// <returns></returns>
		public static bool BestSearch(string text, Regex pattern)
		{

			using (var reader = new StringReader(text))
			{
				String line;

				while ((line = reader.ReadLine()) != null)
				{
					if (line.Length != 0 && (line[0] == '+' || line[0] == '-') && pattern.IsMatch(line, 1))
					{
						return true;
					}
				}
			}
			return false;
		}

		/// <summary>
		/// Searches for a string inside a text. Ignores lines that don't start with '+' or '-'
		/// </summary>
		/// <param name="text">text to search in</param>
		/// <param name="pattern">string to search for</param>
		/// <returns>returns whether text contains str in a row that starts with a '+' or '-'</returns>
		static bool FastSearchWithPlusMinus(string text, string pattern, StringComparison comparision)
		{
			if (pattern.Length == 0 || text.Length < pattern.Length)
			{
				return false;
			}

			bool goodLine = text[0] == '+' || text[0] == '-';
			int lineStart = 0;
			int lineLength = 0;
			for (int i = 0; i < text.Length; i++)
			{

				if (text[i] == '\n')
				{
					if (goodLine && lineLength > 0)
					{
						if (text.Substring(lineStart, lineLength).IndexOf(pattern, comparision) >= 0)
						{
							return true;
						}
					}

					if (i + 1 < text.Length)
					{
						lineStart = i + 1;
						lineLength = 0;
						goodLine = text[i + 1] == '+' || text[i + 1] == '-';
					}
				}
				else if (goodLine)
				{
					lineLength++;
				}
			}

			if (goodLine && lineLength > 0)
			{
				if (text.Substring(lineStart, lineLength).IndexOf(pattern, comparision) >= 0)
				{
					return true;
				}
			}

			return false;
		}


		/// <summary>
		/// Joins paths. replaces slashes with backslashes. Uses backslashes for joining.
		/// </summary>
		/// <param name="paths">node names</param>
		/// <returns>new path</returns>
		public static string JoinPathsWin(params string[] paths)
		{
			string result = "";
			if (paths.Length > 0)
			{
				for (int i = 0; i < paths.Length - 1; i++)
				{
					result += paths[i].Trim('/', '\\').Replace('/', '\\') + '\\';
				}
				result += paths[paths.Length - 1];
			}
			return result;
		}


		/// <summary>
		/// Joins paths. replaces backslashes with slashed. Uses slashes for joining.
		/// </summary>
		/// <param name="paths">node names</param>
		/// <returns>new path</returns>
		public static string JoinPaths(params string[] paths)
		{
			string result = "";
			if (paths.Length > 0)
			{
				for (int i = 0; i < paths.Length - 1; i++)
				{
					result += paths[i].Trim('\\', '/').Replace('\\', '/') + '/';
				}
				result += paths[paths.Length - 1];
			}
			return result;
		}


		/// <summary>
		/// Gets Parent Path. e.g. folder1/folder2/file.txt  ->  folder1/folder2
		/// This method is simple and fast. It does not format the output in a specific way.
		/// </summary>
		/// <param name="path">Node Path</param>
		/// <returns>parent path</returns>
		public static string GetParentPath(string path)
		{
			for (int i = path.Length - 2; i > 0; i--)
			{
				if (path[i] == '/')
				{
					return path.Substring(0, i);
				}
			}
			return "";
		}
	}
}
