using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Networking.BackgroundTransfer;
using Windows.Storage;
using WindowsStore.Client.User.Common.ExtensionMethod;
using WindowsStore.Client.User.Common.PresentationModel;
using WindowsStore.Client.User.Common.Web;
using WindowsStore.Client.User.Service.Local;
using WindowsStore.Client.User.Service.Remote;
using WindowsStore.Client.User.Service.Remote.Address;
using WindowsStore.Client.User.Service.Remote.BackgroundTransfer;

namespace WindowsStore.Client.User.Service.ApplicationService
{
    public class AppDownloadManager
    {
        // Fields
        private Downloader _downloader;
        private string _downloadsHistoryFileName;
        private List<AppDownloadItem> _downloadsHistory;
        private static AppDownloadManager _instance;

        // Events
        public event Action<AppDownloadItem> DownloadProgress;
        public event Action<AppDownloadItem> DownloadCompleted;

        // Properties
        public ObservableCollection<AppDownloadItem> CurrentDownloads { get; private set; }
        public ObservableCollection<AppDownloadItem> CompletedDownloads { get; private set; }
        public bool IsDownloadManagerInitialized { get; set; }
        public static AppDownloadManager Instance
        {
            get
            {
                if (_instance == null) _instance = new AppDownloadManager();
                return _instance;
            }
        }

        private AppDownloadManager()
        {
            IsDownloadManagerInitialized = false;
            CurrentDownloads = new ObservableCollection<AppDownloadItem>();
            CompletedDownloads = new ObservableCollection<AppDownloadItem>();
            _downloader = new Downloader();
            _downloader.DownloadProgress += downloader_DownloadProgress;
            _downloadsHistoryFileName = "DownloadsHistory.xml";
            _downloadsHistory = new List<AppDownloadItem>();
        }

        /// <summary>
        /// Initializes the object. if the object is already initialized, this method do no action and return immediately.
        /// </summary>
        public async Task InitializeAsync()
        {
            if (IsDownloadManagerInitialized) return;
            await LoadDownloadsHistoryFromFileAsync();
            await DiscoverDownloadsAsync();
            LoadCompletedDownloadsFromDownloadsHistory();
            IsDownloadManagerInitialized = true;
        }


        /// <summary>
        /// Discovers Current and Completed Downloads.
        /// </summary>
        public async Task DiscoverDownloadsAsync()
        {
            CurrentDownloads.Clear();
            CompletedDownloads.Clear();
            var currentDownloads = await _downloader.DiscoverBackgroundDownloadsAsync();

            foreach (var download in currentDownloads) {
                var status = download.Progress.Status;
                if (status == BackgroundTransferStatus.Canceled) continue;

                var appDownloadItem = GetAppDownloadItem(download);
                appDownloadItem.Tag = download;

                if (status == BackgroundTransferStatus.Completed) {
                    CompletedDownloads.Add(appDownloadItem);
                }
                else {
                    CurrentDownloads.Add(appDownloadItem);
                }
            }
        }

        public async Task StartDownloadAsync(AppDownloadItem appDownloadItem)
        {
            await InitializeAsync();

            if (FindAppInCurrentDownloads(appDownloadItem.AppGuid) != null)
                return;

            // Start Download
            CurrentDownloads.Add(appDownloadItem);
            appDownloadItem.StorageFile = await CurrentApplication.AppDownloadFolder.CreateFileAsync(
                    $"{appDownloadItem.AppGuid}.pstl",
                    CreationCollisionOption.ReplaceExisting);
            var downloadOperation = await _downloader.StartDownloadAsync(
                    ServerUri.GetAppDownloadUri(appDownloadItem.AppGuid),
                    appDownloadItem.StorageFile);
            appDownloadItem.StartDate = DateTime.Now;
            appDownloadItem.DownloadGuid = downloadOperation.Guid;
            appDownloadItem.Tag = downloadOperation;

            // update collections
            _downloadsHistory.Add(appDownloadItem);
            await SaveDownloadsHistoryToFileAsync();
        }

        public void PauseDownload(AppDownloadItem appDownloadItem)
        {
            var downloadOperation = (DownloadOperation)appDownloadItem.Tag;
            _downloader.PauseDownload(downloadOperation);
        }

        public void ResumeDownload(AppDownloadItem appDownloadItem)
        {
            var downloadOperation = (DownloadOperation)appDownloadItem.Tag;
            _downloader.ResumeDownload(downloadOperation);
        }

        public void CancelDownload(AppDownloadItem appDownloadItem)
        {
            var downloadOperation = (DownloadOperation)appDownloadItem.Tag;
            _downloader.CancelDownload(downloadOperation);
        }

        public AppDownloadItem FindAppInCurrentDownloads(Guid appGuid)
        {
            return CurrentDownloads.SingleOrDefault(appDownloadItem => appDownloadItem.AppGuid == appGuid);
        }

        public async Task StartDownloadPaasteelAsync()
        {
            await AppDownloadManager.Instance.StartDownloadAsync(new AppDownloadItem()
            {
                AppGuid = CurrentApplication.Guid,
                AppName = CurrentApplication.Name
            });
        }

        private void downloader_DownloadProgress(DownloadOperation downloadOperation)
        {
            var appDownloadItem = CurrentDownloads.SingleOrDefault(item =>
                    (item.Tag as DownloadOperation).Guid == downloadOperation.Guid);
            if (appDownloadItem == null) return;
            appDownloadItem.BytesReceived = downloadOperation.Progress.BytesReceived;
            appDownloadItem.SetStatus(downloadOperation.Progress.Status);

            // When this event handler is occured for first time (for a specefic DownloadOperation),
            // appDownloadItem.TotalBytesToReceive is zero
            if (appDownloadItem.TotalBytesToReceive == 0)
                appDownloadItem.TotalBytesToReceive = downloadOperation.Progress.TotalBytesToReceive;

            // OS might not report a download completion event, we should check this.
            if ((downloadOperation.Progress.BytesReceived == downloadOperation.Progress.TotalBytesToReceive) &&
                (downloadOperation.Progress.BytesReceived > 0)) {
                appDownloadItem.SetStatus( BackgroundTransferStatus.Completed);
            }

            if (appDownloadItem.GetStatus()  == BackgroundTransferStatus.Completed) {
                appDownloadItem.EndDate = DateTime.Now;
                CurrentDownloads.Remove(appDownloadItem);
                CompletedDownloads.Add(appDownloadItem);
                var task = SaveDownloadsHistoryToFileAsync();
                if (this.DownloadCompleted != null)
                    DownloadCompleted(appDownloadItem);
            }

            if (this.DownloadProgress != null) {
                DownloadProgress(appDownloadItem);
            }
        }

        private AppDownloadItem GetAppDownloadItem(DownloadOperation downloadOperation)
        {
            int appId = -1;
            var appDownloadItem = _downloadsHistory.SingleOrDefault(downloadItem =>
                downloadItem.DownloadGuid == downloadOperation.Guid);

            if (appDownloadItem == null) {
                // Unknown download item!
                var queryStringParts = HttpUtility.ParseQueryString(downloadOperation.RequestedUri.Query);
                Int32.TryParse(queryStringParts["appid"], out appId);
            }

            appDownloadItem = new AppDownloadItem()
            {
                AppId = (appDownloadItem != null ? appDownloadItem.AppId : appId),
                AppName = (appDownloadItem != null ? appDownloadItem.AppName : downloadOperation.Guid.ToString()),
                StorageFile = downloadOperation.ResultFile,
                TotalBytesToReceive = downloadOperation.Progress.TotalBytesToReceive,
                BytesReceived = downloadOperation.Progress.BytesReceived,
                DownloadGuid = downloadOperation.Guid,
                Tag = downloadOperation,
            };
            appDownloadItem.SetStatus(downloadOperation.Progress.Status);
            return appDownloadItem;
        }

        private async Task SaveDownloadsHistoryToFileAsync()
        {
            try {
                StorageFile file = await ApplicationData.Current.LocalFolder.CreateFileAsync(
                    _downloadsHistoryFileName, CreationCollisionOption.ReplaceExisting);
                SerializationHelper<List<AppDownloadItem>>.SerializeToFileAsync(_downloadsHistory, file);
            }
            catch (Exception exp) {

            }
        }

        private async Task LoadDownloadsHistoryFromFileAsync()
        {
            try {
                StorageFile file = await ApplicationData.Current.LocalFolder.GetFileAsync(_downloadsHistoryFileName);
                _downloadsHistory = await SerializationHelper<List<AppDownloadItem>>.DeserializeFromFileAsync(file);
            }
            catch {
            }
        }

        private void LoadCompletedDownloadsFromDownloadsHistory()
        {
            _downloadsHistory.ForEach(appDownloadItem =>
            {
                if (appDownloadItem.GetStatus()  == BackgroundTransferStatus.Completed && appDownloadItem.TotalBytesToReceive > 0)
                    CompletedDownloads.Add(appDownloadItem);
            });
        }

    }
}
