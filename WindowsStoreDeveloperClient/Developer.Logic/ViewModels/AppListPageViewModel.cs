using System.Collections.ObjectModel;
using System.Threading.Tasks;
using WindowsStore.Client.Developer.Common;
using WindowsStore.Client.Developer.Logic.Models;
using WindowsStore.Client.Developer.Logic.ServiceInterface;
using Prism.Commands;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;
using System.Linq;
using Prism.Windows.AppModel;

namespace WindowsStore.Client.Developer.Logic.ViewModels
{
    public class AppListPageViewModel : ViewModelBase
    {
        #region Constructor

        public AppListPageViewModel(INavigationService navigationService, IAccountService accountService,IAppService appService,IResourceLoader resourceLoader)
        {
            _navigationService = navigationService;
            _accountService = accountService;
            _appService = appService;
            _resourceLoader = resourceLoader;

            GoToSendAppPageCommand = new DelegateCommand(GoToSendAppPage);
            GoToAccountInfoPageCommand = new DelegateCommand(GoToAccountInfoPage);
            GoToUserProfilePageCommand = new DelegateCommand(GoToUserProfilePage);

            Initialize();
        }

        #endregion

        #region Services

        private readonly INavigationService _navigationService;
        private readonly IAccountService _accountService;
        private readonly IAppService _appService;
        private readonly IResourceLoader _resourceLoader;
        #endregion

        #region Fields

        private ObservableCollection<DashboardAppItemUserControlViewModel> _developerAppsDetails;
        //private read
        #endregion

        #region Properties    

        [RestorableState]
        public ObservableCollection<DashboardAppItemUserControlViewModel> DeveloperAppsDetails
        {
            get { return _developerAppsDetails; }
            set { SetProperty(ref _developerAppsDetails, value); }
        }
        //public ObservableCollection<DashboardAppItemUserControlViewModel> DeveloperApps2 { get; private set; }
        #endregion

        #region Methods

        private async void Initialize()
        {
            var result = await _appService.GetDeveloperAppsAsync();
            var developerAppsTasks = result.Select(async a => await CreateDashboardAppItemData(a));

            var appsDetails = await Task.WhenAll<DashboardAppItemUserControlViewModel>(developerAppsTasks);

            DeveloperAppsDetails = new ObservableCollection<DashboardAppItemUserControlViewModel>(appsDetails);
        }

        private async Task<DashboardAppItemUserControlViewModel> CreateDashboardAppItemData(Task<AppDetail> task)
        {
            var app = await task;
            return new DashboardAppItemUserControlViewModel(_navigationService,_resourceLoader)
            {
                AppDetail =app,
            };
        }

        #endregion

        #region Commands
        public DelegateCommand GoToSendAppPageCommand { get; }
        public DelegateCommand GoToUserProfilePageCommand { get; }
        public DelegateCommand GoToAccountInfoPageCommand { get; }
        #endregion

        #region Actions

        public void GoToSendAppPage()
        {
            _navigationService.Navigate(ViewNames.AppDetail, null);
        }


        public void GoToUserProfilePage()
        {
            _navigationService.Navigate(ViewNames.UserProfile, null);
        }

        public void GoToAccountInfoPage()
        {
            _navigationService.Navigate(ViewNames.AccountInfo, null);
        }
        #endregion
    }
}


