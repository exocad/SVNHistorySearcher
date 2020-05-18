using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using ICSharpCode.AvalonEdit.CodeCompletion;
using ICSharpCode.AvalonEdit.Folding;
using ICSharpCode.AvalonEdit.Highlighting;
using ICSharpCode.AvalonEdit.Search;

using SVNHistorySearcher.Models;
using SVNHistorySearcher.ViewModels;

namespace SVNHistorySearcher
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{

		public MainWindow()
		{
			InitializeComponent();
		}

		private void TextBox_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
		{
			SelectAll(sender);
		}
		private void TextBox_GotMouseCapture(object sender, MouseEventArgs e)
		{
			SelectAll(sender);
		}
		private void SelectAll(object sender)
		{
			if (sender is TextBox)
			{
				((TextBox)sender).SelectAll();
			}
		}

		private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			((ViewModels.MainViewModel)DataContext).TryShutdown();
		}

		private void FoundDiff_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			try
			{
				ContentControl cc = (ContentControl)sender;
				WrapPanel wp = (WrapPanel)cc.Content;
				var fd = (FoundDiffWithColorSolution)cc.DataContext;

				MainViewModel mvm = (MainViewModel)this.DataContext;
				OpenedFile of = new OpenedFile(fd.FoundDiff, 0);
				mvm.OpenInTortoise(of, true);
				mvm.OpenFile(of);
			}
			catch
			{

			}
		}

		private void TextBox_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Enter || e.Key == Key.Tab)
			{
				ApplyRevisionTextChanged((TextBox)sender);
			}
		}

		private void ApplyRevisionTextChanged(TextBox sender)
		{
			var mvm = ((ViewModels.MainViewModel)DataContext);
			mvm.TreeRevisionText = sender.Text;
		}

		/// <summary>
		/// initiates search when pressing enter
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void SearchTextOnKeyDownHandler(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Return)
			{
				if(sender is TextBox)
				{
					var tb = (TextBox)sender;
					
					MainViewModel mvm = (MainViewModel)this.DataContext;
					mvm.SearchString = tb.Text;
					mvm.ButtonSearchCommand.Execute(null);
				}
			}
		}

		private void RepoUrlBox_KeyDown(object sender, KeyEventArgs e)
		{
			if(e.Key == Key.Enter)
			{
				ButtonLoadRepository.Command.Execute(null);
			}
		}
	}
}
