using System;
using System.Windows.Input;

namespace TouchableCard.MVVM
{
	public class DelegateCommand : ICommand
	{
		readonly Action _execute;
		readonly Predicate<object> _canExecute;

		public DelegateCommand(Action execute, Predicate<object> canExecute)
		{
			if (execute == null)
				throw new NullReferenceException("execute can not null");

			_execute = execute;
			_canExecute = canExecute;
		}

		public DelegateCommand(Action execute)
		{
			if (execute == null)
				throw new NullReferenceException("execute can not null");

			_execute = execute;
		}

		public event EventHandler CanExecuteChanged
		{
			add { CommandManager.RequerySuggested += value; }
			remove { CommandManager.RequerySuggested -= value; }
		}

		public bool CanExecute(object parameter)
		{
			return _canExecute == null ? true : _canExecute(parameter);
		}

		public void Execute(object parameter)
		{
			_execute?.Invoke();
		}
	}

	public class DelegateCommand<T> : ICommand
	{
		readonly Action<T> _execute;
		readonly Predicate<object> _canExecute;

		public DelegateCommand(Action<T> execute, Predicate<object> canExecute)
		{
			if (execute == null)
				throw new NullReferenceException("execute can not null");

			_execute = execute;
			_canExecute = canExecute;
		}

		public DelegateCommand(Action<T> execute)
		{
			if (execute == null)
				throw new NullReferenceException("execute can not null");

			_execute = execute;
		}

		public event EventHandler CanExecuteChanged
		{
			add { CommandManager.RequerySuggested += value; }
			remove { CommandManager.RequerySuggested -= value; }
		}

		public bool CanExecute(object parameter)
		{
			return _canExecute == null ? true : _canExecute(parameter);
		}

		public void Execute(object parameter)
		{
			_execute.Invoke((T)parameter);
		}
	}
}
