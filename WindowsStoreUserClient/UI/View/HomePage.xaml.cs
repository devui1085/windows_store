using System;
using System.Collections.ObjectModel;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using WindowsStore.Client.User.Common.ExtensionMethod;
using WindowsStore.Client.User.Common.Infrastructure;
using WindowsStore.Client.User.Common.PresentationModel;
using WindowsStore.Client.User.UI.Infrastructure;
using WindowsStore.Client.User.UI.View.Interface;
using WindowsStore.Client.User.UI.ViewModel;

namespace WindowsStore.Client.User.UI.View
{
    public sealed partial class HomePage : Page, IHomePage
    {
        public HomePageViewModel ViewModel { get; set; }
        DispatcherTimer _timer;

        public HomePage()
        {
            this.InitializeComponent();
            ViewModel = (HomePageViewModel)DataContext;
            ViewModel.View = this;

            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(8);
            _timer.Tick += _timer_Tick;
            _timer.Start();
        }

        private void _timer_Tick(object sender, object e)
        {
            var selectedIndex = flipView.SelectedIndex;
            var count = ((ObservableCollection<StoreApp>)flipView.ItemsSource).Count();
            if (count < 2 || selectedIndex == -1) return;
            flipView.SelectedIndex = (flipView.SelectedIndex + 1) % count;
        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            UiManager.Instance.PageTitle = "Home".Localize();
            await ViewModel.LoadAppsAsync();
        }

        private void showAllTopApplicationsHyperLink_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(CatalogPage), AppQueryParameters.TopFreeApplications());
        }

        private void showAllTopGamesHyperLink_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(CatalogPage), AppQueryParameters.TopFreeGames());
        }

        private void randomAppsListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            Frame.Navigate(typeof(AppDownloadPage), e.ClickedItem);
        }

        private void topGamesListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            Frame.Navigate(typeof(AppDownloadPage), e.ClickedItem);
        }

        private void topApplicationsListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            Frame.Navigate(typeof(AppDownloadPage), e.ClickedItem);
        }

        void IHomePage.ShowNetworkErrorMessage()
        {
            //modalMessage.Show(
            //    "NoInternetAccessMessage".Localize(),
            //    "ReTry".Localize(),
            //    async () =>
            //    {
            //        await ViewModel.LoadAppsAsync();
            //    });
        }

        void IHomePage.HideNetworkErrorMessage()
        {
            modalMessage.Hide();
        }

        public void SetFlipViewHeight()
        {
            if (ViewModel.FeaturedApps.Count() == 0) return;
            var image = ViewModel.FeaturedApps.First().BackgroundImage;
            var imageRatio = (float)image.PixelWidth / image.PixelHeight;
            flipView.Height = flipView.ActualWidth / imageRatio;
        }

        private void Page_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            SetFlipViewHeight();
        }
    }
}
