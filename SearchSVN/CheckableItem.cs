using SVNHistorySearcher.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace SVNHistorySearcher
{
	public class CheckableItem : ViewModels.ViewModel
	{

		MainViewModel mainViewModel;

		CheckableItem _parent;
		public CheckableItem Parent
		{
			get
			{
				return _parent;
			}
			set
			{
				_parent = value;
			}
		}


		private bool _isExpanded = false;
		public bool IsExpanded
		{
			get
			{
				return _isExpanded;
			}
			set
			{
				if (_isExpanded != value)
				{
					if (value)
					{
						LoadChildrenIfNecessary();
						if (Children != null)
						{
							foreach (var e in Children)
							{
								e.LoadChildrenIfNecessary();
							}
						}
					}
					_isExpanded = value;
					RaisePropertyChanged("IsExpanded");
				}
			}
		}


		private IList<CheckableItem> _children;
		public IList<CheckableItem> Children
		{
			get
			{
				return _children;
			}
			set
			{
				_children = value;
				RaisePropertyChanged("Children");
			}
		}

		private bool _isFile = false;
		public bool IsFile
		{
			get
			{
				return _isFile;
			}
		}

		private bool _isFolder = false;
		public bool IsFolder
		{
			get
			{
				return _isFolder;
			}
		}

		private bool? _isChecked = false;
		public bool? IsChecked
		{
			get
			{
				return _isChecked;
			}
			set
			{
				if (_isChecked != value)
				{
					SetIsChecked(value);

					if (this.Parent != null)
					{
						Parent.Update();
					}
				}
			}
		}

		private string _text;
		public string Text
		{
			get
			{
				return _text;
			}
		}

		private string _path;
		public string Path
		{
			get { return _path; }
		}

		public string Name
		{
			get
			{
				return System.IO.Path.GetFileName(_path);
			}
		}

		private long _revision;
		public long Revision
		{
			get { return _revision; }
		}


		public ICommand OpenFile
		{
			get
			{
				return new CommandHandler((obj) =>
				{
					mainViewModel.OpenFileFromTree(Path, Revision, false);
				}, true);
			}
		}

		public ICommand OpenFileWith
		{
			get
			{
				return new CommandHandler((obj) =>
				{
					mainViewModel.OpenFileFromTree(Path, Revision, true);
				}, true);
			}
		}

		public ICommand OpenParentInExplorer
		{
			get
			{
				return new CommandHandler((obj) =>
				{
					mainViewModel.OpenParentInExplorer(Path, Revision);
				}, true);
			}
		}

		public ICommand SetAsTreeRoot
		{
			get
			{
				return new CommandHandler((obj) =>
				{
					mainViewModel.SwitchTreeRoot(Path, Revision);
				}, true);
			}
		}

		private bool loaded = false;

		public CheckableItem(CheckableItem parent, string path, long revision, SharpSvn.SvnNodeKind nodeKind, MainViewModel mvm, bool fakeChildren = true)
		{
			_path = path.Trim('/');
			_revision = revision;
			_parent = parent;
			mainViewModel = mvm;

			if (_path == "")
			{
				_text = "/";
			}
			else
			{
				_text = System.IO.Path.GetFileName(_path);
			}

			if (nodeKind != SharpSvn.SvnNodeKind.File && nodeKind != SharpSvn.SvnNodeKind.SymbolicLink)
			{
				if (fakeChildren)
				{
					Children = new ObservableCollection<CheckableItem>() { new CheckableItem(true) };
				}
				else
				{
					Children = new ObservableCollection<CheckableItem>();
				}
				_isFile = false;
			}
			else
			{
				_isFile = true;
			}

			if (nodeKind == SharpSvn.SvnNodeKind.Directory)
			{
				_isFolder = true;
			}
		}

		public CheckableItem(bool fake)
		{

		}

		// sets state according to children
		public void Update()
		{
			if (_children != null)
			{
				bool? val = false;
				bool first = true;

				foreach (CheckableItem c in _children)
				{
					if (c._isChecked != null)
					{

						if (first)
						{
							val = c._isChecked;
							first = false;
						}
						else if (c._isChecked != val)
						{
							val = null;
						}

					}
					else
					{
						val = null;
						break;
					}
				}

				if (val != _isChecked)
				{
					_isChecked = val;
					if (Parent != null)
					{
						Parent.Update();
					}

					RaisePropertyChanged("IsChecked");
				}

			}
		}

		/// <summary>
		/// Gets CheckableItem relative to this. Only works for children/grandchildren
		/// </summary>
		/// <param name="relpath">path relative to this checkable items path. slashes are trimmed</param>
		/// <returns>null if there is no Item with this relative path</returns>
		public CheckableItem GetItemByRelativePath(string relpath)
		{

			var split = relpath.Trim('/').Split('/');

			if (split[0] == "")
			{
				return this;
			}
			else
			{
				LoadChildrenIfNecessary();

				foreach (var c in Children)
				{
					if (c.Name == split[0])
					{
						if (split.Length > 1)
						{
							return c.GetItemByRelativePath(String.Join("/", split, 1, split.Length - 1));
						}
						else
						{
							return c;
						}
					}
				}
			}

			return null;
		}


		public void SetIsChecked(bool? value)
		{
			this._isChecked = value;
			if (_children != null)
			{
				foreach (CheckableItem c in _children)
				{
					c.SetIsChecked(value);
				}
			}

			RaisePropertyChanged("IsChecked");

		}


		public CheckableItem this[string s]
		{
			get
			{
				if (_children != null)
				{
					foreach (CheckableItem c in _children)
					{
						if (c.Text == s)
						{
							return c;
						}
					}
				}

				return null;
			}
			set
			{
				if (this[s] == null)
				{
					if (_children == null)
					{
						_children = new ObservableCollection<CheckableItem>();
					}
					_children.Add(value);
				}
			}
		}

		public void GetCheckedNodes(ref List<Tuple<string, bool>> nodes)
		{
			if (_isChecked != false)
			{

				if (_isChecked == true)
				{
					// Add recursivly
					nodes.Add(new Tuple<string, bool>(this._path, this._children != null));
				}
				else
				{
					//nodes.Add(new Tuple<string, bool>(this._path, false));

					if (this._children != null)
					{
						foreach (CheckableItem c in _children)
						{
							c.GetCheckedNodes(ref nodes);
						}
					}
				}
			}
		}


		public void LoadChildrenIfNecessary()
		{
			if (!loaded)
			{
				loaded = true;
				_children = mainViewModel.LoadHierarchy(_path, _revision, this);

				foreach (CheckableItem c in _children)
				{
					if (this.IsChecked != null)
					{
						c._isChecked = this._isChecked;
					}
				}

				Children = _children.OrderBy(i => i.Text).OrderBy(i => i.IsFile).ToList<CheckableItem>();
			}
		}
	}
}
