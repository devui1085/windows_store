using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using WindowsStore.Client.User.Service.ApplicationService;
using WindowsStore.Client.User.UI.Infrastructure;
using WindowsStore.Client.User.UI.ViewModel;

namespace WindowsStore.Client.User.UI.View
{
    public sealed partial class DownloadsPage : Page
    {
        public DownloadsPageViewModel ViewModel { get; set; }

        public DownloadsPage()
        {
            this.InitializeComponent();
            ViewModel = (DownloadsPageViewModel)DataContext;
        }

        private async void Page_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            await ViewModel.DownloadManager.InitializeAsync();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            if (DeviceRegistrationService.Instance.IsMandatoryUpdateAvailable) {
                Frame.BackStack.Clear();
            }
        }
    }
}
