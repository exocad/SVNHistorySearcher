using SVNHistorySearcher.Models;
using System;
using System.Collections.Generic;

namespace SVNHistorySearcher.ViewModels
{
	public class RepositoryOverviewViewModel : ViewModel
	{
		MainViewModel mainViewModel;

		IList<CheckableItem> _items;
		public IList<CheckableItem> Items
		{
			get { return _items; }
			set
			{
				_items = value;
				RaisePropertyChanged("Items");
			}
		}


		public RepositoryOverviewViewModel(MainViewModel mainViewModel)
		{
			this.mainViewModel = mainViewModel;
		}

		public List<Tuple<string, bool>> GetSelectedNodes()
		{
			List<Tuple<string, bool>> files = new List<Tuple<string, bool>>();

			if (Items != null)
			{
				foreach (CheckableItem c in Items)
				{
					c.GetCheckedNodes(ref files);
				}
			}
			return files;
		}

		public void Reset()
		{
			Items = null;
		}


		private long currentTreeRevision = -1;
		private string currentTreeHeadPath = null;
		private SubversionSearcher currentSubversionSearcherUsedForTree = null;

		/// <summary>
		/// Builds the Repository overview at a certain revision
		/// </summary>
		/// <param name="subversionSearcher">SubversionSearcher object to use</param>
		/// <param name="path">Path relative to RepositoryUrl of subversionSearcher</param>
		/// <param name="revision">Revision at which to build</param>
		public void BuildRepositoryOverview(SubversionSearcher subversionSearcher, string path, long revision)
		{
			if (!SubversionSearcher.IsReady(subversionSearcher))
			{
				Progress.DebugLog("Tried to build repository overview without an initialized SubversionSearcher");
				return;
			}

			if (revision == currentTreeRevision && path == currentTreeHeadPath &&
				object.ReferenceEquals(currentSubversionSearcherUsedForTree, subversionSearcher) &&
				this.Items != null && this.Items.Count != 0)
			{
				return;
			}

			if (path == null || subversionSearcher.PathExistsAtRevision(path, revision) == false)
			{
				Progress.Log("{0} does not exist at revision {1}", path, revision);
				this.Items = new List<CheckableItem> { };
				return;
			}


			IList<string> expandedNodes = new List<string>();
			IList<string> checkedNodes = new List<string>();

			if (path == currentTreeHeadPath)
			{
				// keeping the nodes that were expanded expanded
				if (this.Items != null && this.Items.Count > 0)
				{
					Queue<CheckableItem> togo = new Queue<CheckableItem>();

					foreach (var item in this.Items)
					{
						togo.Enqueue(item);
					}

					while (togo.Count > 0)
					{
						var item = togo.Dequeue();

						if (item.IsExpanded)
						{
							expandedNodes.Add(item.Path.Length > path.Length ? item.Path.Substring(path.Length).TrimStart('/') : "");

							foreach (var c in item.Children)
							{
								togo.Enqueue(c);
							}
						}
					}
				}
				else
				{
					expandedNodes.Add("");
				}

				// keeping the nodes that were checked
				if (this.Items != null && this.Items.Count > 0)
				{
					Queue<CheckableItem> togo = new Queue<CheckableItem>();

					foreach (var item in this.Items)
					{
						togo.Enqueue(item);
					}

					while (togo.Count > 0)
					{
						var item = togo.Dequeue();

						if (item.IsChecked == true)
						{
							checkedNodes.Add(item.Path.Length > path.Length ? item.Path.Substring(path.Length).TrimStart('/') : "");
						}
						else if (item.IsChecked == null)
						{
							foreach (var c in item.Children)
							{
								togo.Enqueue(c);
							}
						}
					}
				}
			}
			else
			{
				expandedNodes.Add("");
			}

			CheckableItem rootFolder = new CheckableItem(null, path, revision, SharpSvn.SvnNodeKind.Directory, mainViewModel);
			rootFolder.Children = mainViewModel.LoadHierarchy(path, revision, rootFolder);

			foreach (var item in expandedNodes)
			{
				var ci = rootFolder.GetItemByRelativePath(item);
				if (ci != null)
				{
					ci.IsExpanded = true;
				}
			}

			foreach (var item in checkedNodes)
			{
				var ci = rootFolder.GetItemByRelativePath(item);
				if (ci != null)
				{
					ci.IsChecked = true;
				}
			}


			this.Items = new List<CheckableItem> { rootFolder };

			Progress.Log("Tree loaded at revision {0}", revision);
			currentTreeRevision = revision;
			currentTreeHeadPath = path;
			currentSubversionSearcherUsedForTree = subversionSearcher;
		}
	}
}
