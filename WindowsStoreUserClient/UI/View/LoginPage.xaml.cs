using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using UI;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using WindowsStore.Client.User.Common.ExtensionMethod;
using WindowsStore.Client.User.UI.Infrastructure;
using WindowsStore.Client.User.UI.View.Interface;
using WindowsStore.Client.User.UI.ViewModel;


namespace WindowsStore.Client.User.UI.View
{
    public sealed partial class LoginPage : Page, ILoginPage
    {
        public LoginPageViewModel ViewModel { get; set; }
        public LoginPage()
        {
            this.InitializeComponent();
            ViewModel = (LoginPageViewModel)DataContext;
            ViewModel.View = this;
        }

        private void signupHyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(SignupPage));
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

        void ILoginPage.ShowWaiting(bool show)
        {
            progressRing.IsActive = show;
            emailTextBox.IsEnabled =
            passwordBox.IsEnabled =
            signInButton.IsEnabled = !show;
        }

        public async Task ShowInvalidCredentialsMessageAsync()
        {
            MessageDialog dlg = new MessageDialog("InvalidUsernameOrPassword".Localize());
            await dlg.ShowAsync();
        }

        public void NavigateToCatalogPage()
        {
            Frame.Navigate(typeof(CatalogPage));
        }
    }
}
