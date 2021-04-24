using System;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using WindowsStore.Client.User.Common.ExtensionMethod;
using WindowsStore.Client.User.UI.Infrastructure;
using WindowsStore.Client.User.UI.View.Interface;
using WindowsStore.Client.User.UI.ViewModel;


namespace WindowsStore.Client.User.UI.View
{
    public sealed partial class SignInPage : Page, ISignInPage
    {
        public SignInPageViewModel ViewModel { get; set; }
        public SignInPage()
        {
            this.InitializeComponent();
            ViewModel = (SignInPageViewModel)DataContext;
            ViewModel.View = this;
        }

        private void signupHyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(SignUpPage));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            UiManager.Instance.PageTitle = "SignIn".Localize();
        }

        private void passwordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            ViewModel.SignInCommand.RaiseCanExecuteChanged(null);
        }

        private void emailTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ViewModel.SignInCommand.RaiseCanExecuteChanged(null);
        }

        void ISignInPage.ShowWaiting(bool show)
        {
            progressRing.IsActive = show;
            emailTextBox.IsEnabled =
            passwordBox.IsEnabled =
            signInButton.IsEnabled = !show;
        }

        public async Task ShowInvalidCredentialsMessageAsync()
        {
            await UiManager.Instance.ShowMessageAsync("InvalidUsernameOrPassword".Localize());
        }

        public void NavigateToCatalogPage()
        {
            Frame.Navigate(typeof(CatalogPage));
        }
    }
}
