using System.Windows;
using System.Windows.Input;
using BlackJackApp.ViewModel;
using Common.Utils;

namespace BlackJackApp.View
{
    /// <summary>
    /// Interaction logic for BlackJackWindow.xaml
    /// </summary>
    public partial class BlackJackWindow : Window
    {
        public BlackJackWindow()
        {
            InitializeComponent();
            DataContext = new BlackJackViewModel();
        }

        private void UIElement_OnPreviewKeyDown(object sender, KeyEventArgs e)
        {
            TextControlHelper.UserInputTextBox_OnPreviewKeyDown(sender,e);
        }

    }
}
