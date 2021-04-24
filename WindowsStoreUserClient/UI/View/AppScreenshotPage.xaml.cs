using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using WindowsStore.Client.User.Common.PresentationModel;
using WindowsStore.Client.User.UI.Infrastructure;
using WindowsStore.Client.User.UI.ViewModel;

namespace WindowsStore.Client.User.UI.View
{
    public sealed partial class AppScreenshotPage : Page
    {
        public AppScreenshotPageViewModel ViewModel { get; set; }

        public AppScreenshotPage()
        {
            this.InitializeComponent();
            ViewModel = (AppScreenshotPageViewModel)DataContext;
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            // Change visual state
            UiManager.Instance.IsSubFrameMaximized = true;

            //
            dynamic parameter = e.Parameter;
            ViewModel.StoreApp = (StoreApp)parameter.StoreApp;
            ViewModel.ScreenshotIndex = (int)parameter.ScreenshotIndex;
            await ViewModel.LoadScreenshotsAsync();
        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            base.OnNavigatingFrom(e);
            UiManager.Instance.IsSubFrameMaximized = false;
        }
    }
}
