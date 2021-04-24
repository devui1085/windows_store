using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UI;
using Windows.UI.Xaml.Data;
using WindowsStore.Client.User.Common.ExtensionMethod;
using WindowsStore.Client.User.Common.Infrastructure;
using WindowsStore.Client.User.Common.PresentationModel;
using WindowsStore.Client.User.Service.ApplicationService;
using WindowsStore.Client.User.Service.Local;
using WindowsStore.Client.User.UI.Infrastructure;
using WindowsStore.Client.User.UI.Infrastructure.ExtensionMethod;
using WindowsStore.Client.User.UI.View.Interface;

namespace WindowsStore.Client.User.UI.ViewModel
{
    public class SignInPageViewModel : ViewModelBase
    {
        RelayCommand _signInCommand;
        public ISignInPage View { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public SignInPageViewModel()
        {

        }

        #region Sign In Command
        public RelayCommand SignInCommand
        {
            get
            {
                if (_signInCommand == null)
                    _signInCommand = new RelayCommand(async (object obj) => await SignInAsync(obj), CanSignIn);
                return _signInCommand;
            }
        }

        private async Task SignInAsync(object obj)
        {
            View.ShowWaiting(true);
            try {
                await UserManager.Instance.SignInAsync(Email, Password);
                if (UserManager.Instance.IsSignedIn)
                    View.NavigateToCatalogPage();
                else
                    await View.ShowInvalidCredentialsMessageAsync();
            }
            catch {
                await UiManager.ShowMessageAsync("NoInternetAccessMessage".Localize());
            }

            View.ShowWaiting(false);
        }

        private bool CanSignIn(object obj)
        {
            return
                !string.IsNullOrEmpty(Email) &&
                !string.IsNullOrEmpty(Password) &&
                Email.IsValidEmail() &&
                Password.Length >= 5;
        }
        #endregion


    }
}
