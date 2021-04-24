using WindowsStore.Client.Developer.Common;
using WindowsStore.Client.Developer.Logic.ServiceInterface;
using WindowsStore.Client.Developer.Logic.ViewModelInterface;
using Prism.Commands;
using Prism.Windows.AppModel;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;

namespace WindowsStore.Client.Developer.Logic.ViewModels
{
    public class TopAppBarUserControlViewModel:ViewModelBase, ITopAppBarUserControlViewModel
    {
        #region Constructor

        public TopAppBarUserControlViewModel(INavigationService navigationService, IAccountService accountService)
        {
            _navigationService = navigationService;
            _accountService = accountService;
            SignOutCommand = new DelegateCommand(SignOut, CanSingOut);
        }

        #endregion

        #region Services

        private INavigationService _navigationService;
        private IAccountService _accountService;

        #endregion

        #region Fields

        private bool _signOutEnabled;
        #endregion

        #region Properties    
        [RestorableState]
        public bool SignOutEnabled
        {
            get { return _signOutEnabled; }
            set
            {
                _signOutEnabled = value;
                SignOutCommand.RaiseCanExecuteChanged();
            }
        }
        #endregion

        #region Methods

        #endregion

        #region Commands

        public DelegateCommand SignOutCommand { get; }

        #endregion

        #region Actions

        private void SignOut()
        {
            _accountService.SignOut();
            _navigationService.Navigate(ViewNames.SignIn, null);
        }

        private bool CanSingOut()
        {
            return _signOutEnabled;
        }

        #endregion
    }
}
