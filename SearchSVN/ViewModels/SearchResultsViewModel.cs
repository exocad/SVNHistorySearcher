using SVNHistorySearcher.Models;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace SVNHistorySearcher.ViewModels
{
	public class SearchResultsViewModel : ViewModel
	{

		MainViewModel mainViewModel;

		private ICommand _selectionChanged;
		private Object _selectedItem = null;
		SearchResults _searchResults;

		public IList<FoundFile> Items
		{
			get
			{
				return SearchResults != null ? SearchResults.Files : null;
			}
		}

		public SearchResults SearchResults
		{
			get { return _searchResults; }
			set
			{
				if (value != null)
				{
					if (value.Files.Count <= 50)
					{
						foreach (var e in value.Files)
						{
							e.IsExpanded = true;
						}
					}
				}
				_searchResults = value;
				RaisePropertyChanged("ExpandResults");
				RaisePropertyChanged("Items");
			}
		}

		public ICommand ChangedSelection
		{
			get { return _selectionChanged; }
			set { _selectionChanged = value; }
		}

		public Object SelectedItem
		{
			get { return _selectedItem; }
			set
			{
				_selectedItem = value;

				if (value is FoundDiffWithColorSolution)
				{
					_selectedItem = ((FoundDiffWithColorSolution)value).FoundDiff;
				}

				if (_selectedItem is FoundFile)
				{
					mainViewModel.OpenFile(new OpenedFile((FoundFile)_selectedItem, 0));
				}
				else if (_selectedItem is FoundDiff)
				{
					FoundDiff fd = (FoundDiff)_selectedItem;

					if (fd.Content == null)
					{
						fd.Content = mainViewModel.GetFileContent(fd);
					}

					mainViewModel.OpenFile(new OpenedFile(fd, 0));
				}

				RaisePropertyChanged("SelectedItem");
			}
		}

		public SearchResultsViewModel(MainViewModel mainViewModel)
		{
			this.mainViewModel = mainViewModel;
		}

		public void Reset()
		{
			SearchResults = null;
		}
	}
}
