using System.Windows;
using BlackJackApp;
using BlackJackApp.View;
using MiniGamesPortal.ViewModel;

namespace MiniGamesPortal.View
{
    /// <summary>
    /// Interaction logic for PortalWindow.xaml
    /// </summary>
    public partial class PortalWindow : Window
    {
        public PortalWindow()
        {
            InitializeComponent();
            DataContext = new PortalViewModel();
        }

        private void StartBlackJack_OnClick(object sender, RoutedEventArgs e)
        {
            BlackJackWindow blackJack = new BlackJackWindow();
            blackJack.Show();
        }
    }
}
