using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlackJackApp.ViewModel;
using Common.Commands;
using Common.Interfaces;

namespace BlackJackApp.Commands
{
    public class HitCommand : BaseBlackJackCommand
    {
        public HitCommand(IViewModel viewModel) : base(viewModel)
        {
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            ViewModel.Hit(ViewModel.User);
        }
    }
}
