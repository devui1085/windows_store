using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UI;
using Windows.Storage;
using Windows.UI.Xaml.Data;
using WindowsStore.Client.User.Common.Enum;
using WindowsStore.Client.User.Common.ExtensionMethod;
using WindowsStore.Client.User.Common.Infrastructure;
using WindowsStore.Client.User.Common.PresentationModel;
using WindowsStore.Client.User.Service.ApplicationService;
using WindowsStore.Client.User.Service.Local;
using WindowsStore.Client.User.UI.Infrastructure;
using WindowsStore.Client.User.UI.Infrastructure.ExtensionMethod;

namespace WindowsStore.Client.User.UI.ViewModel
{
    public class AppDownloadPageViewModel : ViewModelBase
    {
        bool _showAppDownloadProgress;
        RelayCommand _installAppCommand;
        StoreApp _storeApp;

        public StoreApp StoreApp
        {
            get
            {
                return _storeApp;
            }

            set
            {
                _storeApp = value;
                RaisePropertyChanged();
            }
        }
        public ObservableCollection<Screenshot> AppScreenshots { get; set; }

        public bool ShowAppDownloadProgress
        {
            set
            {
                _showAppDownloadProgress = value;
                base.RaisePropertyChanged();
            }
            get
            {
                return _showAppDownloadProgress;
            }
        }

        public AppDownloadManager DownloadManager
        {
            get
            {
                return AppDownloadManager.Instance;
            }
        }

        public AppDownloadPageViewModel()
        {
            AppScreenshots = new ObservableCollection<Screenshot>();
        }

        public async Task InitilizePageAsync()
        {
            try {
                UiManager.ShowLoading();
                await LoadAppDetailsAsync();
                await LoadAppScreenshotsAsync();
            }
            catch (Exception exp) {

            }
            UiManager.HideLoading();
        }

        private async Task LoadAppScreenshotsAsync()
        {
            for (int i = 0; i < StoreApp.NumberOfMobileScreenshots; i++) {
                try {
                    AppScreenshots.Add(await AppManager.Instance.GetAppScreenShotAsync(
                        StoreApp.Guid,
                        AppScreenshotType.Mobile,
                        AppScreenshotSize.Thumbnail,
                        i));
                }
                catch {

                }
            }
        }

        public async Task LoadAppDetailsAsync()
        {
            var appDetails = await AppManager.Instance.GetAppDetailsAsync(StoreApp.Guid);
            appDetails.Icon128x128 = StoreApp.Icon128x128;
            StoreApp = appDetails;
        }

        #region Install App Command
        public RelayCommand InstallAppCommand
        {
            get
            {
                if (_installAppCommand == null)
                    _installAppCommand = new RelayCommand(async (object obj) => await ExecuteInstallAppCommandAsync(obj), CanExecuteInstallAppCommand);
                return _installAppCommand;
            }
        }

        private async Task ExecuteInstallAppCommandAsync(object obj)
        {
            try {
                await DownloadManager.StartDownloadAsync(new AppDownloadItem()
                {
                    AppGuid = StoreApp.Guid,
                    AppName = StoreApp.Name
                });
            }
            catch {

            }
            InstallAppCommand.RaiseCanExecuteChanged(null);
        }

        private bool CanExecuteInstallAppCommand(object obj)
        {
            return !DownloadManager.CurrentDownloads.Any(download => download.AppGuid == StoreApp.Guid);
        }
        #endregion
    }
}
