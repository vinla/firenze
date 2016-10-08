using System;
using System.Windows.Input;

namespace Firenze.Mvvm
{
    public class MvvmCommand : ICommand
    {
        private readonly Func<object, bool> _canExecuteDelegate;
        private readonly Action<object> _executeAction;

        public MvvmCommand(Action<object> executeAction)
            : this(null, executeAction)
        {
        }

        public MvvmCommand(Func<object, bool> canExecuteDelegate, Action<object> executeAction)
        {
            _canExecuteDelegate = canExecuteDelegate;
            _executeAction = executeAction;
        }

        public bool CanExecute(object parameter)
        {
            if (_canExecuteDelegate == null)
                return true;

            return _canExecuteDelegate(parameter);
        }

        protected virtual void OnCanExecuteChanged(EventArgs e)
        {
            if (CanExecuteChanged != null)
                CanExecuteChanged(this, e);
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            _executeAction(parameter);
        }
    }
}
