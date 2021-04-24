using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UI;
using Windows.UI.Popups;
using Windows.UI.Xaml.Data;
using WindowsStore.Client.User.Common.Enum;
using WindowsStore.Client.User.Common.ExtensionMethod;
using WindowsStore.Client.User.Common.Infrastructure;
using WindowsStore.Client.User.Common.PresentationModel;
using WindowsStore.Client.User.Service.ApplicationService;
using WindowsStore.Client.User.Service.Local;
using WindowsStore.Client.User.Service.Local.PackageManagement;
using WindowsStore.Client.User.UI.Infrastructure;
using WindowsStore.Client.User.UI.Infrastructure.ExtensionMethod;

namespace WindowsStore.Client.User.UI.ViewModel
{
    public class DownloadsPageViewModel : ViewModelBase
    {
        public AppDownloadManager DownloadManager
        {
            get
            {
                return AppDownloadManager.Instance;
            }
        }

        public DownloadsPageViewModel()
        {
            UiManager.PageTitle = "Downloads".Localize();
            DownloadManager.CurrentDownloads.CollectionChanged += CurrentDownloads_CollectionChanged;
            DownloadManager.CompletedDownloads.CollectionChanged += CompletedDownloads_CollectionChanged;
        }

        private void CompletedDownloads_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            RaisePropertyChanged(nameof(ShowInstallationSection));
        }

        private void CurrentDownloads_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            RaisePropertyChanged(nameof(ShowDownloadsSection));
        }

        #region Pause Download Command
        public ICommand PauseDownloadCommand
        {
            get
            {
                return new RelayCommand(PauseDownload, CanPauseDownloadCommand);
            }
        }

        private void PauseDownload(object obj)
        {
            var downloadItem = (AppDownloadItem)obj;
            AppDownloadManager.Instance.PauseDownload(downloadItem);
        }

        private bool CanPauseDownloadCommand(object obj)
        {
            return true;
        }
        #endregion

        #region Resume Download Command
        public ICommand ResumeDownloadCommand
        {
            get
            {
                return new RelayCommand(ResumeDownload, CanResumeDownloadCommand);
            }
        }

        private void ResumeDownload(object obj)
        {
            try
            {
                var downloadItem = (AppDownloadItem)obj;
                AppDownloadManager.Instance.ResumeDownload(downloadItem);
            }
            catch
            {

            }
        }

        private bool CanResumeDownloadCommand(object obj)
        {
            return true;
        }

        #endregion

        #region Install App Command
        public ICommand InstallAppCommand
        {
            get
            {
                return new RelayCommand(async (object obj) => await InstallAppAsync(obj), CanInstallApp);
            }
        }

        private async Task InstallAppAsync(object obj)
        {
            var appDownloadItem = (AppDownloadItem)obj;
            await PackageManager.Instance.InstallAppAsync(appDownloadItem);
        }

        private bool CanInstallApp(object obj)
        {
            var appDownloadItem = obj as AppDownloadItem;
            return
                appDownloadItem != null &&
                !PackageManager.Instance.InstallingPackage &&
                appDownloadItem.StorageFile != null &&
                appDownloadItem.InstallationStatus != InstallationStatus.Installed;
        }
        #endregion

        public bool ShowInstallationSection
        {
            get
            {
                return DownloadManager.CompletedDownloads.Count > 0;
            }
        }

        public bool ShowDownloadsSection
        {
            get
            {
                return DownloadManager.CurrentDownloads.Count > 0;
            }
        }

    }
}
