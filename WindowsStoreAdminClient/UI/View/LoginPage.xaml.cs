using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using WindowsStore.Client.Admin.Common.ExtensionMethod;
using WindowsStore.Client.Admin.UI.View.Interface;
using WindowsStore.Client.Admin.UI.ViewModel;
using WindowsStore.Client.Admin.UI.Infrastructure.ExtensionMethod;

namespace WindowsStore.Client.Admin.UI.View
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

        private async void loginButton_Click(object sender, RoutedEventArgs e)
        {
            if(ValidateInputs())
            {
                await ViewModel.LoginAsync();
            }
        }

        private bool ValidateInputs()
        {
            bool inputsAreValid = true;
            string msg = "";

            if (!emailTextBox.Text.IsValidEmail())
            {
                msg = "EnterValidEmail".Localize();
                inputsAreValid = false;
            }
            if (inputsAreValid && passwordBox.Password.Length == 0)
            {
                msg = "EnterPassword".Localize();
                inputsAreValid = false;
            }

            if (!inputsAreValid)
            {
                MessageDialog dlg = new MessageDialog(msg);
                dlg.ShowAsync();
            }

            return inputsAreValid;
        }

        void ILoginPage.NavigateToHomePage()
        {
            ViewModel.Password = "";
            Frame.Navigate(typeof(EditNaturalPersonPage), ViewModel);
        }

        void ILoginPage.ShowLoginFailedMessage()
        {
            MessageDialog msg = new MessageDialog("LoginFailed".Localize());
            msg.ShowAsync();
        }
    }
}
