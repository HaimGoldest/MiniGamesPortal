using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Common.Interfaces;

namespace Common.Commands
{
    public abstract class BaseCommand : ICommand
    {
        protected BaseCommand(IViewModel viewModel)
        {
        }

        public abstract bool CanExecute(object parameter);

        public abstract void Execute(object parameter);

        public event EventHandler CanExecuteChanged;
    }
}
