using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    public class UserProfileActivationPageViewModel : ViewModelBase
    {
        private RelayCommand _activateProfileCommand;
        private RelayCommand _resendCodeCommand;
        private bool _showProgressRing;
        
        public IUserProfileActivationPage View { get; set; }
        public string VerificationCode { get; set; }
        public string UserName
        {
            get
            {
                return UserManager.Instance.StoredUserName;
            }
        }
        public bool ShowProgressRing {
            get
            {
                return _showProgressRing;
            }
            set
            {
                _showProgressRing = value;
                RaisePropertyChanged();
            }
        }
        public bool SendingActivationCode { get; set; }

        public UserProfileActivationPageViewModel()
        {

        }

        #region Activate Profile Command
        public RelayCommand ActivateProfileCommand
        {
            get
            {
                if (_activateProfileCommand == null)
                    _activateProfileCommand = new RelayCommand(async (object obj) => await ActivateProfileAsync(obj), CanActivateProfile);
                return _activateProfileCommand;
            }
        }

        private async Task ActivateProfileAsync(object obj)
        {
            try {
                var result = await UserManager.Instance.TryActivateAccountAsync(int.Parse(VerificationCode));
                if (!result) {
                    await View.ShowInvalidCodeMessageAsync();
                    return;
                }
                View.NavigateToCatalogPage();
            }
            catch {
                await View.ShowErrorOcurredMessageAsync();
            }
        }

        private bool CanActivateProfile(object obj)
        {
            int vc;
            return
                !string.IsNullOrEmpty(VerificationCode) &&
                VerificationCode.Length == 4 &&
                int.TryParse(VerificationCode, out vc);
        }
        #endregion

        #region Resend Activation Code Command
        public RelayCommand ResendCodeCommand
        {
            get
            {
                if (_resendCodeCommand == null)
                    _resendCodeCommand = new RelayCommand(async (object obj) => await ResendCodeAsync(obj), CanResendCode);
                return _resendCodeCommand;
            }
        }


        private async Task ResendCodeAsync(object obj)
        {
            try {
                ShowProgressRing = SendingActivationCode = true;
                ResendCodeCommand.RaiseCanExecuteChanged(null);
                await UserManager.Instance.ResendActivationCode();
                await View.ShowActivationCodeSentMessageAsync();
            }
            catch {
                await View.ShowResendingCodeFailedMessageAsync();
            }
            finally {
                ShowProgressRing = false;
                await Task.Delay(5000);
                SendingActivationCode = false;
                ResendCodeCommand.RaiseCanExecuteChanged(null);
            }
        }

        private bool CanResendCode(object obj)
        {
            return !SendingActivationCode;
        }
        #endregion

    }
}
