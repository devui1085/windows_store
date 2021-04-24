using System.Collections.Generic;
using System.Collections.ObjectModel;
using Windows.UI.Xaml.Navigation;
using WindowsStore.Client.Developer.Logic.Models;
using WindowsStore.Client.Developer.Logic.ServiceInterface;
using WindowsStore.Client.Developer.Logic.ViewModelInterface;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;

namespace WindowsStore.Client.Developer.Logic.ViewModels
{
    public class CredentialUserControlViewModel : ViewModelBase ,ICredentialUserControlViewModel
    {
        #region Constructor
        public CredentialUserControlViewModel(IClientDeveloperService developerService)
        {
            this.UserCredential = new UserCredential();
            _developerService = developerService;
        }
        #endregion

        #region Services
        private readonly IClientDeveloperService _developerService;
        #endregion

        #region Fields
        //private UserCredential _userCredential;
        private bool _showEmailHasRegisterd;
        #endregion

        #region Properties    

        public UserCredential UserCredential { get;  }

        public string PrimaryEmail
        {
            get { return this.UserCredential.PrimaryEmail; }
            set
            {
                this.UserCredential.PrimaryEmail = value;
                this.ShowEmailHasRegisterd = false;
                if (UserCredential.ValidateProperty("PrimaryEmail"))
                {
                    AlterIfEmailHasRegisterd(this.UserCredential.PrimaryEmail);
                }
            }
        }
        public bool ShowEmailHasRegisterd
        {
            get { return _showEmailHasRegisterd; }
            set { SetProperty(ref _showEmailHasRegisterd, value); }
        }
        #endregion

        #region Methods
        public override void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState)
        {
            if (viewModelState != null)
            {
                base.OnNavigatedTo(e, viewModelState);

                if (e.NavigationMode == NavigationMode.Refresh)
                {
                    //// Restores the error collection manually
                    var errorsCollection = RetrieveEntityStateValue<IDictionary<string, ReadOnlyCollection<string>>>("errorsCollection", viewModelState);

                    if (errorsCollection != null)
                    {
                        this.UserCredential.SetAllErrors(errorsCollection);
                    }
                    // elase set defaults
                }
            }
        }

        public override void OnNavigatingFrom(NavigatingFromEventArgs e, Dictionary<string, object> viewModelState, bool suspending)
        {
            base.OnNavigatingFrom(e, viewModelState, suspending);

            // Store the errors collection manually
            if (viewModelState != null)
            {
                AddEntityStateValue("errorsCollection", this.UserCredential.GetAllErrors(), viewModelState);
            }
        }


        public bool ValidateForm()
        {
            return this.UserCredential.ValidateProperties();
        }


        private async void AlterIfEmailHasRegisterd(string primaryEmail)
        {
            this.ShowEmailHasRegisterd = !await _developerService.IsEmailAvailableForRegistrationAsync(primaryEmail);
        }

        #endregion

        #region Commands
        #endregion

        #region Actions
        #endregion
    }
}
