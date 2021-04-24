using System.Collections.Generic;
using Windows.UI.Xaml.Navigation;
using WindowsStore.Client.Developer.Common;
using WindowsStore.Client.Developer.Logic.Models;
using WindowsStore.Client.Developer.Logic.ServiceInterface;
using Prism.Commands;
using Prism.Windows.AppModel;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;

namespace WindowsStore.Client.Developer.Logic.ViewModels
{
    public class AppDetailPageViewModel : ViewModelBase
    {
        #region Constructor

        public AppDetailPageViewModel(INavigationService navigationService,IClientDeveloperService developerService)
        {
            _navigationService = navigationService;
            _developerService = developerService;

         //   AppDetail = new AppDetail();
            GoToAppSpecificationPageCommand = new DelegateCommand(GoToAppSpecificationPage, CanGoToAppSpecificationPage);
            GoToAppIconPageCommand = new DelegateCommand(GoToAppIconPage, CanGoToAppIconPage);
            GoToAppScreenshotsPageCommand = new DelegateCommand(GoToAppScreenshotsPage, CanGoToAppScreenshotsPage);
            GoToAppPlatformSpecificationPageCommand = new DelegateCommand(GoToAppPlatformSpecificationPage,CanGoToAppPlatformSpecificationPage);
            GoToAppVersionSpecificationPageCommand = new DelegateCommand(GoToAppVersionSpecificationPage,CanGoToAppVersionSpecificationPage);
           // GoToAppPackagesPageCommand = new DelegateCommand(GoToAppPackagePage, CanGoToAppPackagePage);
        }

        #endregion

        #region Services

        private readonly INavigationService _navigationService;
        private readonly IClientDeveloperService _developerService;
        #endregion

        #region Fields

        private AppDetail _appDetail;
        private int _appId;
        #endregion

        #region Properties    
        [RestorableState]
        public AppDetail AppDetail
        {
            get { return _appDetail; }
            set { SetProperty(ref _appDetail, value); }
        }

        public bool AppSpecificationIsComplete => AppDetail?.AppSpecification != null && AppDetail.AppSpecification.IsComplete;

        public bool AppIconIsComplete => AppDetail?.AppIcon != null && AppDetail.AppIcon.IsComplete;

        public bool AppScreenshotIsComplete => AppDetail?.AppSpecification!=null && AppDetail.AppSpecification.HasMobileScreenshot;

        public bool AppPlatformSpecificationIsComplete
            => AppDetail?.AppPlatformSpecification != null && AppDetail.AppPlatformSpecification.IsComplete;

        public bool AppVersionSpecificationIsComplete
         => AppDetail?.AppVersionSpecification != null && AppDetail.AppVersionSpecification.IsComplete;


        public bool AppSpecificationPageEnabled => true;
        public bool AppIconPageEnabled => AppSpecificationIsComplete;
        public bool AppScreenshotsPageEnabled => AppDetail?.AppSpecification != null && AppDetail.AppSpecification.IsComplete;
        public bool AppPlatformSpecificationPageEnabled => AppSpecificationIsComplete;
        public bool AppVersionSpecificationPageEnabled => AppIconIsComplete && AppPlatformSpecificationIsComplete;

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
                    //var errorsCollection = RetrieveEntityStateValue<IDictionary<string, ReadOnlyCollection<string>>>("errorsCollection", viewModelState);

                    //if (errorsCollection != null)
                    //{
                    //    _naturalPerson.SetAllErrors(errorsCollection);
                    //}
                    // elase set defaults
                }
            }

            if (e.NavigationMode == NavigationMode.New)
            {
                AppDetail = e.Parameter as AppDetail ?? new AppDetail();
            }
        }

        #endregion

        #region Commands
        public DelegateCommand GoToAppSpecificationPageCommand { get; }
        public DelegateCommand GoToAppIconPageCommand { get; }
        public DelegateCommand GoToAppScreenshotsPageCommand { get; }
        public DelegateCommand GoToAppPlatformSpecificationPageCommand { get; }
        public DelegateCommand GoToAppVersionSpecificationPageCommand { get; }
        public DelegateCommand GoToAppPackagesPageCommand { get; }



        #endregion

        #region Actions

        private async void GoToAppSpecificationPage()
        {
            AppDetail param = AppDetail;

            if(AppDetail.AppSpecification != null)
             param = await _developerService.GetDeveloperAppDetailAsync(AppDetail.AppSpecification.AppId);

            _navigationService.Navigate(ViewNames.AppSpecification, param);
        }

        private void GoToAppIconPage()
        {
            _navigationService.Navigate(ViewNames.AppIcon, AppDetail);
        }

        private void GoToAppScreenshotsPage()
        {
            _navigationService.Navigate(ViewNames.AppScreenshots, AppDetail);
        }

        private void GoToAppPlatformSpecificationPage()
        {
            _navigationService.Navigate(ViewNames.AppPlatformSpecification, AppDetail);
        }

        private async void GoToAppVersionSpecificationPage()
        {
            var param = await _developerService.GetDeveloperAppDetailAsync(AppDetail.AppSpecification.AppId);
            _navigationService.Navigate(ViewNames.AppVersionSpecification, param);
        }

        //private void GoToAppPackagePage()
        //{
        //    _navigationService.Navigate(ViewNames.AppPackages, AppDetail);
        //}

        private bool CanGoToAppSpecificationPage()
        {
            return true;
        }

        private bool CanGoToAppIconPage()
        {
            return AppIconPageEnabled;
        }

        private bool CanGoToAppScreenshotsPage()
        {
            return AppScreenshotsPageEnabled;
        }

        private bool CanGoToAppPlatformSpecificationPage()
        {
            return AppPlatformSpecificationPageEnabled;
        }
        private bool CanGoToAppVersionSpecificationPage()
        {
            return AppVersionSpecificationPageEnabled;
        }
       
        
        //private bool CanGoToAppPackagePage()
        //{
        //   return AppPlatformSpecificationIsComplete;
        //}
        #endregion

    }
}
