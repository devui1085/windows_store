using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace WindowsStore.Client.Developer.UI.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SignUpPage : NavigationAwarePage
    {
        //RegisterUserViewModel ViewModel;

        public SignUpPage()
        {
            this.InitializeComponent();
            //    ViewModel = (RegisterUserViewModel)DataContext;
            //     ViewModel.View = this;
        }

        private void GoHome_Click(object sender, RoutedEventArgs e)
        {
            //Frame.Navigate(typeof(SignInPage));
        }

        private async void submitButton_Click(object sender, RoutedEventArgs e)
        {
            //if (!ValidateForm()) return;
            //await ViewModel.RegisterUserCommandAsync();
            //Frame.Navigate(typeof(ActivateAccountView), emailTextBox.Text.Trim());
        }

        //private bool ValidateForm()
        //{
            //bool validFirstName, validLastName, validPassword, validEmail = true;
            //firstNameValidationTextBlock.Visibility = (validFirstName = firstNameTextBox.Text.Length >= 3) ? Visibility.Collapsed : Visibility.Visible;
            //lastNameValidationTextBlock.Visibility = (validLastName = lastNameTextBox.Text.Length >= 3) ? Visibility.Collapsed : Visibility.Visible;
            //passwordValidationTextBlock.Visibility = (validPassword = passwordBox.Password.Length >= 5) ? Visibility.Collapsed : Visibility.Visible;
            //emailValidationTextBlock.Text  = (validEmail = emailTextBox.Text.IsValidEmail()) ? "" : "PleaseEnterAValidEmail".Localize();
            //return (validFirstName && validLastName && validEmail && validPassword && ViewModel.EmailIsAvailableForRegistration);
        //}

        private async void emailTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            //if (emailTextBox.Text.IsValidEmail())
            //{
            //    var capturedEmail = emailTextBox.Text;
            //    await ViewModel.CheckEmailForAvalablityAsync();
            //    if (capturedEmail == emailTextBox.Text)
            //    {
            //        emailValidationTextBlock.Text = (ViewModel.EmailIsAvailableForRegistration ?
            //            "EmailIsAvailable" : "EmailIsNotAvailableForRegistration").Localize();
            //    }
            //}
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            //sexualityComboBox.SelectedIndex = 0;
        }
    }
}
