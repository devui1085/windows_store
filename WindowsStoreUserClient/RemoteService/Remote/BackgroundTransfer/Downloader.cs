using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Windows.Networking.BackgroundTransfer;
using Windows.Storage;
using WindowsStore.Client.User.Common.ExtensionMethod;

namespace WindowsStore.Client.User.Service.Remote.BackgroundTransfer
{
    internal class Downloader
    {
        // Fields
        BackgroundDownloader _backgroundDownloader;
        BackgroundTransferGroup _transferGroup;
        Dictionary<Guid, CancellationTokenSource> _cancellationTokenSources;

        // Events
        /// <summary>
        /// Note: Handler of this event is invoked on a background thread
        /// </summary>
        public event Action<DownloadOperation> DownloadProgress;

        public Downloader()
        {
            InitializeDownloader();
        }

        public async Task<DownloadOperation> StartDownloadAsync(Uri uri, IStorageFile storageFile)
        {
            Progress<DownloadOperation> progressCallback = new Progress<DownloadOperation>(DownloadOperationProgress);
            CancellationTokenSource cts = new CancellationTokenSource();
            var downloadOperation = _backgroundDownloader.CreateDownload(uri, storageFile);
            var downloadTask = downloadOperation.StartAsync().AsTask(cts.Token, progressCallback);
            _cancellationTokenSources.Add(downloadOperation.Guid, cts);
            return downloadOperation;
        }

        public void PauseDownload(DownloadOperation downloadOperation)
        {
            if (downloadOperation.Progress.Status == BackgroundTransferStatus.Running)
            {
                downloadOperation.Pause();
            }
        }

        public void ResumeDownload(DownloadOperation download)
        {
            if (download.Progress.Status == BackgroundTransferStatus.PausedByApplication)
            {
                download.Resume();
            }
        }

        public void CancelDownload(DownloadOperation download)
        {
            _cancellationTokenSources[download.Guid].Cancel();
        }

        public async Task<IReadOnlyList<DownloadOperation>> DiscoverBackgroundDownloadsAsync()
        {
            var currentDownloads = await BackgroundDownloader.GetCurrentDownloadsForTransferGroupAsync(_transferGroup);
            _cancellationTokenSources.Clear();

            foreach (var downloadOperation in currentDownloads)
            {
                //if (downloadOperation.Progress.Status != BackgroundTransferStatus.Running) continue;
                try
                {
                    Progress<DownloadOperation> progressCallback = new Progress<DownloadOperation>(DownloadOperationProgress);
                    CancellationTokenSource cts = new CancellationTokenSource();
                    var attachTask = downloadOperation.AttachAsync().AsTask(cts.Token, progressCallback);
                    var addCancelationTokenTask = attachTask.ContinueWith(antecedent =>
                    {
                        if (antecedent.Status == TaskStatus.Faulted)
                        {
                            // Attaching to DownloadOperation has failed
                            return;
                        }
                        _cancellationTokenSources.Add(antecedent.Result.Guid, cts);
                    });
                }
                catch
                {
                }
            }

            return currentDownloads;
        }

        private void InitializeDownloader()
        {
            const int initialCapecity = 10;
            _transferGroup = BackgroundTransferGroup.CreateGroup("2336B35A-4F7A-49F9-BB7A-45EBBC45B769");
            _transferGroup.TransferBehavior = BackgroundTransferBehavior.Parallel;
            _backgroundDownloader = new BackgroundDownloader();
            _backgroundDownloader.TransferGroup = _transferGroup;
            _cancellationTokenSources = new Dictionary<Guid, CancellationTokenSource>(initialCapecity);
        }

        private void DownloadOperationProgress(DownloadOperation download)
        {
            // Note that this event handler is invoked on a background thread
            if (this.DownloadProgress != null)
                this.DownloadProgress(download);
        }
    }
}
