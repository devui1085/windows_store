using Windows.UI.Xaml.Controls;
using WindowsStore.Client.User.UI.ViewModel;

namespace WindowsStore.Client.User.UI.View
{
    public sealed partial class SettingsPage : Page
    {
        public SettingsPageViewModel ViewModel { set; get; }

        public SettingsPage()
        {
            this.InitializeComponent();
            ViewModel = DataContext as SettingsPageViewModel;
        }
    }
}
