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


namespace SVNHistorySearcher.Views {
	/// <summary>
	/// Interaction logic for SetCredentialsWindow.xaml
	/// </summary>
	public partial class SetCredentialsWindow : Window {
		MainViewModel mvm;

		Action OnRespond;

		public SetCredentialsWindow(MainViewModel mvm, string username, string password, Action onRespond = null) {
			InitializeComponent();

			this.mvm = mvm;
			this.OnRespond = onRespond;

			TB_username.Text = username;
			TB_password.Password = password;
		}

		private void ButtonCancel_Click(object sender, RoutedEventArgs e) {
			mvm.SetCredentialsWindow = null;
			this.Close();
		}

		private void ButtonOk_Click(object sender, RoutedEventArgs e) {
			mvm.CredentialsWindowResponse(this, TB_username.Text, TB_password.Password, OnRespond);
		}

		private void TB_password_GotFocus(object sender, KeyboardFocusChangedEventArgs e) {
			TB_password.SelectAll();
		}
		private void TB_password_GotFocus(object sender, MouseEventArgs e) {
			TB_password.SelectAll();
		}

		private void TB_username_GotFocus(object sender, KeyboardFocusChangedEventArgs e) {
			TB_username.SelectAll();
		}
		private void TB_username_GotFocus(object sender, MouseEventArgs e) {
			TB_username.SelectAll();
		}
	}
}
