using System.Threading.Tasks;
using WindowsStore.Client.Developer.Common;
using WindowsStore.Client.Developer.Logic.ServiceInterface;
using Prism.Commands;
using Prism.Windows.AppModel;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;

namespace WindowsStore.Client.Developer.Logic.ViewModels
{
    public class ConfirmRegistrationPageViewModel :ViewModelBase
    {
        #region Constructor

        public ConfirmRegistrationPageViewModel(IAlertMessageService alertMessageService,INavigationService navigationService,IAccountService accountService,IClientDeveloperService clientDeveloperService,IResourceLoader resourceLoader)
        {
            _navigationService = navigationService;
            _accountService = accountService;
            _clientDeveloperService = clientDeveloperService;
            _alertMessageService = alertMessageService;
            _resourceLoader = resourceLoader;

            _activationCommandEnabled = true;
            _resendActivationCodeCommandEnabled = true;

            ActivateAccountCommand = DelegateCommand.FromAsyncHandler(ActivateAccountAsync,
                CanActivateAccount);
            ResendActivationCodeCommand = DelegateCommand.FromAsyncHandler(ResendActivationCodeAsync,
                CanResendActivationCode);
        }
        #endregion

        #region Services

        private INavigationService _navigationService;
        private IAccountService _accountService;
        private readonly IClientDeveloperService _clientDeveloperService;
        private IAlertMessageService _alertMessageService;
        private IResourceLoader _resourceLoader;
        #endregion

        #region Fields

        private bool _activationCommandEnabled;
        private bool _resendActivationCodeCommandEnabled;
        private bool _activationCodeIsSent;
        #endregion

        #region Properties    

        public string ActivationCode { get; set; }

        public bool ActivationCodeIsSent
        {
            get { return _activationCodeIsSent; }
            set { SetProperty(ref _activationCodeIsSent,value); }
        }
        #endregion

        #region Methods

        #endregion

        #region Commands
        public DelegateCommand ActivateAccountCommand { get; }
        public DelegateCommand ResendActivationCodeCommand { get; }
        #endregion

        #region Actions

        private async Task ActivateAccountAsync()
        {
            _activationCommandEnabled = false;
            try
            {
                int activationCode;

                if (int.TryParse(ActivationCode?.Trim(), out activationCode))
                {
                    // call service
                    var result =
                        await
                            _clientDeveloperService.TryActivateAccountAsync(_accountService.SignedInUser.PrimaryEmail,
                                activationCode);

                    if (result)
                        _navigationService.Navigate(ViewNames.Dashboard, null);
                    else
                        await
                            _alertMessageService.ShowAsync(_resourceLoader.GetString("InvalidActivationCode"), null,
                                DialogCommands.CloseDialogCommand);
                }
                else
                {
                    await
                          _alertMessageService.ShowAsync(_resourceLoader.GetString("InvalidActivationCode"), null,
                              DialogCommands.CloseDialogCommand);
                }

            }
            finally
            {
                 _activationCommandEnabled = true;
            }
        }

        private bool CanActivateAccount()
        {
            return _activationCommandEnabled;
        }

        private async Task ResendActivationCodeAsync()
        {
            _resendActivationCodeCommandEnabled = false;

            var result = await _clientDeveloperService.ResendActivationCodeAsync(_accountService.SignedInUser.PrimaryEmail);

            if (result)
                ActivationCodeIsSent = true;
            else
                await _alertMessageService.ShowAsync(_resourceLoader.GetString("GeneralErrorMessage"), _resourceLoader.GetString("ErrorOnActivation"), DialogCommands.CloseDialogCommand);
        }

        private bool CanResendActivationCode()
        {
            return _resendActivationCodeCommandEnabled;
        }

        #endregion
    }
}
