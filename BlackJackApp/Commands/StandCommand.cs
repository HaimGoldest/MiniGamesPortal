using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Interfaces;

namespace BlackJackApp.Commands
{
    public class StandCommand :BaseBlackJackCommand
    {
        public StandCommand(IViewModel viewModel) : base(viewModel)
        {
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            ViewModel.Stand();
        }
    }
}
