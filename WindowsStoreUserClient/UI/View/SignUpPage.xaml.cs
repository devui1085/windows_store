using System;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using WindowsStore.Client.User.Common.ExtensionMethod;
using WindowsStore.Client.User.UI.Infrastructure;
using WindowsStore.Client.User.UI.View.Interface;
using WindowsStore.Client.User.UI.ViewModel;

namespace WindowsStore.Client.User.UI.View
{
    public sealed partial class SignUpPage : Page, ISignUpPage
    {
        public SignUpPageViewModel ViewModel { get; set; }

        public SignUpPage()
        {
            this.InitializeComponent();
            ViewModel = (SignUpPageViewModel)DataContext;
            ViewModel.View = this;
        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            base.OnNavigatingFrom(e);
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            UiManager.Instance.PageTitle = "SignUp".Localize();
        }


        private async void signupButton_Click(object sender, RoutedEventArgs e)
        {
            string msg = null;

            if (msg == null && !emailTextBox.Text.Trim().IsValidEmail()) {
                msg = "InvalidEmail";
            }

            if (msg == null && passwordBox.Password.Length < 5) {
                msg = "InvalidPassword";
            }

            if (msg == null && confirmPasswordBox.Password != passwordBox.Password) {
                msg = "InvalidConfirmPaasword";
            }

            if (msg != null) {
                await UiManager.Instance.ShowMessageAsync(msg.Localize());
                return;
            }

            await ViewModel.RegisterUserAsync();
        }

        async Task ISignUpPage.ShowEmailIsNotAvailableMessageAsync()
        {
            await UiManager.Instance.ShowMessageAsync("EmailIsNotAvailableForRegistration".Localize());
        }

        async Task ISignUpPage.ShowErrorMessageAsync()
        {
            await UiManager.Instance.ShowMessageAsync("ErrorOccuredInUserRegistration".Localize());
        }

        void ISignUpPage.NavigateToActivationPage()
        {
            Frame.Navigate(typeof(UserProfileActivationPage), ViewModel.NaturalPerson);
        }
    }
}
