using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HBM.Command
{
    public class RelayCommand : ICommand
    {
        Action DoWork;
        Action<object> DoWork_;

        public RelayCommand(Action dowork)
        {
            this.DoWork = dowork;
        }

        public RelayCommand(Action<object> dowork)
        {
            this.DoWork_ = dowork;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            DoWork_(parameter);
        }
    }
}