using System.Dynamic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using WindowsStore.Client.User.Common.ExtensionMethod;
using WindowsStore.Client.User.Common.PresentationModel;
using WindowsStore.Client.User.UI.Infrastructure;
using WindowsStore.Client.User.UI.ViewModel;

namespace WindowsStore.Client.User.UI.View
{
    public sealed partial class AppDownloadPage : Page
    {
        public AppDownloadPageViewModel ViewModel { get; set; }

        public AppDownloadPage()
        {
            this.InitializeComponent();
            ViewModel = (AppDownloadPageViewModel)this.DataContext;
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            var app = (StoreApp)e.Parameter;
            ViewModel.StoreApp = app;
            if (app.LatestVersion == null) app.LatestVersion = new AppVersion();
            if (app.AppCategory == null) app.AppCategory = new AppCategory();
            await ViewModel.InitilizePageAsync();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            UiManager.Instance.PageTitle = "InstallApp".Localize();
        }

        private void screenshotViewer_ItemClick(object sender, ItemClickEventArgs e)
        {
            dynamic parameter = new ExpandoObject();
            parameter.StoreApp = ViewModel.StoreApp;
            parameter.ScreenshotIndex = ((Screenshot)e.ClickedItem).Index;
            Frame.Navigate(typeof(AppScreenshotPage), parameter);
        }
    }
}
