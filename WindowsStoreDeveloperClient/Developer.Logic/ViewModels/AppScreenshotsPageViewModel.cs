using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Windows.UI.Xaml.Navigation;
using WindowsStore.Client.Developer.Common;
using WindowsStore.Client.Developer.Logic.Models;
using WindowsStore.Client.Developer.Logic.ServiceInterface;
using WindowsStore.Client.Developer.Logic.ViewModelInterface;
using Prism.Commands;
using Prism.Windows.AppModel;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;

namespace WindowsStore.Client.Developer.Logic.ViewModels
{
    public class AppScreenshotsPageViewModel: ViewModelBase, IAppScreenshotsPageViewModel
    {
        #region Constructor

        public AppScreenshotsPageViewModel(IAlertMessageService alertMessageService, IResourceLoader resourceLoader, INavigationService navigationService, IClientDeveloperService developerService)
        {
            _navigationService = navigationService;
            _developerService = developerService;
            _alertMessageService = alertMessageService;
            _resourceLoader = resourceLoader;

            MobileScreenshots = new ObservableCollection<AppScreenshot>();
            SaveMobileScreenshotCommand = DelegateCommand.FromAsyncHandler(SaveMobileScreenshotAsync);
            RemoveScreenshotCommand = DelegateCommand<AppScreenshot>.FromAsyncHandler(RemoveScreenshot);
            GoToAppDetailPageCommand = new DelegateCommand(GoToAppDetail);
        }

 

        #endregion

        #region Services

        private readonly INavigationService _navigationService;
        private readonly IClientDeveloperService _developerService;
        private readonly IResourceLoader _resourceLoader;
        private readonly IAlertMessageService _alertMessageService;

        #endregion
        #region Fields

        public AppDetail _appDetail; 
        private ObservableCollection<AppScreenshot> _mobileScreenshots;
        private ObservableCollection<AppScreenshot> _desktopScreenshots;

        //private read
        #endregion

        #region Properties    
        [RestorableState]
        public AppDetail AppDetail
        {
            get { return _appDetail; }
            set { SetProperty(ref _appDetail, value); }
        }



        [RestorableState]
        public ObservableCollection<AppScreenshot> MobileScreenshots
        {
            get { return _mobileScreenshots; }
            set { SetProperty(ref _mobileScreenshots, value); }
        }

        [RestorableState]
        public ObservableCollection<AppScreenshot> DesktopScreenshots
        {
            get { return _desktopScreenshots; }
            set { SetProperty(ref _desktopScreenshots, value); }
        }

        public bool HasMobileScreenshot => MobileScreenshots.Count > 0;
        #endregion

        #region Methods

        public IAlertMessageService GetAlertMessageService()
        {
            return _alertMessageService;
        }

        public IResourceLoader GetResourceLoader()
        {
            return _resourceLoader;
        }
        public override async void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState)
        {
            if (viewModelState != null)
            {
                base.OnNavigatedTo(e, viewModelState);
            }

            if (e.NavigationMode == NavigationMode.New)
            {
                var param = e.Parameter as AppDetail;

                if (param != null)
                {
                    AppDetail = param;

                    // load app screeshots
                    LoadScreenshots();
                }
            }
        }

        public override void OnNavigatingFrom(NavigatingFromEventArgs e, Dictionary<string, object> viewModelState,
            bool suspending)
        {
            base.OnNavigatingFrom(e, viewModelState, suspending);

            // Store the errors collection manually
            if (viewModelState != null)
            {
                //AddEntityStateValue("errorsCollection", this.AppSpecification.GetAllErrors(), viewModelState);
            }
        }

       
        public void ShowImageSizeError()
        {
            _alertMessageService.ShowAsync(_resourceLoader.GetString("ImageSizeError"), null,
                DialogCommands.CloseDialogCommand);
        }
        #endregion

        #region Commands
        public DelegateCommand SaveMobileScreenshotCommand { get; }

        public DelegateCommand<AppScreenshot> RemoveScreenshotCommand { get; }

        public DelegateCommand GoToAppDetailPageCommand { get; }
        #endregion

        #region Actions

        private async void LoadScreenshots()
        {
            var filter = new AppScreenshotFilter()
            {
                AppId = AppDetail.AppSpecification.AppId,
                AppGuid = AppDetail.AppSpecification.Guid,
                ScreenshotSize = DeveloperService.ScreenshotSize.Thumbnail,
                ScreenshotType = DeveloperService.ScreenshotType.Mobile
            };

            var screenshotIds = await _developerService.GetScreenshotIdsAsync(filter);
            
            foreach(var id in screenshotIds)
            {
                filter.ScreenshotId = id;
                var screenshot = await _developerService.GetScreenshotAsync(filter);

                MobileScreenshots.Add(screenshot);
            }

            // notify ui
            this.OnPropertyChanged(nameof(HasMobileScreenshot));
        }
        private async Task SaveMobileScreenshotAsync()
        {
            await _developerService.RegisterAppIconAsync(AppDetail.AppIcon);
            _navigationService.Navigate(ViewNames.AppDetail, AppDetail);
        }


        public void AddScreenshot(AppScreenshot screenshot)
        {
            _developerService.SaveScreenshotAsync(screenshot);
            MobileScreenshots.Add(screenshot);

            // notify ui
            this.OnPropertyChanged(nameof(HasMobileScreenshot));
        }

        public async Task RemoveScreenshot(AppScreenshot screenshot)
        {
            if (MobileScreenshots.Count == 1)
            {
                await _alertMessageService.ShowAsync(_resourceLoader.GetString("AcquireTheMinimumNumberOfScreenshot"), null,DialogCommands.CloseDialogCommand);
                return;
            }

            await _developerService.RemoveScreenshotAsync(screenshot);
            MobileScreenshots.Remove(screenshot);

            // notify ui 
            this.OnPropertyChanged(nameof(HasMobileScreenshot));
        }

        public async void GoToAppDetail()
        {
            var appDetail = await _developerService.GetDeveloperAppDetailAsync(AppDetail.AppSpecification.AppId);
            _navigationService.Navigate(ViewNames.AppDetail, appDetail);
        }

        #endregion
    }
}
