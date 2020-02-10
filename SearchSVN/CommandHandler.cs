using System;
using System.Windows.Input;

namespace SVNHistorySearcher
{
	public class CommandHandler : ICommand
	{
		private Action<object> _action;
		private bool _canExecute;
		public CommandHandler(Action<object> action, bool canExecute)
		{
			_action = action;
			_canExecute = canExecute;
		}

		public void SetCanExecute(bool value)
		{
			_canExecute = value;
		}

		public bool CanExecute(object parameter)
		{
			return _canExecute;
		}

#pragma warning disable
		public event EventHandler CanExecuteChanged;
#pragma warning restore

		public void Execute(object parameter)
		{
			_action(parameter);
		}
	}

}
