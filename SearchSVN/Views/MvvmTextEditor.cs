using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows;

using ICSharpCode.AvalonEdit;
using ICSharpCode.AvalonEdit.Highlighting;
using ICSharpCode.AvalonEdit.Search;

namespace SVNHistorySearcher.Views {
	public class MvvmTextEditor : TextEditor, INotifyPropertyChanged {
		public static DependencyProperty CaretOffsetProperty =
			DependencyProperty.Register("CaretOffset", typeof(int), typeof(MvvmTextEditor),
			// binding changed callback: set value of underlying property
			new PropertyMetadata((obj, args) => {
				MvvmTextEditor target = (MvvmTextEditor)obj;
				target.CaretOffset = (int)args.NewValue;
			})
		);

		public static DependencyProperty TextProperty =
			DependencyProperty.Register("Text", typeof(string), typeof(MvvmTextEditor),
			// binding changed callback: set value of underlying property
			new PropertyMetadata((obj, args) => {
				MvvmTextEditor target = (MvvmTextEditor)obj;
				target.Text = (string)args.NewValue;
			})
		);

		public static DependencyProperty HighlightingLanguageProperty =
			DependencyProperty.Register("HighlightingLanguage", typeof(string), typeof(MvvmTextEditor),
			// binding changed callback: set value of underlying property
			new PropertyMetadata((obj, args) => {
				MvvmTextEditor target = (MvvmTextEditor)obj;
				target.SyntaxHighlighting = HighlightingManager.Instance.GetDefinitionByExtension((string)args.NewValue);
			})
		);

		public static DependencyProperty HighlightedStringProperty =
			DependencyProperty.Register("HighlightedString", typeof(string), typeof(MvvmTextEditor),
			// binding changed callback: set value of underlying property
			new PropertyMetadata((obj, args) => {
				MvvmTextEditor target = (MvvmTextEditor)obj;
				target.HighlightedString = (string)args.NewValue;
			})
		);

		public static DependencyProperty UseRegexProperty =
			DependencyProperty.Register("UseRegex", typeof(bool), typeof(MvvmTextEditor),
			// binding changed callback: set value of underlying property
			new PropertyMetadata((obj, args) => {
				MvvmTextEditor target = (MvvmTextEditor)obj;
				target.UseRegex = (bool)args.NewValue;
			})
		);

		public new string Text {
			get { return base.Text; }
			set { base.Text = value; }
		}

		public new int CaretOffset {
			get { return base.CaretOffset; }
			set { base.CaretOffset = value; }
		}

		public string HighlightingLanguage {
			get { return hLang; }
			set { hLang = value; }
		}

		public string HighlightedString {
			set {
				_highlightedString = value;
				ReOpenSearchPanel();
			}
		}

		public bool UseRegex {
			set {
				_useRegex = value;
				ReOpenSearchPanel();
			}
		}

		public void ReOpenSearchPanel() {
			if (searchPanel == null) {
				searchPanel = SearchPanel.Install(this);
			}
			searchPanel.SearchPattern = _highlightedString;
			searchPanel.UseRegex = _useRegex;
			searchPanel.Open();
		}

		public int Length { get { return base.Text.Length; } }
		string hLang = ".txt";
		string _highlightedString = "";
		bool _useRegex = false;
		SearchPanel searchPanel;

		protected override void OnTextChanged(EventArgs e) {
			RaisePropertyChanged("Length");
			base.OnTextChanged(e);
		}

		public event PropertyChangedEventHandler PropertyChanged;
		public void RaisePropertyChanged(string info) {
			if(PropertyChanged != null) {
				PropertyChanged(this, new PropertyChangedEventArgs(info));
			}
		}

	}

}
