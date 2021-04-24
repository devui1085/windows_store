using System;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using WindowsStore.Client.Admin.Common.ExtensionMethod;
using WindowsStore.Client.Admin.UI.ViewModel;
using WindowsStore.Client.Admin.UI.Infrastructure.ExtensionMethod;

namespace WindowsStore.Client.Admin.UI.View
{
    public sealed partial class EditNaturalPersonPage : Page
    {
        public EditNaturalPersonPageViewModel ViewModel{ get; set; }

        public EditNaturalPersonPage()
        {
            this.InitializeComponent();
            ViewModel = (EditNaturalPersonPageViewModel)DataContext;
        }

        private async void okButton_Click(object sender, RoutedEventArgs e)
        {
            if (await ValidateInputsAsync())
            {
                await ViewModel.CommitAsync();
            }
        }

        private async Task<bool> ValidateInputsAsync()
        {
            string msg = null;

            if (firstNameTextBox.Text.Length < 2)
                msg = "EnterValidFirstName".Localize();
            else if (lastNameTextBox.Text.Length < 2)
                msg = "EnterValidLastName".Localize();
            else if (primaryEmailTextBox.Text.IsValidEmail())
                msg = "EnterValidEmail".Localize();
            else if (sexualityComboBox.SelectedItem == null)
                msg = "SelectSexuality".Localize();
            else if (passwordBox.Password.Length < 5)
                msg = "EnterValidPassword".Localize();
            else if (passwordBox.Password != confirmPasswordBox.Password)
                msg = "PasswordConfirmMismatch".Localize();

            if (msg != null)
            {
                MessageDialog dlg = new MessageDialog(msg);
                await dlg.ShowAsync();
            }
            return msg != null;
        }
    }
}
