using System;
using System.Windows.Input;

namespace Framework.MVVM
{
   public class DelegateCommand :ICommand
    {
        private readonly Action _whattoExecute;
        private readonly Func<bool> _whentoExecute;
        public DelegateCommand(Action what, Func<bool> when)
        {
            _whattoExecute = what;
            _whentoExecute = when;
        }
        public bool CanExecute(object parameter)
       {
            return _whentoExecute();
        }

       public void Execute(object parameter)
       {
            _whattoExecute();
        }

       public event EventHandler CanExecuteChanged;
    }
}
