using WindowsStore.Client.Developer.Common;
using WindowsStore.Client.Developer.Logic.ServiceInterface;
using WindowsStore.Client.Developer.Logic.ViewModelInterface;
using Prism.Commands;
using Prism.Windows.AppModel;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;
using System;

namespace WindowsStore.Client.Developer.Logic.ViewModels
{
   public class MainPageViewModel:ViewModelBase, IMainPageViewModel
    {
        #region Constructor

        public MainPageViewModel(IAccountService accountService,IResourceLoader resourceLoader)
        {
            _accountService = accountService;
            _resourceLoader = resourceLoader;

            GoToSendAppPageCommand = new DelegateCommand(GoToSendAppPage);
            GoToDashboardPageCommand = new DelegateCommand(GoToDashboardPage);
            GoToAccountInfoPageCommand = new DelegateCommand(GoToAccountInfoPage);
            GoToUserProfilePageCommand = new DelegateCommand(GoToUserProfilePage);
            GoToSignInPageCommand = new DelegateCommand(GoToSignInPage);
            GoToSignUpPageCommand = new DelegateCommand(GoToSignUpPage);

            SignOutCommand = new DelegateCommand(SignOut);
        }

        #endregion

        #region Services

        private INavigationService _navigationService;
        private readonly IAccountService _accountService;
        private readonly IResourceLoader _resourceLoader;
        #endregion

        #region Fields
        #endregion

        #region Properties    
        #endregion

        #region Methods
        #endregion

        #region Commands
        public DelegateCommand GoToSendAppPageCommand { get; }
        public DelegateCommand GoToDashboardPageCommand { get; }
        public DelegateCommand GoToUserProfilePageCommand { get; }
        public DelegateCommand GoToAccountInfoPageCommand { get; }
        public DelegateCommand SignOutCommand { get; }

        public DelegateCommand GoToSignInPageCommand { get; }
        public DelegateCommand GoToSignUpPageCommand { get; }
        public INavigationService NavigationService
        {
            set
            {
                _navigationService = value;
            }
        }

       public void NotifyMainFormForNewChanges()
       {
           this.OnPropertyChanged(nameof(SignedInUser));
           this.OnPropertyChanged(nameof(AnonymouseUser));
       }

       #endregion

        #region Actions

        public void GoToSendAppPage()
        {
            _navigationService.Navigate(ViewNames.AppDetail, null);
        }

        public void GoToDashboardPage()
        {
            _navigationService.Navigate(ViewNames.Dashboard, null);
        }

        public void GoToUserProfilePage()
        {
            _navigationService.Navigate(ViewNames.UserProfile, null);
        }

        public void GoToAccountInfoPage()
        {
            _navigationService.Navigate(ViewNames.AccountInfo, null);
        }

        public void GoToSignInPage()
        {
            _navigationService.Navigate(ViewNames.SignIn, null);
        }
        public void GoToSignUpPage()
        {
            _navigationService.Navigate(ViewNames.SignUp, null);
        }
        public void SignOut()
        {
            _accountService.SignOut();
            NotifyMainFormForNewChanges();
            _navigationService.Navigate(ViewNames.SignIn, null);
        }

        public bool SignedInUser => _accountService.SignedInUser !=null;
        public bool AnonymouseUser => _accountService.SignedInUser == null;

        #endregion
    }
}
