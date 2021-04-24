using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using WindowsStore.Client.User.Common.Enum;
using WindowsStore.Client.User.Common.Infrastructure;
using WindowsStore.Client.User.Common.PresentationModel;
using WindowsStore.Client.User.Service.Local;
using WindowsStore.Client.User.Service.Local.PackageManagement;
using WindowsStore.Client.User.Service.Remote.Wcf;

namespace WindowsStore.Client.User.Service.ApplicationService
{
    public class PackageManager
    {
        // Fields
        private static PackageManager _instance;

        // Properties
        private Queue<AppDownloadItem> InstallationQueue { get; set; }
        public bool InstallingPackage { get; set; }
        public static PackageManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new PackageManager();
                return _instance;
            }
        }

        // Events
        public event Action<AppDownloadItem> InstallationCompleted;

        public PackageManager()
        {
            InstallationQueue = new Queue<AppDownloadItem>();
        }

        public async Task InstallAppAsync(AppDownloadItem appDownloadItem)
        {
            InstallationQueue.Enqueue(appDownloadItem);
            if (InstallingPackage)
                return;

            InstallingPackage = true;
            while (InstallationQueue.Count() > 0) {
                PackageInstallationResult result = new PackageInstallationResult() { Success = false };
                var item = InstallationQueue.Dequeue();
                        item.InstallationStatus = InstallationStatus.Installing;
                for (int i = 0; i < 3 && !result.Success; i++) {
                    result = await DevicePackageManager.InstallAppAsync(item.StorageFile, item.AppGuid);
                    if (!result.Success) {
                        await Task.Delay(2000);
                    }
                }

                if (result.Success) {
                    item.InstallationStatus = InstallationStatus.Installed;
                    // Delete App Package
                    try {
                        var storageFile = await CurrentApplication.AppDownloadFolder.GetFileAsync($"{item.AppGuid}.pstl");
                        await storageFile.DeleteAsync();
                    }
                    catch {
                    }
                }
                else {
                    item.InstallationStatus = InstallationStatus.InstallationFailed;
                }

                // Raise Event
                if (InstallationCompleted != null)
                    InstallationCompleted(item);
            }
            InstallingPackage = false;
        }
    }
}
