using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Pizza_Palace_Coding_Problem.ViewModels
{
    /// <summary>
    /// For Handling Custom Events in MVVM-Pattern.
    /// </summary>
    public class CommandHandler : ICommand
    {
        private Action<object> _action;
        private bool _canExecute;

        public CommandHandler(Action<object> action, bool canExecute)
        {
            _action = action;
            _canExecute = canExecute;
        }
        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter)
        {
            return _canExecute;
        }
        public void Execute(object parameter)
        {
            _action(parameter);
        }
    }
}
