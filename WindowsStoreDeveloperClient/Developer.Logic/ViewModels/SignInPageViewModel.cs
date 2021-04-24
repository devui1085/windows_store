
using System.Threading.Tasks;
using System;
using WindowsStore.Client.Developer.Common;
using WindowsStore.Client.Developer.Common.Enum;
using WindowsStore.Client.Developer.Logic.Models;
using WindowsStore.Client.Developer.Logic.ServiceInterface;
using WindowsStore.Client.Developer.Logic.ViewModelInterface;
using Prism.Commands;
using Prism.Windows.AppModel;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;

namespace WindowsStore.Client.Developer.Logic.ViewModels
{
    public class SignInPageViewModel : ViewModelBase, ISignInViewModel
    {
        #region Services

        private readonly IAccountService _accountService;
        private readonly IAlertMessageService _alertMessageService;
        private readonly IResourceLoader _resourceLoader;
        private readonly INavigationService _navigationService;
        #endregion

        #region Constructor


        public SignInPageViewModel(IAccountService accountService, IAlertMessageService alertMessageService,
            IResourceLoader resourceLoader, INavigationService navigationService)
        {
            _accountService = accountService;
            _alertMessageService = alertMessageService;
            _resourceLoader = resourceLoader;
            _navigationService = navigationService;
            _saveCredentials = true;

            SignInCommand = DelegateCommand.FromAsyncHandler(SignInAsync, CanSignIn);
            GoBackCommand = new DelegateCommand(Close);
            SignUpNavigationCommand = new DelegateCommand(NavigateToSignUp);

           // CheckUserSavedCredential();
        }

        public async void CheckUserSavedCredential(string defaultPage)
        {
            var logOnResult = await _accountService.TrySignInOnSavedCredentialsAsync();

            if (logOnResult !=null)
            {
                //_userName = _accountService.SignedInUser.PrimaryEmail;
                NavigateUserOnSignedInResult(logOnResult);
                //IsNewSignIn = false;
            }
            else
            {
                _navigationService.Navigate(defaultPage, null);
            }

        }

        #endregion

        #region Fields

        private string _userName;
        private string _password;
        private bool _isOpened;
        private bool _saveCredentials;
        private bool _isSignInInvalid;
        private Action _successAction;

        #endregion

        #region Properties

        [RestorableState]
        public string UserName
        {
            get { return _userName; }

            set
            {
                if (SetProperty(ref _userName, value))
                {
                    SignInCommand.RaiseCanExecuteChanged();
                }
            }
        }

        [RestorableState]
        public string Password
        {
            get { return _password; }

            set
            {
                if (SetProperty(ref _password, value))
                {
                    SignInCommand.RaiseCanExecuteChanged();
                }
            }
        }

        [RestorableState]
        public bool IsOpened
        {
            get { return _isOpened; }
            private set { SetProperty(ref _isOpened, value); }
        }

        public bool IsNewSignIn { get; set; }

        //[RestorableState]
        //public bool SaveCredentials
        //{
        //    get { return _saveCredentials; }
        //    set { SetProperty(ref _saveCredentials, value); }
        //}

        [RestorableState]
        public bool IsSignInInvalid
        {
            get { return _isSignInInvalid; }
            private set { SetProperty(ref _isSignInInvalid, value); }
        }
        #endregion

        #region Methods

        #region ISignInViewModel

        public void Open(Action successAction)
        {
            IsOpened = true;
            _successAction = successAction;
        }

        #endregion

        #endregion

        #region Commands

        public DelegateCommand GoBackCommand { get; private set; }

        public DelegateCommand SignInCommand { get; }

        public DelegateCommand SignUpNavigationCommand { get; private set; }

        #endregion

        #region Actions

        private bool CanSignIn()
        {
            return !string.IsNullOrEmpty(UserName) && !string.IsNullOrEmpty(Password);
        }

        private async Task SignInAsync()
        {
          //  var signinSuccessfull = false;

            var result = await _accountService.SignInUserAsync(UserName, Password, _saveCredentials);
        //    signinSuccessfull = result.SignedIn;

            NavigateUserOnSignedInResult(result);
        }

        private async void NavigateUserOnSignedInResult(LogOnResult result)
        {
            if (result.SignedIn)
            {
                IsSignInInvalid = false;

                switch (result.AccountStatus)
                {
                    case UserAccountStatus.Activated:
                        _navigationService.ClearHistory();
                        _navigationService.Navigate(ViewNames.Dashboard, null);
                        break;
                    case UserAccountStatus.NotActivated:
                        _navigationService.Navigate(ViewNames.ConfirmRegistration, null);
                        break;
                    case UserAccountStatus.Blocked:
                        await _alertMessageService.ShowAsync(_resourceLoader.GetString("AccountBlockedByAdmin"), string.Empty,
                            DialogCommands.CloseDialogCommand);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                Close();
            }
            else
            {
                IsSignInInvalid = true;

                await _alertMessageService.ShowAsync(_resourceLoader.GetString("InvalidUserNameOrPassword"), _resourceLoader.GetString("Error"), DialogCommands.CloseDialogCommand);
            }
        }

        private void Close()
        {
            IsOpened = false;
        }

        private void NavigateToSignUp()
        {
            _navigationService.Navigate(ViewNames.SignUp, null);
        }

        #endregion
    }
}
