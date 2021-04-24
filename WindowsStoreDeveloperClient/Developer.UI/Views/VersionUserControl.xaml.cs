using System.Text.RegularExpressions;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace WindowsStore.Client.Developer.UI.Views
{
    public sealed partial class VersionUserControl : UserControl
    {
        public VersionUserControl()
        {
            this.InitializeComponent();
        }

        private void MajorTextBox_Paste(object sender, TextControlPasteEventArgs e)
        {
            if (!IsTextAllowed(MajorTextBox.Text))
            {
                e.Handled = true;
            }
        }

        private static bool IsTextAllowed(string text)
        {
            Regex regex = new Regex("[^0-9.-]+"); //regex that matches disallowed text
            return !regex.IsMatch(text);
        }

        private void TextBox_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if ((e.Key >= Windows.System.VirtualKey.Number0 && e.Key <= Windows.System.VirtualKey.Number9)
                || (e.Key >= Windows.System.VirtualKey.NumberPad0 && e.Key <= Windows.System.VirtualKey.NumberPad9)
                || e.Key == Windows.System.VirtualKey.Tab 
                || e.Key == Windows.System.VirtualKey.Back
                )
            {
                e.Handled = false;
                //Value = $"{MajorTextBox.Text}.{MinorTextBox.Text}.{BuildTextBox.Text}.0";
            }
            else
                e.Handled = true;
        }
    }
}
