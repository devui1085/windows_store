using System;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using WindowsStore.Client.User.Common.ExtensionMethod;
using WindowsStore.Client.User.Service.ApplicationService;
using WindowsStore.Client.User.UI.Infrastructure;
using WindowsStore.Client.User.UI.View.Interface;
using WindowsStore.Client.User.UI.ViewModel;
using WindowsStore.Client.User.Common.Infrastructure;

namespace WindowsStore.Client.User.UI.View
{
    public sealed partial class MainPage : Page, IMainPage
    {
        public MainPageViewModel ViewModel { get; set; }
        public bool _areInteractiveControlsEnabled { get; set; }

        public MainPage()
        {
            this.InitializeComponent();
            ViewModel = DataContext as MainPageViewModel;
            ViewModel.View = this;
            _areInteractiveControlsEnabled = true;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            UiManager.Instance.Initialize(ViewModel);
            UiManager.Instance.IsSubFrameMaximized = true;
            if (string.IsNullOrEmpty(UserManager.Instance.StoredUserName))
            {
                ShowSignInButton("SignIn".Localize());
            }
        }

        private void closePaneButton_Click(object sender, RoutedEventArgs e)
        {
            splitView.IsPaneOpen = false;
        }

        private void hamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            splitView.IsPaneOpen = !splitView.IsPaneOpen;
        }

        private void subPageFrame_Navigated(object sender, NavigationEventArgs e)
        {
            UiManager.Instance.HideLoading();
        }

        void IMainPage.ShowLoading()
        {
            progressRing.Visibility = Visibility.Visible;
        }

        void IMainPage.HideLoading()
        {
            progressRing.Visibility = Visibility.Collapsed;
        }

        private void goToHomePageButton_Click(object sender, RoutedEventArgs e)
        {
            splitView.IsPaneOpen = false;
            subPageFrame.Navigate(typeof(HomePage));
        }

        private void goToSettingsPageButton_Click(object sender, RoutedEventArgs e)
        {
            splitView.IsPaneOpen = false;
            subPageFrame.Navigate(typeof(SettingsPage));
        }

        private void goToApplicationsPageButton_Click(object sender, RoutedEventArgs e)
        {
            splitView.IsPaneOpen = false;
            subPageFrame.Navigate(typeof(CatalogPage), AppQueryParameters.TopFreeApplications());
        }

        private void goToGamesPageButton_Click(object sender, RoutedEventArgs e)
        {
            splitView.IsPaneOpen = false;
            subPageFrame.Navigate(typeof(CatalogPage), AppQueryParameters.TopFreeGames());
        }

        private void goToDownloadsPageButton_Click(object sender, RoutedEventArgs e)
        {
            splitView.IsPaneOpen = false;
            subPageFrame.Navigate(typeof(DownloadsPage));
        }

        private void goToAboutPaasteelPageButton_Click(object sender, RoutedEventArgs e)
        {
            splitView.IsPaneOpen = false;
            subPageFrame.Navigate(typeof(AboutPaasteelPage));
        }

        async Task IMainPage.NavigateToDownloadsPageForMandatoryUpdateAsync()
        {
            await UiManager.Instance.ShowMessageAsync("MandatoryUpdateIsAvailableMessage".Localize(), "MandatoryUpdate".Localize());
            UiManager.Instance.AreMainPageInteractiveControlsEnabled = false;
            UiManager.Instance.IsSubFrameMaximized = false;
            subPageFrame.Navigate(typeof(DownloadsPage));
        }

        private void goToLoginPageButton_Click(object sender, RoutedEventArgs e)
        {
            splitView.IsPaneOpen = false;

            if (!UserManager.Instance.IsSignedIn)
            {
                subPageFrame.Navigate(typeof(SignInPage));
            }
            else if (!UserManager.Instance.IsProfileActivated)
            {
                subPageFrame.Navigate(typeof(UserProfileActivationPage));
            }
            else if (UserManager.Instance.IsSignedIn)
            {
                subPageFrame.Navigate(typeof(UserProfilePage));
            }
        }

        public void ShowSignInButton(string content)
        {
            signInButton.Visibility = Visibility.Visible;
            signInButton.Content = content;
        }

        private void subPageFrame_Navigating(object sender, NavigatingCancelEventArgs e)
        {

        }

        void IMainPage.NavigateToHomePage()
        {
            UiManager.Instance.IsSubFrameMaximized = false;
            subPageFrame.Navigate(typeof(HomePage));
        }

        void IMainPage.ShowSignInButton(string content)
        {
            throw new NotImplementedException();
        }

        void IMainPage.ShowModalMessage(string message,string firstActionText, EventHandler firstActionClickEventHandler)
        {
            modalMessage.Show(message, firstActionText, firstActionClickEventHandler);
        }

        void IMainPage.HideModalMessage()
        {
            modalMessage.Hide();
        }

        bool IMainPage.AreInteractiveControlsEnabled
        {
            set
            {
                hamburgerButton.IsEnabled = value;
                goToDownloadsPageButton.IsEnabled = value;
                splitView.IsPaneOpen = false;
                _areInteractiveControlsEnabled = value;
                currentDownloadsCountTextBlock.Visibility = value ? Visibility.Visible : Visibility.Collapsed;
            }
            get
            {
                return _areInteractiveControlsEnabled;
            }
        }


    }
}
