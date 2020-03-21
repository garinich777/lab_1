using System;
using System.Windows.Input;

namespace lab_1.ViewModel
{
    internal class DelegateCommand : ICommand
    {
        private Action<object> execute;
        Func<object, bool> canExecute;

        public DelegateCommand(Action<object> execute, Func<object, bool> canExecute)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public DelegateCommand(Action<object> executeAction) : this(executeAction, null) { }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            if (canExecute != null)
                return canExecute(parameter);
            return true;
        }

        public void Execute(object parameter)
        {
            execute?.Invoke(parameter);
        }
    }
}