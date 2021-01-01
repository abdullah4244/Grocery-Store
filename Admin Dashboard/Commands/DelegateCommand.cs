using System;
using System.Collections.Generic;
using System.Text;

using System.Windows.Input;

namespace Admin_Dashboard.Commands
{
    class DelegateCommand : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }

            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        private Action<object> _execute;
        private Func<object, bool> _canExecute;


        public DelegateCommand(Action<object> e,Func<object,bool> c)
        {
            this._execute = e;
            this._canExecute = c;
              }
        public bool CanExecute(object parameter)
        {
            return this._canExecute(parameter as string);
        }

        public void Execute(object parameter)
        {
            this._execute(parameter);
        }
    }
}
