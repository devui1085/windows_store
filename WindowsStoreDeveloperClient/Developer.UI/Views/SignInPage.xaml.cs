using Windows.System;
using Windows.UI.Xaml;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace WindowsStore.Client.Developer.UI.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SignInPage : NavigationAwarePage
    {
        public SignInPage()
        {
            this.InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
           
        }

        private void RegisterUser_Click(object sender, RoutedEventArgs e)
        {
            //Frame.Navigate(typeof(RegisterUserView));
        }

        private void TxtPassword_KeyDown(object sender, Windows.UI.Xaml.Input.KeyRoutedEventArgs e)
        {
            if (e.Key == VirtualKey.Enter)
            {
                SignInButton.Command?.Execute(null);
            }
        }

        private void ForgotPasswordHyperLinkButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
