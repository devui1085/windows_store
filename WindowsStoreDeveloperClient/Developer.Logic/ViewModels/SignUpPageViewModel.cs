
using System.Threading.Tasks;
using System;
using WindowsStore.Client.Developer.Common;
using WindowsStore.Client.Developer.Common.Enum;
using WindowsStore.Client.Developer.Logic.ServiceInterface;
using WindowsStore.Client.Developer.Logic.ViewModelInterface;
using Prism.Commands;
using Prism.Windows.AppModel;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;

namespace WindowsStore.Client.Developer.Logic.ViewModels
{
    public class SignUpPageViewModel : ViewModelBase
    {
        #region Constructor


        public SignUpPageViewModel( //IAccountService accountService, 
            IAlertMessageService alertMessageService,
            IResourceLoader resourceLoader,
            INavigationService navigationService,
            INaturalPersonUserControlViewModel naturalPersonViewModel,
            ILegalPersonUserControlViewModel legalPersonViewModel,
            ICredentialUserControlViewModel credentialViewModel)
        {
            // _user = new User();
            //_accountService = accountService;
            _alertMessageService = alertMessageService;
            _resourceLoader = resourceLoader;
            _navigationService = navigationService;
            this.NaturalPersonViewModel = naturalPersonViewModel;
            this.LegalPersonViewModel = legalPersonViewModel;
            this.CredentialViewModel = credentialViewModel;

            SignUpCommand = DelegateCommand.FromAsyncHandler(SignUpAsync,CanSignUp);
            //GoBackCommand = new DelegateCommand(GoBack);
        }



        #endregion

        #region Services

        //private readonly IAccountService _accountService;
        private readonly IAlertMessageService _alertMessageService;
        private readonly IResourceLoader _resourceLoader;
        private readonly INavigationService _navigationService;

        #endregion

        #region Fields

        private PersonType _personType;

        private bool _isPersonValid;
        private bool _isCredentialValid;

        #endregion

        #region Properties       

        public INaturalPersonUserControlViewModel NaturalPersonViewModel { get; }
        public ILegalPersonUserControlViewModel LegalPersonViewModel { get; }
        public ICredentialUserControlViewModel CredentialViewModel { get; } 

        [RestorableState]
        public PersonType PersonType
        {
            get { return _personType; }
            set
            {
                if (SetProperty(ref _personType, value))
                {
                    SignUpCommand.RaiseCanExecuteChanged();
                }
            }
        }

        [RestorableState]
        public bool IsPersonValid
        {
            get { return _isPersonValid; }
            set { SetProperty(ref _isPersonValid, value); }
        }

        [RestorableState]
        public bool IsCredentialValid
        {
            get { return _isCredentialValid; }
            set { SetProperty(ref _isCredentialValid, value); }
        }

        #endregion

        #region Methods


        #endregion

        #region Commands


        //public DelegateCommand GoBackCommand { get; private set; }

        public DelegateCommand SignUpCommand { get; }

        #endregion

        #region Actions

        private async Task SignUpAsync()
        {
            var success = false;

            try
            {
                switch (PersonType)
                {
                    case PersonType.NaturalPerson:
                        // set naturalPerson values
                        NaturalPersonViewModel.NaturalPerson.PrimaryEmail =
                              CredentialViewModel.UserCredential.PrimaryEmail;
                        NaturalPersonViewModel.Password = CredentialViewModel.UserCredential.Password;

                        // first validate naturalPersonViewModel and credentialViewModel
                        //
                        this.IsPersonValid = NaturalPersonViewModel.ValidateForm();
                        this.IsCredentialValid = CredentialViewModel.ValidateForm();

                        // if validation is true signup person
                        if (this.IsPersonValid && this.IsCredentialValid)
                        {
                          
                            await NaturalPersonViewModel.ProcessFormAsync();

                            success = true;
                        }
                        break;
                    case PersonType.LegalPerson:
                        // set legalPerson values
                        LegalPersonViewModel.LegalPerson.PrimaryEmail = CredentialViewModel.UserCredential.PrimaryEmail;
                        LegalPersonViewModel.Password = CredentialViewModel.UserCredential.Password;
                        
                        // first validate naturalPersonViewModel and credentialViewModel
                        //
                        this.IsPersonValid = LegalPersonViewModel.ValidateForm();
                        this.IsCredentialValid = CredentialViewModel.ValidateForm();

                        // if validation is true signup person
                        if (this.IsPersonValid && this.IsCredentialValid)
                        {
                            await LegalPersonViewModel.ProcessFormAsync();

                            success = true;
                        }
                        break;
                    case PersonType.None:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                //if success clear sencetive information from memory and navigate to confirm registration page
                if (success)
                {
                    NaturalPersonViewModel.Password = LegalPersonViewModel.Password = null;
                    _navigationService.Navigate(ViewNames.ConfirmRegistration, null);
                }
            }
            catch (Exception)
            {
                await
                    _alertMessageService.ShowAsync(_resourceLoader.GetString("ErrorServiceUnreachable"), null,
                        DialogCommands.CloseDialogCommand);
            }
        }

        private bool CanSignUp()
        {
            return _personType != PersonType.None;
        }
        //private void GoBack()
        //{
        //    _navigationService.GoBack();
        //}

        #endregion
    }
}
