using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using WindowsStore.Client.User.Common.Enum;
using WindowsStore.Client.User.Common.ExtensionMethod;
using WindowsStore.Client.User.Common.Infrastructure;
using WindowsStore.Client.User.Service.ApplicationService;
using WindowsStore.Client.User.UI.Infrastructure;
using WindowsStore.Client.User.UI.View.Interface;
using WindowsStore.Client.User.UI.ViewModel;

namespace WindowsStore.Client.User.UI.View
{
    public sealed partial class CatalogPage : Page, ICatalogPage
    {
        public CatalogPageViewModel ViewModel { get; set; }
        public CatalogPage()
        {
            this.InitializeComponent();
            ViewModel = (CatalogPageViewModel)DataContext;
            ViewModel.View = this;
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            ViewModel.AppQueryParameters = (AppQueryParameters)e.Parameter;
            UiManager.Instance.PageTitle = ViewModel.AppQueryParameters.AppType == AppType.Application ?
                "Applications".Localize() : "Game".Localize();
            ViewModel.RestoreState();
            await appsGridView.LoadMoreItemsAsync();
            if (UserManager.Instance.IsSignedIn) {
                Frame.BackStack.RemoveRange(item =>
                    item.SourcePageType == typeof(UserProfileActivationPage) || item.SourcePageType == typeof(SignInPage));
            }
        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            base.OnNavigatingFrom(e);
            ViewModel.SaveState();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            //UiManager.Instance.PageTitle = "Applications".Localize();
            //if (ViewModel.StoreApps.Count == 0)
            //    await appsGridView.LoadMoreItemsAsync();
        }

        private void appsGridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            Frame.Navigate(typeof(AppDownloadPage), e.ClickedItem);
        }

        void ICatalogPage.ShowNetworkErrorMessage()
        {
            UiManager.Instance.ShowModalMessage(
                "NoInternetAccessMessage".Localize(),
                "ReTry".Localize(),
                modalMessageFirstActionClicked);
        }

        void ICatalogPage.HideNetworkErrorMessage()
        {
            UiManager.Instance.HideModalMessage();
        }

        void modalMessageFirstActionClicked(object sender, EventArgs e)
        {
            var task = appsGridView.LoadMoreItemsAsync();
        }
    }
}
