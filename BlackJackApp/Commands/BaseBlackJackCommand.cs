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
    public abstract class BaseBlackJackCommand : BaseCommand
    {
        protected readonly BlackJackViewModel ViewModel;

        protected BaseBlackJackCommand(IViewModel viewModel) : base(viewModel)
        {
            ViewModel = (BlackJackViewModel)viewModel;
        }
        
    }
}
