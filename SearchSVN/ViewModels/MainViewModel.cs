/*

This file is part of the tool "SVNHistorySearcher" is licensed under the "Apache License Version 2.0", see APACHE-LICENSE-2.0.txt and http://www.apache.org/licenses/LICENSE-2.0.html
The tool "SVNHistorySearcher" was developed in the company exocad GmbH by the author Ion Paciu in 2019.

                Apache License
                           Version 2.0, January 2004
                        http://www.apache.org/licenses/

   TERMS AND CONDITIONS FOR USE, REPRODUCTION, AND DISTRIBUTION

   1. Definitions.

      "License" shall mean the terms and conditions for use, reproduction,
      and distribution as defined by Sections 1 through 9 of this document.

      "Licensor" shall mean the copyright owner or entity authorized by
      the copyright owner that is granting the License.

      "Legal Entity" shall mean the union of the acting entity and all
      other entities that control, are controlled by, or are under common
      control with that entity. For the purposes of this definition,
      "control" means (i) the power, direct or indirect, to cause the
      direction or management of such entity, whether by contract or
      otherwise, or (ii) ownership of fifty percent (50%) or more of the
      outstanding shares, or (iii) beneficial ownership of such entity.

      "You" (or "Your") shall mean an individual or Legal Entity
      exercising permissions granted by this License.

      "Source" form shall mean the preferred form for making modifications,
      including but not limited to software source code, documentation
      source, and configuration files.

      "Object" form shall mean any form resulting from mechanical
      transformation or translation of a Source form, including but
      not limited to compiled object code, generated documentation,
      and conversions to other media types.

      "Work" shall mean the work of authorship, whether in Source or
      Object form, made available under the License, as indicated by a
      copyright notice that is included in or attached to the work
      (an example is provided in the Appendix below).

      "Derivative Works" shall mean any work, whether in Source or Object
      form, that is based on (or derived from) the Work and for which the
      editorial revisions, annotations, elaborations, or other modifications
      represent, as a whole, an original work of authorship. For the purposes
      of this License, Derivative Works shall not include works that remain
      separable from, or merely link (or bind by name) to the interfaces of,
      the Work and Derivative Works thereof.

      "Contribution" shall mean any work of authorship, including
      the original version of the Work and any modifications or additions
      to that Work or Derivative Works thereof, that is intentionally
      submitted to Licensor for inclusion in the Work by the copyright owner
      or by an individual or Legal Entity authorized to submit on behalf of
      the copyright owner. For the purposes of this definition, "submitted"
      means any form of electronic, verbal, or written communication sent
      to the Licensor or its representatives, including but not limited to
      communication on electronic mailing lists, source code control systems,
      and issue tracking systems that are managed by, or on behalf of, the
      Licensor for the purpose of discussing and improving the Work, but
      excluding communication that is conspicuously marked or otherwise
      designated in writing by the copyright owner as "Not a Contribution."

      "Contributor" shall mean Licensor and any individual or Legal Entity
      on behalf of whom a Contribution has been received by Licensor and
      subsequently incorporated within the Work.

   2. Grant of Copyright License. Subject to the terms and conditions of
      this License, each Contributor hereby grants to You a perpetual,
      worldwide, non-exclusive, no-charge, royalty-free, irrevocable
      copyright license to reproduce, prepare Derivative Works of,
      publicly display, publicly perform, sublicense, and distribute the
      Work and such Derivative Works in Source or Object form.

   3. Grant of Patent License. Subject to the terms and conditions of
      this License, each Contributor hereby grants to You a perpetual,
      worldwide, non-exclusive, no-charge, royalty-free, irrevocable
      (except as stated in this section) patent license to make, have made,
      use, offer to sell, sell, import, and otherwise transfer the Work,
      where such license applies only to those patent claims licensable
      by such Contributor that are necessarily infringed by their
      Contribution(s) alone or by combination of their Contribution(s)
      with the Work to which such Contribution(s) was submitted. If You
      institute patent litigation against any entity (including a
      cross-claim or counterclaim in a lawsuit) alleging that the Work
      or a Contribution incorporated within the Work constitutes direct
      or contributory patent infringement, then any patent licenses
      granted to You under this License for that Work shall terminate
      as of the date such litigation is filed.

   4. Redistribution. You may reproduce and distribute copies of the
      Work or Derivative Works thereof in any medium, with or without
      modifications, and in Source or Object form, provided that You
      meet the following conditions:

      (a) You must give any other recipients of the Work or
          Derivative Works a copy of this License; and

      (b) You must cause any modified files to carry prominent notices
          stating that You changed the files; and

      (c) You must retain, in the Source form of any Derivative Works
          that You distribute, all copyright, patent, trademark, and
          attribution notices from the Source form of the Work,
          excluding those notices that do not pertain to any part of
          the Derivative Works; and

      (d) If the Work includes a "NOTICE" text file as part of its
          distribution, then any Derivative Works that You distribute must
          include a readable copy of the attribution notices contained
          within such NOTICE file, excluding those notices that do not
          pertain to any part of the Derivative Works, in at least one
          of the following places: within a NOTICE text file distributed
          as part of the Derivative Works; within the Source form or
          documentation, if provided along with the Derivative Works; or,
          within a display generated by the Derivative Works, if and
          wherever such third-party notices normally appear. The contents
          of the NOTICE file are for informational purposes only and
          do not modify the License. You may add Your own attribution
          notices within Derivative Works that You distribute, alongside
          or as an addendum to the NOTICE text from the Work, provided
          that such additional attribution notices cannot be construed
          as modifying the License.

      You may add Your own copyright statement to Your modifications and
      may provide additional or different license terms and conditions
      for use, reproduction, or distribution of Your modifications, or
      for any such Derivative Works as a whole, provided Your use,
      reproduction, and distribution of the Work otherwise complies with
      the conditions stated in this License.

   5. Submission of Contributions. Unless You explicitly state otherwise,
      any Contribution intentionally submitted for inclusion in the Work
      by You to the Licensor shall be under the terms and conditions of
      this License, without any additional terms or conditions.
      Notwithstanding the above, nothing herein shall supersede or modify
      the terms of any separate license agreement you may have executed
      with Licensor regarding such Contributions.

   6. Trademarks. This License does not grant permission to use the trade
      names, trademarks, service marks, or product names of the Licensor,
      except as required for reasonable and customary use in describing the
      origin of the Work and reproducing the content of the NOTICE file.

   7. Disclaimer of Warranty. Unless required by applicable law or
      agreed to in writing, Licensor provides the Work (and each
      Contributor provides its Contributions) on an "AS IS" BASIS,
      WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or
      implied, including, without limitation, any warranties or conditions
      of TITLE, NON-INFRINGEMENT, MERCHANTABILITY, or FITNESS FOR A
      PARTICULAR PURPOSE. You are solely responsible for determining the
      appropriateness of using or redistributing the Work and assume any
      risks associated with Your exercise of permissions under this License.

   8. Limitation of Liability. In no event and under no legal theory,
      whether in tort (including negligence), contract, or otherwise,
      unless required by applicable law (such as deliberate and grossly
      negligent acts) or agreed to in writing, shall any Contributor be
      liable to You for damages, including any direct, indirect, special,
      incidental, or consequential damages of any character arising as a
      result of this License or out of the use or inability to use the
      Work (including but not limited to damages for loss of goodwill,
      work stoppage, computer failure or malfunction, or any and all
      other commercial damages or losses), even if such Contributor
      has been advised of the possibility of such damages.

   9. Accepting Warranty or Additional Liability. While redistributing
      the Work or Derivative Works thereof, You may choose to offer,
      and charge a fee for, acceptance of support, warranty, indemnity,
      or other liability obligations and/or rights consistent with this
      License. However, in accepting such obligations, You may act only
      on Your own behalf and on Your sole responsibility, not on behalf
      of any other Contributor, and only if You agree to indemnify,
      defend, and hold each Contributor harmless for any liability
      incurred by, or claims asserted against, such Contributor by reason
      of your accepting any such warranty or additional liability.

   END OF TERMS AND CONDITIONS

   APPENDIX: How to apply the Apache License to your work.

      To apply the Apache License to your work, attach the following
      boilerplate notice, with the fields enclosed by brackets "[]"
      replaced with your own identifying information. (Don't include
      the brackets!)  The text should be enclosed in the appropriate
      comment syntax for the file format. We also recommend that a
      file or class name and description of purpose be included on the
      same "printed page" as the copyright notice for easier
      identification within third-party archives.

   Copyright [2019] [exocad GmbH, Julius-Reiber-Str.37, 64293 Darmstadt, Germany]

   Licensed under the Apache License, Version 2.0 (the "License");
   you may not use this file except in compliance with the License.
   You may obtain a copy of the License at

       http://www.apache.org/licenses/LICENSE-2.0

   Unless required by applicable law or agreed to in writing, software
   distributed under the License is distributed on an "AS IS" BASIS,
   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
   See the License for the specific language governing permissions and
   limitations under the License.


*/


using SharpSvn;
using SVNHistorySearcher.Common;
using SVNHistorySearcher.Models;
using SVNHistorySearcher.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SVNHistorySearcher.ViewModels
{
	public class MainViewModel : ViewModel
	{

		SearchResultsViewModel _searchResultsViewModel;
		FilePreviewViewModel _filePreviewViewModel;
		RepositoryOverviewViewModel _repositoryOverviewViewModel;

		private SubversionSearcher subversionSearcher;
		public SetCredentialsWindow SetCredentialsWindow;
		Task searchTask;

		AtomicBoolean currentlyLoadingRepository = new AtomicBoolean(false);

		List<string> previousNodeList = null;
		List<Tuple<string, bool>> previousSelectedList = null;

		Dictionary<string, ICommand> _buttonCommands = new Dictionary<string, ICommand>();

		public SearchResultsViewModel SearchResults
		{
			get
			{
				return _searchResultsViewModel ?? (_searchResultsViewModel = new SearchResultsViewModel(this));
			}
		}

		public FilePreviewViewModel FilePreview
		{
			get
			{
				return _filePreviewViewModel ?? (_filePreviewViewModel = new FilePreviewViewModel(this));
			}
		}

		public RepositoryOverviewViewModel RepositoryOverview
		{
			get
			{
				return _repositoryOverviewViewModel ?? (_repositoryOverviewViewModel = new RepositoryOverviewViewModel(this));
			}
		}


		private string _windowCaption = "SVNHistorySearcher";
		public string WindowCaption
		{
			get { return _windowCaption; }
			set
			{
				_windowCaption = value;
				RaisePropertyChanged("WindowCaption");
			}
		}

		public double WindowWidth
		{
			get { return Settings.Instance.WindowWidth; }
			set {
				Settings.Instance.WindowWidth = value;
				RaisePropertyChanged("WindowWidth");
			}
		}

		public double WindowHeight
		{
			get { return Settings.Instance.WindowHeight; }
			set {
				Settings.Instance.WindowHeight = value;
				RaisePropertyChanged("WindowHeight");
			}
		}
		public GridLength ColumnOneWidth
		{
			get { return new GridLength(Settings.Instance.ColumnOneWidth, GridUnitType.Pixel); }
			set
			{
				Settings.Instance.ColumnOneWidth = value.Value;
				RaisePropertyChanged("ColumnOneWidth");
			}
		}
		public GridLength ColumnTwoWidth
		{
			get { return new GridLength(Settings.Instance.ColumnTwoWidth, GridUnitType.Pixel); }
			set
			{
				Settings.Instance.ColumnTwoWidth = value.Value;
				RaisePropertyChanged("ColumnTwoWidth");
			}
		}
		public GridLength ColumnRepoViewWidth
		{
			get { return new GridLength(Settings.Instance.ColumnRepoViewWidth, GridUnitType.Star); }
			set
			{
				Settings.Instance.ColumnRepoViewWidth = value.Value;
				RaisePropertyChanged("ColumnRepoViewWidth");
			}
		}
		public GridLength ColumnResultViewWidth
		{
			get { return new GridLength(Settings.Instance.ColumnResultViewWidth, GridUnitType.Star); }
			set
			{
				Settings.Instance.ColumnResultViewWidth = value.Value;
				RaisePropertyChanged("ColumnResultViewWidth");
			}
		}
		public GridLength ColumnTextViewer
		{
			get { return new GridLength(Settings.Instance.ColumnTextViewer, GridUnitType.Star); }
			set
			{
				Settings.Instance.ColumnTextViewer = value.Value;
				RaisePropertyChanged("ColumnTextViewer");
			}
		}
		public WindowState WindowState
		{
			get { return Settings.Instance.WindowIsMaximized ? WindowState.Maximized : WindowState.Normal; }
			set
			{
				Settings.Instance.WindowIsMaximized = value == WindowState.Maximized;
				RaisePropertyChanged("WindowIsMaximized");
			}
		}

		#region Search options

		SearchOptions SearchOptions
		{
			get
			{
				return Settings.Instance.PreviousSearchOptions ?? (Settings.Instance.PreviousSearchOptions = new SearchOptions());
			}
		}
		public bool CaseSensitive
		{
			get { return SearchOptions.CaseSensitive; }
			set
			{
				SearchOptions.CaseSensitive = value;
				RaisePropertyChanged("CaseSensitive");
			}
		}
		public bool UseRegex
		{
			get { return SearchOptions.UseRegex; }
			set
			{
				SearchOptions.UseRegex = value;
				RaisePropertyChanged("UseRegex");
			}
		}
		public bool StopOnCopy
		{
			get { return SearchOptions.StopOnCopy; }
			set
			{
				SearchOptions.StopOnCopy = value;
				RaisePropertyChanged("StopOnCopy");
			}
		}
		public bool SearchInRenames
		{
			get { return SearchOptions.SearchInRenames; }
			set
			{
				SearchOptions.SearchInRenames = value;
				RaisePropertyChanged("SearchInRenames");
			}
		}
		public bool SearchInContent
		{
			get { return SearchOptions.SearchInContent; }
			set
			{
				SearchOptions.SearchInContent = value;
				RaisePropertyChanged("SearchInContent");
			}
		}

		public string FilenameRegex
		{
			get
			{
				return SearchOptions.FilenameSubstring;
			}
			set
			{
				SearchOptions.FilenameSubstring = value;
				RaisePropertyChanged("FilenameSubstring");
			}
		}

		#endregion

		public long TreeRevision
		{
			get
			{
				return SearchOptions.TreeRevision ?? 0;
			}
			set
			{
				if (subversionSearcher != null)
				{

					long newVal = Math.Max(Math.Min(subversionSearcher.HeadRevision, value), 1);
					bool hasChanged = newVal != TreeRevision;
					SearchOptions.TreeRevision = newVal;
					if (hasChanged)
					{
						RaisePropertyChanged("TreeRevisionText");

						RepositoryOverview.BuildRepositoryOverview(subversionSearcher, HeadNodePath, TreeRevision);
					}
				}
			}
		}
		public string TreeRevisionText
		{
			get
			{
				if (TreeRevision == 0 || !SubversionSearcher.IsReady(subversionSearcher))
				{
					return "";
				}
				else
				{
					if (TreeRevision >= subversionSearcher.HeadRevision)
					{
						return String.Format("{0}(HEAD)", subversionSearcher.HeadRevision);
					}
				}
				return TreeRevision.ToString();
			}

			set
			{
				var a = value.Trim();

				long rev;
				if (!long.TryParse(a, out rev))
				{
					rev = long.MaxValue;
				}

				if (subversionSearcher != null)
				{
					if (rev > subversionSearcher.HeadRevision)
					{
						TreeRevision = subversionSearcher.HeadRevision;
					}
					else
					{
						TreeRevision = Math.Max(1, rev);
					}
					RaisePropertyChanged("TreeRevisionText");
				}
			}
		}

		public string HeadNodePath { get; private set; } = "";

		public string SearchString
		{
			get { return SearchOptions.Text ?? ""; }
			set
			{
				SearchOptions.Text = value;
				RaisePropertyChanged("SearchString");
			}
		}


		#region Author stuff

		public string AuthorsString
		{
			get
			{
				if (SearchOptions?.Authors != null)
					return String.Join(", ", SearchOptions.Authors);
				return "";
			}
			set
			{
				SearchOptions.Authors = (from a in value.Split(',') select a.Trim()).Distinct().ToList();
				RaisePropertyChanged("AuthorsString");
			}
		}

		public bool ExcludeAuthors
		{
			get
			{
				return SearchOptions.ExcludeAuthors;
			}
			set
			{
				if (SearchOptions.ExcludeAuthors != value)
				{
					SearchOptions.ExcludeAuthors = value;
					RaisePropertyChanged("ExcludeAuthors");
				}
			}
		}

		#endregion

		#region Date stuff

		private string dateFormat = "dd.MM.yyyy";
		public string StartRevisionText
		{
			get
			{
				if (SearchOptions.SearchFromRevision.RevisionType == SvnRevisionType.Number)
					return SearchOptions.SearchFromRevision.Revision.ToString();
				if (SearchOptions.SearchFromRevision.RevisionType == SvnRevisionType.Time)
					return SearchOptions.SearchFromRevision.Time.ToString();
				return "";
			}
			set
			{
				if (long.TryParse(value, out long res))
				{
					SearchOptions.SearchFromRevision = new SvnRevision(res);
				}
				else if (DateTime.TryParse(value, CultureInfo.CurrentCulture, DateTimeStyles.AssumeUniversal | DateTimeStyles.AdjustToUniversal, out DateTime dt))
				{
					SearchOptions.SearchFromRevision = new SvnRevision(dt);
				}
				else
				{
					MessageBox.Show(String.Format("Date or revision is in the wrong format."));
				}
			}
		}

		public string EndRevisionText
		{
			get
			{
				if (SearchOptions.SearchToRevision.RevisionType == SvnRevisionType.Number)
					return SearchOptions.SearchToRevision.Revision.ToString();
				if (SearchOptions.SearchToRevision.RevisionType == SvnRevisionType.Time)
					return SearchOptions.SearchToRevision.Time.ToString();
				if (SearchOptions.SearchToRevision.RevisionType == SvnRevisionType.Head)
					return "HEAD";
				return "";
			}
			set
			{
				if (value.ToUpper() == "HEAD")
				{
					SearchOptions.SearchToRevision = new SvnRevision(SvnRevisionType.Head);
				}
				else if (long.TryParse(value, out long res))
				{
					SearchOptions.SearchToRevision = new SvnRevision(res);
				}
				else if (DateTime.TryParse(value, CultureInfo.CurrentCulture, DateTimeStyles.AssumeUniversal | DateTimeStyles.AdjustToUniversal, out DateTime dt))
				{
					SearchOptions.SearchToRevision = new SvnRevision(dt);
				}
				else
				{
					MessageBox.Show(String.Format("Date or revision is in the wrong format.", dateFormat));
				}
			}
		}

		#endregion


		public ObservableCollection<string> RecentRepositories { get; set; }

		public string RepositoryUrl
		{
			get
			{
				return Settings.Instance.RepositoryUrl;
			}
			private set
			{
				Settings.Instance.RepositoryUrl = value;
				RaisePropertyChanged("RepositoryUrl");
			}
		}


		#region Progress Stuff

		private int _progressPercentage = 0;
		public int ProgressPercentage
		{
			get
			{
				return _progressPercentage;
			}
			set
			{
				_progressPercentage = value;
				RaisePropertyChanged("ProgressPercentage");
			}
		}

		private string _logMessage = "";
		public string LogMessage
		{
			get
			{
				return _logMessage;
			}
			set
			{
				_logMessage = value;
				RaisePropertyChanged("LogMessage");
			}
		}

		#endregion


		#region Button Commands

		public ICommand ButtonChangeRepository
		{
			get
			{
				return _buttonCommands.ContainsKey("repositoryChange") ? _buttonCommands["repositoryChange"] : (_buttonCommands["repositoryChange"] = new CommandHandler((obj) =>
				{
					Task t = new Task(() => { TryLoadRepository(RepositoryUrl); });
					t.Start();
				}, true));
			}
		}


		public ICommand ButtonSearchCommand
		{
			get
			{
				return _buttonCommands.ContainsKey("search") ? _buttonCommands["search"] : (_buttonCommands["search"] = new CommandHandler((obj) =>
				{
					if (searchTask != null && !searchTask.IsCompleted)
					{
						// cancelling
						if (subversionSearcher != null)
						{
							subversionSearcher.CancelSearch();
						}
					}
					searchTask = new Task(Search);
					searchTask.Start();
				}, true));
			}
		}


		public ICommand ButtonOpenInTortoise
		{
			get
			{
				return _buttonCommands.ContainsKey("openInTortoise") ? _buttonCommands["openInTortoise"] : (_buttonCommands["openInTortoise"] = new CommandHandler((obj) =>
				{

					if (FilePreview.OpenedFile != null)
					{
						OpenInTortoise(FilePreview.OpenedFile, true);
					}

				}, true));
			}
		}

		public ICommand ButtonPreRevCommand
		{
			get
			{
				return new CommandHandler((obj) =>
				{
					TreeRevision -= 1;
				}, true);
			}
		}

		public ICommand ButtonNextRevCommand
		{
			get
			{
				return new CommandHandler((obj) =>
				{
					TreeRevision += 1;
				}, true);
			}
		}


		#endregion


		/// <summary>
		/// Adds the current RepositoryUrl to the recent repositories list.
		/// Builds the RepositoryOverview
		/// This method has to be called from the main thread.
		/// </summary>
		void MakeTreeAndUpdateRepoUrl(SubversionSearcher subversionSearcher, string repoUrl)
		{
			if (SubversionSearcher.IsReady(subversionSearcher))
			{
				string repositoryUrlcp = repoUrl;

				try
				{
					string newHeadNodePath = subversionSearcher.GetLowestExistingHeadNodePath(repoUrl, subversionSearcher.HeadRevision);
					HeadNodePath = newHeadNodePath;
					repositoryUrlcp = Utils.JoinPaths(subversionSearcher.RepositoryUrl, newHeadNodePath);

					RepositoryOverview.BuildRepositoryOverview(subversionSearcher, HeadNodePath, subversionSearcher.HeadRevision);

				}
				catch (Exception ex)
				{
					Progress.ErrorLog(ex);
					MessageBox.Show(String.Format("Error: {0}", ex.Message));
				}

				if (RecentRepositories.Contains(repositoryUrlcp))
				{
					RecentRepositories.Remove(repositoryUrlcp);
				}

				RecentRepositories.Insert(0, repositoryUrlcp);
				while (RecentRepositories.Count > Settings.Instance.RepositoryHistoryLength)
				{
					RecentRepositories.RemoveAt(RecentRepositories.Count - 1);
				}

				RaisePropertyChanged("RecentRepositories");

				Settings.Instance.RecentRepositories = RecentRepositories.ToList();
				Settings.Instance.RepositoryUrl = repositoryUrlcp;

				RepositoryUrl = repositoryUrlcp;

				if (subversionSearcher.InSearch)
				{
					Progress.Log("Building repository overview..");
					TreeRevision = subversionSearcher.HeadRevision;
					RepositoryOverview.BuildRepositoryOverview(subversionSearcher, HeadNodePath, TreeRevision);
					Progress.Log("Ready");
				}
			}
		}


		/// <summary>
		/// Switches tree root to path at revision
		/// </summary>
		/// <param name="path"></param>
		/// <param name="revision"></param>
		public void SwitchTreeRoot(string path, long revision)
		{
			RepositoryOverview.BuildRepositoryOverview(subversionSearcher, path, revision);
			HeadNodePath = path;
			RepositoryUrl = subversionSearcher.RepositoryUrl + path;
		}


		/// <summary>
		/// Has to run asyncronously because it invokes methods in main thread
		/// </summary>
		/// <param name="repoUrl"></param>
		async void TryLoadRepository(string repoUrl)
		{
			if (!currentlyLoadingRepository.CompareAndSet(false, true))
			{
				return; // do nothing because one repository is already loading
			}

			_searchResultsViewModel.Reset();
			_repositoryOverviewViewModel.Reset();
			_filePreviewViewModel.Reset();

			if (repoUrl == null || repoUrl.Length == 0)
			{
				if (subversionSearcher != null)
				{
					subversionSearcher.Close();
					subversionSearcher = null;
				}
				return;
			}

			repoUrl = repoUrl.TrimEnd('/') + '/';

			if (SubversionSearcher.IsReady(subversionSearcher) && repoUrl.StartsWith(subversionSearcher.RepositoryUrl))
			{
				// were just in another directory of the same repository
				//_headNodePath = subversionSearcher.GetLowestExistingHeadNodePath(repoUrl, subversionSearcher.HeadRevision);
				App.Current.Dispatcher.Invoke(() => MakeTreeAndUpdateRepoUrl(subversionSearcher, repoUrl));
			}
			else
			{

				// load other repository

				// close the old one
				if (SubversionSearcher.IsReady(subversionSearcher))
				{
					subversionSearcher.Close();
					Progress.Log("Switching Repository...");
				}
				subversionSearcher = null;


				/// START trying to find credentials by and opening add credentials window if necessary
				Progress.Log("Finding credentials...");
				bool useCredentials = true;
				SubversionSearcher.AuthenticationInfo info = SubversionSearcher.HasCredentials(repoUrl);
				for (int i = 0; i < 4; i++)
				{

					if (info.Successful)
					{
						if (i == 0)
						{
							useCredentials = false;
						}
						 break;
					}
					else if (
						info.ThrownException != null && (
							info.ThrownException is SharpSvn.SvnAuthorizationException ||
							info.ThrownException is SharpSvn.SvnRepositoryIOForbiddenException ||
							info.ThrownException is SharpSvn.SvnAuthenticationException) ||
						info.ThrownException?.InnerException != null && (
							info.ThrownException.InnerException is SharpSvn.SvnAuthorizationException ||
							info.ThrownException.InnerException is SharpSvn.SvnRepositoryIOForbiddenException ||
							info.ThrownException.InnerException is SharpSvn.SvnAuthenticationException))
					{
						// trying to make sense of sharpsvn's exceptions
						// opening credentials window

						if (i == 0)
						{
							info = SubversionSearcher.CheckCredentials(repoUrl, Settings.Instance.Username, Settings.Instance.Password);
						}
						else
						{
							Progress.Log("Wrong credentials");
							var mrse = new ManualResetEvent(false);
							App.Current.Dispatcher.Invoke(() => { OpenCredentialsWindow(() => { mrse.Set(); }); });

							mrse.WaitOne();

							info = SubversionSearcher.CheckCredentials(repoUrl, Settings.Instance.Username, Settings.Instance.Password);
						}
					}
					else
					{
						Progress.Log(String.Format("{0}\r\nSee error.log", info.ExceptionMessage));
						break;
					}

				}
				// END trying  to find credentials


				if (info.Successful)
				{
					Progress.Log("Loading Repository");

					if (useCredentials)
					{
						// Use credentials from credentials window or file
						await Task.Run(() =>
						{
							try
							{
								subversionSearcher = new SubversionSearcher(RepositoryUrl, Settings.Instance.Username, Settings.Instance.Password);
							}
							catch (Exception ex)
							{
								Progress.Log("Failed to initialize. See error.log");
								Progress.ErrorLog(ex);
							}
						});
					}
					else
					{
						// Use credentials from tortoise
						await Task.Run(() =>
						{
							try
							{
								subversionSearcher = new SubversionSearcher(RepositoryUrl);
							}
							catch (Exception ex)
							{
								Progress.Log("Failed to initialize. See error.log");
								Progress.ErrorLog(ex);
							}
						});
					}

					App.Current.Dispatcher.Invoke(() => MakeTreeAndUpdateRepoUrl(subversionSearcher, repoUrl));

				}
			}

			if (!currentlyLoadingRepository.CompareAndSet(true, false))
			{
				// should never happen
			}
		}


		/// <summary>
		/// Callback method that the credentials window uses after the user has clicked OK on it
		/// </summary>
		/// <param name="crw">instance of credentials window</param>
		/// <param name="username">typed in username</param>
		/// <param name="password">typed in password</param>
		/// <param name="onRespond">will be called at the end of this method</param>
		public void CredentialsWindowResponse(SetCredentialsWindow crw, string username, string password, Action onRespond = null)
		{
			crw.Close();
			SetCredentialsWindow = null;
			if (username.Length == 0)
			{
				Settings.Instance.Username = "";
				Settings.Instance.Password = "";
			}
			else if (username != Settings.Instance.Username || password != Settings.Instance.Password)
			{
				Settings.Instance.Username = username;
				Settings.Instance.Password = password;
			}

			Settings.Instance.Username = Settings.Instance.Username;
			Settings.Instance.Password = Settings.Instance.Password;

			if (onRespond != null)
				onRespond();
		}


		public void Initialize()
		{

			Settings.Instance.RepositoryHistoryLength = Settings.Instance.RepositoryHistoryLength;
			RecentRepositories = new ObservableCollection<string>(Settings.Instance.RecentRepositories);
			RaisePropertyChanged("RecentRepositories");

			Progress.RegisterCallbackOnMajorChange(() =>
			{
				ProgressPercentage = Progress.GetProgressPercentage();
			});

			Progress.RegisterCallbackOnLogUpdate((message) =>
			{
				LogMessage = message;
			});


			if ((RepositoryUrl = Settings.Instance.RepositoryUrl) != "")
			{
				if (Settings.Instance.LoadPreviousRepositoryOnStartup)
				{
					Task t = new Task(() => { TryLoadRepository(RepositoryUrl); });
					t.Start();
				}
			}
		}

		public MainViewModel()
		{

		}

		~MainViewModel()
		{
			Settings.ClearTemporaryFiles();
		}


		public IList<CheckableItem> LoadHierarchy(string url, long revision, CheckableItem parent)
		{

			IList<CheckableItem> result = new List<CheckableItem>();

			if (subversionSearcher != null)
			{
				IList<bool> hasChildList;
				var children = subversionSearcher.GetChildrenInHierarchy(url, revision, out hasChildList, true);
				if (children != null)
				{
					for (int i = 0; i < children.Count; i++)
					{
						result.Add(new CheckableItem(parent, children[i].Item1, revision, children[i].Item2, this, hasChildList[i]));
					}
				}
			}

			return result;
		}

		public void OpenFile(OpenedFile file)
		{
			_filePreviewViewModel.OpenedFile = file;
		}


		void OpenCredentialsWindow(Action onRespond = null)
		{
			if (SetCredentialsWindow != null && SetCredentialsWindow.IsActive == false)
			{
				SetCredentialsWindow.Close();
				SetCredentialsWindow = null;
			}
			if (SetCredentialsWindow == null)
			{
				SetCredentialsWindow = new SetCredentialsWindow(this, "", "", onRespond);
				SetCredentialsWindow.DataContext = this;
				SetCredentialsWindow.Show();
			}
		}

		public void Search()
		{

			SearchOptions options = this.SearchOptions.DeepCopy();

			if (!SubversionSearcher.IsReady(subversionSearcher))
			{
				Progress.Log("Repository not loaded");
				return;
			}

			if (options.Text != "")
			{

				List<Tuple<string, bool>> nod = RepositoryOverview.GetSelectedNodes();
				if (nod.Count == 0 && FilenameRegex == "")
				{
					Progress.Log("No files specified");
					return;
				}

				if (UseRegex)
				{
					try
					{
						Regex rx = new Regex(options.Text);
					}
					catch (ArgumentException)
					{
						Progress.Log("Invalid regex");
						return;
					}
				}

				Progress.Log("Listing...");

				if (previousSelectedList != null)
				{
					int hashCode = 0;
					previousSelectedList.ForEach(s => hashCode += s.GetHashCode());
					nod.ForEach(s => hashCode -= s.GetHashCode());

					if (hashCode != 0)
					{
						previousSelectedList = nod;
						options.Files = previousNodeList = subversionSearcher.GetFullNodeList(nod, TreeRevision);
					}
					else
					{
						options.Files = previousNodeList;
					}
				}
				else
				{
					previousSelectedList = nod;
					options.Files = previousNodeList = subversionSearcher.GetFullNodeList(nod, TreeRevision);
				}

				SearchResults results = subversionSearcher.Search(options);

				if (results == null)
				{
					return; // search failed
				}

				if (!results.Successful)
				{
					string caption = "Search incomplete";
					string text = "Result might be incomplete. Some diffs could not be searched for whatever reason.\r\nWould you like to see the list of diffs that are still missing?";
					MessageBoxButton button = MessageBoxButton.YesNo;
					MessageBoxImage icon = MessageBoxImage.Warning;

					MessageBoxResult mbs = MessageBox.Show(text, caption, button, icon);
					if (mbs == MessageBoxResult.Yes)
					{
						try
						{
							string filepath = results.ErrorPath;
							if (System.IO.File.Exists(filepath))
							{
								Process.Start(filepath);
							}
						}
						catch (Exception e)
						{
							Progress.ErrorLog(e.ToString());
							MessageBox.Show("Something went wrong.. See error.log");
						}
					}
				}
				Progress.Log("Loading {0} results..", results.Files.Count);

				_searchResultsViewModel.SearchResults = results;

				Progress.Log(String.Format("Search finished after {0:F2}s", results.TotalTime.HasValue ? (results.TotalTime.Value / 1000).ToString() : "undefined"));
			}
			else
			{
				Progress.Log("Search text can not be empty");
			}
		}


		/// <summary>
		/// Gets a diff content from the the subversion searcher
		/// </summary>
		/// <param name="fd"></param>
		/// <returns></returns>
		public string GetFileContent(FoundDiff fd)
		{
			return subversionSearcher.ReadSingleDiff(fd.DiffInfo);
		}


		public void OpenFileFromTree(string path, long revision, bool openOpenWithWindow)
		{
			if (!SubversionSearcher.IsReady(subversionSearcher) || !subversionSearcher.PathExistsAtRevision(path, revision))
			{
				Progress.Log("Could not open File");
				return;
			}

			string filePath;
			if (!subversionSearcher.GetFileAtRevision(path, revision, out filePath))
			{
				Progress.Log("Could not fetch file from subversion server.");
				return;
			}

			if (!openOpenWithWindow)
			{
				try
				{
					Process.Start(filePath);
				}
				catch (Exception ex)
				{
					Progress.Log("Could not open file. see error.log");
					Progress.ErrorLog(ex);
				}
			}
		}

		public void OpenParentInExplorer(string path, long revision)
		{
			if (!SubversionSearcher.IsReady(subversionSearcher) || !subversionSearcher.PathExistsAtRevision(path, revision))
			{
				Progress.Log("Could not open File");
				return;
			}

			string filePath;
			if (!subversionSearcher.GetFileAtRevision(path, revision, out filePath))
			{
				Progress.Log("Could not fetch file from subversion server.");
				return;
			}

			try
			{
				System.Diagnostics.Process.Start(System.IO.Path.GetDirectoryName(filePath));
			}
			catch (Exception ex)
			{
				Progress.Log("Could not open file. see error.log");
				Progress.ErrorLog(ex);
			}
		}


		public void OpenInTortoise(OpenedFile openedFile, bool otherTask = false)
		{
			Action<OpenedFile> act = (of) =>
			{
				// implement check whether tortoise is installed and find out where

				string tortoisemerge = Utils.JoinPathsWin(Settings.Instance.TortoisePath, "TortoiseMerge.exe");

				if (System.IO.File.Exists(tortoisemerge) == false)
				{
					MessageBox.Show(String.Format("Tortoise was not found in {0} :(\nYou can change the path of your TortoiseMerge executable in the settings file ({1})", tortoisemerge, Settings.SettingsFilePath));
					return;
				}

				Progress.Log("Opening in tortoise...");

				string fileName = of.FileName;
				string filePath = of.FullPath;
				long leftRevision = Math.Max(Math.Max(of.Revision - 1, 0), of.PrevRevision);
				long rightRevision = of.Revision;

				try
				{

					string leftFilePath;
					bool leftExisting = subversionSearcher.GetFileAtRevision(filePath, leftRevision, out leftFilePath);

					string rightFilePath;
					bool rightExisting = subversionSearcher.GetFileAtRevision(filePath, rightRevision, out rightFilePath);

					ProcessStartInfo psi = new ProcessStartInfo();
					psi.FileName = tortoisemerge;

					//  /groupuuid:{6} omitted
					psi.Arguments = String.Format("/base:\"{0}\" /mine:\"{1}\" /basename:\"{2} Revision {3}\" /minename:\"{2} Revision {4}\" /basereflectedname:{5} /minereflectedname:{5} /readonly",
						leftFilePath,
						rightFilePath,
						fileName,
						leftRevision == 0 || !leftExisting ? "(nonexistent)" : leftRevision.ToString(),
						rightRevision,
						filePath);

					psi.UseShellExecute = false;

					Process.Start(psi);

				}
				catch (Exception ex)
				{
					Progress.ErrorLog(ex);
					MessageBox.Show(ex.Message);
				}

				Progress.Log("");
			};

			if (otherTask)
			{
				Task t = new Task(() => { act(openedFile); });
				t.Start();
			}
			else
			{
				act(openedFile);
			}
		}


		public bool TryShutdown()
		{
			Progress.Log("Shutting down...");
			if (subversionSearcher != null)
			{
				subversionSearcher.Close();
			}

			Settings.Save();
			return true;
		}
	}
}
