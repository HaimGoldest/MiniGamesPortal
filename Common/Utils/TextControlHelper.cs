using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Common.Utils
{
    public static class TextControlHelper
    {
        public static void UserInputTextBox_OnPreviewKeyDown(object sender, KeyEventArgs e)
        {
            var textBox = (FrameworkElement) sender;

            if (e.Key == Key.Enter)
            {
                // Move to a parent that can take focus
                FrameworkElement parent = (FrameworkElement)textBox.Parent;
                while (parent != null && !((IInputElement)parent).Focusable)
                {
                    parent = (FrameworkElement)parent.Parent;
                }

                DependencyObject scope = FocusManager.GetFocusScope(textBox);
                FocusManager.SetFocusedElement(scope, parent);
            }
        }

    }
}
