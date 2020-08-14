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
using System.Windows.Shapes;
using SVNHistorySearcher.ViewModels;


namespace SVNHistorySearcher.Views
{
	/// <summary>
	/// Interaction logic for SetCredentialsWindow.xaml
	/// </summary>
	public partial class SetCredentialsWindow : Window
	{
		MainViewModel mvm;

		Action<(bool cancelled, string username, string password)> OnRespond;

		bool clickedOk = false;

		public SetCredentialsWindow(MainViewModel mvm, string initialUsername, string initialPassword, Action<(bool cancelled, string username, string password)> onRespond = null)
		{
			InitializeComponent();

			this.Closing += SetCredentialsWindow_Closing;

			this.mvm = mvm;
			this.OnRespond = onRespond;

			TB_username.Text = initialUsername;
			TB_password.Password = initialPassword;

			TB_username.Focus();
		}

		private void SetCredentialsWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			OnRespond?.Invoke((!clickedOk, TB_username.Text, TB_password.Password));
		}

		private void ButtonCancel_Click(object sender, RoutedEventArgs e)
		{
			this.Close();
		}

		private void ButtonOk_Click(object sender, RoutedEventArgs e)
		{
			clickedOk = true;
			this.Close();
		}

		private void TB_password_GotFocus(object sender, KeyboardFocusChangedEventArgs e)
		{
			TB_password.SelectAll();
		}
		private void TB_password_GotFocus(object sender, MouseEventArgs e)
		{
			TB_password.SelectAll();
		}

		private void TB_username_GotFocus(object sender, KeyboardFocusChangedEventArgs e)
		{
			TB_username.SelectAll();
		}
		private void TB_username_GotFocus(object sender, MouseEventArgs e)
		{
			TB_username.SelectAll();
		}
	}
}
