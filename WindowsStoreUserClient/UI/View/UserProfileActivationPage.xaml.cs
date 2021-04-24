using System;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;
using WindowsStore.Client.User.Common.ExtensionMethod;
using WindowsStore.Client.User.UI.Infrastructure;
using WindowsStore.Client.User.UI.View.Interface;
using WindowsStore.Client.User.UI.ViewModel;

namespace WindowsStore.Client.User.UI.View
{
    public sealed partial class UserProfileActivationPage : Page, IUserProfileActivationPage
    {
        public UserProfileActivationPageViewModel ViewModel { get; set; }

        public UserProfileActivationPage()
        {
            this.InitializeComponent();
            ViewModel = (UserProfileActivationPageViewModel)DataContext;
            ViewModel.View = this;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            // Remove SignIn & SignUp pages from BackStack
            Frame.BackStack.RemoveRange(item => item.SourcePageType == typeof(SignUpPage));
            Frame.BackStack.RemoveRange(item => item.SourcePageType == typeof(SignInPage));
        }


        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            UiManager.Instance.PageTitle = "ProfileActivation".Localize();
        }

        async Task IUserProfileActivationPage.ShowInvalidCodeMessageAsync()
        {
            await UiManager.Instance.ShowMessageAsync("VerificationCodeIsInvalid".Localize());
        }

        async Task IUserProfileActivationPage.ShowErrorOcurredMessageAsync()
        {
            await UiManager.Instance.ShowMessageAsync("ErrorOcurredWhileActivatingProfile".Localize());
        }

        async Task IUserProfileActivationPage.ShowActivationCodeSentMessageAsync()
        {
            await UiManager.Instance.ShowMessageAsync("ActivationCodeSent".Localize());
        }

        void IUserProfileActivationPage.NavigateToCatalogPage()
        {
            Frame.Navigate(typeof(CatalogPage));
        }

        private void verificationCodeTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ViewModel.ActivateProfileCommand.RaiseCanExecuteChanged(null);
        }

        private void verificationCodeTextBox_KeyDown(object sender, KeyRoutedEventArgs e)
        {
        }

        async Task IUserProfileActivationPage.ShowResendingCodeFailedMessageAsync()
        {
            await UiManager.Instance.ShowMessageAsync("ErrorOcurredWhileResendingActivationCode".Localize());
        }
    }
}
