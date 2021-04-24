using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Windows.UI.Xaml.Navigation;
using WindowsStore.Client.Developer.Common;
using WindowsStore.Client.Developer.Logic.DeveloperService;
using WindowsStore.Client.Developer.Logic.Models;
using WindowsStore.Client.Developer.Logic.ServiceInterface;
using WindowsStore.Client.Developer.Logic.ViewModelInterface;
using Prism.Windows.AppModel;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;

namespace WindowsStore.Client.Developer.Logic.ViewModels
{
    public class AppVersionSpecificationPageViewModel:ViewModelBase,IAppVersionSpecificationPageViewModel
    {
        #region Constructor

        public AppVersionSpecificationPageViewModel(INavigationService navigationService, IAppService appService, IClientDeveloperService developerService,IAlertMessageService alertMessageService, IResourceLoader resourceLoader, IVersionUserControlViewModel versionViewModel)
        {
            _appService = appService;
            _navigationService = navigationService;
            _developerService = developerService;
            _resourceLoader = resourceLoader;
            _alertMessageService = alertMessageService;

            this.VersionViewModel = versionViewModel;
        }
        #endregion

        #region Services
        private IAppService _appService;
        private readonly INavigationService _navigationService;
        private readonly IClientDeveloperService _developerService;
        private readonly IResourceLoader _resourceLoader;
        private readonly IAlertMessageService _alertMessageService;
        #endregion

        #region Fields

        private AppDetail _appDetail;
        private AppVersion _appVersion;
        private Version _currentVersion;
        private string _currentDescription;
        // private AppPackageSpecification _appPackagesSpecification;
        #endregion

        #region Properties    

        [RestorableState]
        public AppDetail AppDetail
        {
            get { return _appDetail; }
            set { SetProperty(ref _appDetail, value); }
        }

        [RestorableState]
        public AppVersion AppVersion
        {
            get { return _appVersion; }
            set { SetProperty(ref _appVersion, value); }
        }

        public bool PageIsOnUpdateState()
        {
            return VersionViewModel.Version.CompareTo(_currentVersion) == 0
                   && _currentDescription != AppVersion.Description;
        }

        public bool NewVersionIsEqualOrLessThanCurrentVersion ()
        {
            return VersionViewModel.Version.CompareTo(_currentVersion) != 1;
        }
        public IVersionUserControlViewModel VersionViewModel { get; }


        #region Packages

        public bool IsX64PackageMandatory => AppDetail.AppPlatformSpecification.CpuArchitectureFlags != null && AppDetail.AppPlatformSpecification.CpuArchitectureFlags.Value.HasFlag(CpuArchitecture.X64);
        public bool IsX86PackageMandatory => AppDetail.AppPlatformSpecification.CpuArchitectureFlags != null && AppDetail.AppPlatformSpecification.CpuArchitectureFlags.Value.HasFlag(CpuArchitecture.X86);
        public bool IsArmPackageMandatory => AppDetail.AppPlatformSpecification.CpuArchitectureFlags != null && AppDetail.AppPlatformSpecification.CpuArchitectureFlags.Value.HasFlag(CpuArchitecture.Arm);
        #endregion
        #endregion

        #region Methods
        public override async void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState)
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
                        AppVersion.SetAllErrors(errorsCollection);
                    }
                    // elase set defaults
                }


            }

            if (e.NavigationMode == NavigationMode.New)
            {
                var param = e.Parameter as AppDetail;

                if (param != null)
                {
                    AppDetail = param;

                    if (AppDetail.AppVersionSpecification != null)
                    {
                        AppVersion = AppDetail.AppVersionSpecification;
                        VersionViewModel.Version = Version.Parse(AppVersion.Version);
                        _currentVersion = Version.Parse(AppVersion.Version);
                        _currentDescription = AppVersion.Description;
                    }
                    else
                    {
                        AppVersion = new AppVersion {AppId = AppDetail.AppSpecification.AppId};
                    }
          
                    //  AppPackageSpecification = AppDetail.AppPackageSpecification ?? new AppPackageSpecification();
                }
            }
        }

        public override void OnNavigatingFrom(NavigatingFromEventArgs e, Dictionary<string, object> viewModelState, bool suspending)
        {
            base.OnNavigatingFrom(e, viewModelState, suspending);

            // Store the errors collection manually
            if (viewModelState != null)
            {
                AddEntityStateValue("errorsCollection", this.AppVersion.GetAllErrors(), viewModelState);
            }
        }

        public bool VersionFormIsValid()
        {
            AppVersion.Version = VersionViewModel.Version.ToString();
            return this.AppVersion.ValidateProperties();
        }

        public IAlertMessageService GetAlertMessageService()
        {
            return _alertMessageService;
        }

        public IResourceLoader GetResourceLoader()
        {
            return _resourceLoader;
        }
        #endregion

        #region Commands
        //  public DelegateCommand SaveAppVersionSpecificationCommand { get; }
        #endregion

        #region Actions

        public async void SaveAppVersionSpecificationAsync(bool updateCurrentVersion)
        {
            // if validation is true signup person

            if (!this.AppVersion.ValidateProperties()) return;

            if (AppVersion.Id == 0 || !updateCurrentVersion)
            {
                AppVersion.Version = VersionViewModel.Version.ToString();
                AppDetail.AppVersionSpecification = await _developerService.RegisterAppVersionAsync(AppVersion);
            }
            else
            {
                await _developerService.UpdateAppVersionAsync(AppVersion);
            }

            _navigationService.Navigate(ViewNames.AppDetail, AppDetail);
        }

        #endregion
    }
}
