using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsStore.Client.User.Common.PresentationModel;
using WindowsStore.Client.User.Service.ApplicationService;

namespace WindowsStore.Client.User.Service.ApplicationService.Initilize
{
    public static class DownloadManagerInitializer
    {
        static DownloadManagerInitializer()
        {

        }

        public static void Initialize()
        {
            AppDownloadManager.Instance.DownloadCompleted += appDownloadManager_DownloadCompleted;
            var task = AppDownloadManager.Instance.InitializeAsync();
        }

        private static async void appDownloadManager_DownloadCompleted(AppDownloadItem appDownloadItem)
        {
            await PackageManager.Instance.InstallAppAsync(appDownloadItem);
        }
    }
}
