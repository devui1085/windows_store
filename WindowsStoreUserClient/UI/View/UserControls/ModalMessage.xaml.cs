using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace WindowsStore.Client.User.UI.View.UserControls
{
    public sealed partial class ModalMessage : UserControl
    {
        EventHandler _firstActionClickEventHandler;

        public ModalMessage()
        {
            this.InitializeComponent();
        }

        public void Show(string message, string firstActionText, EventHandler firstActionClickEventHandler)
        {
            errorMessageTextBlock.Text = message;
            firstActionButton.Content = firstActionText;
            _firstActionClickEventHandler = firstActionClickEventHandler;
            this.Visibility = Visibility.Visible;
        }

        public void Hide()
        {
            this.Visibility = Visibility.Collapsed;
        }

        private void firstActionButton_Click(object sender, RoutedEventArgs e)
        {
            if (_firstActionClickEventHandler != null) {
                _firstActionClickEventHandler(this, null);
            }
        }
    }
}
