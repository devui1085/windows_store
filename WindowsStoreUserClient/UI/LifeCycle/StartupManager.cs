using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UI;
using Windows.ApplicationModel.Activation;
using Windows.Networking.BackgroundTransfer;
using Windows.Networking.Connectivity;
using Windows.UI.Popups;
using WindowsStore.Client.User.Common.Enum;
using WindowsStore.Client.User.Common.ExtensionMethod;
using WindowsStore.Client.User.Common.PresentationModel;
using WindowsStore.Client.User.Service.ApplicationService;
using WindowsStore.Client.User.Service.Local;
using WindowsStore.Client.User.Service.Local.PackageManagement;
using WindowsStore.Client.User.UI.Infrastructure.Timer;

namespace WindowsStore.Client.User.UI.LifeCycle
{
    public static class StartupManager
    {
        internal static void HandleStartupEvent(LaunchActivatedEventArgs e)
        {
            //if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
            //{
            //    //TODO: Load state from previously suspended application
            //}
            InitializePaasteelModules();
        }

        internal static void HandleResumeEvent()
        {

        }

        private static void InitializePaasteelModules()
        {
            InitializeUpdateService();
            InitializeDownloadManager();
            InitializeAutoSignIn();
        }

        private static void InitializeUpdateService()
        {
            UpdateService.Instance.UpdateIsAvailable += updateService_UpdateIsAvailable;
            var timer = new CountdownTimer(2);
            timer.Action = CheckForCurrentAppUpdate;
            timer.Start();
        }

        private static void InitializeAutoSignIn()
        {
            var userManager = UserManager.Instance;
            var countDownTimer = new CountdownTimer(1);
            countDownTimer.Action = param =>
            {
                if (string.IsNullOrEmpty(userManager.StoredUserName)) return;
                var task = userManager.SignInAsync(userManager.StoredUserName, userManager.StoredPassword);
            };
            countDownTimer.Start();
        }

        private static void InitializeDownloadManager()
        {
            AppDownloadManager.Instance.DownloadCompleted += appDownloadManager_DownloadCompleted;
            var countDownTimer = new CountdownTimer(obj =>
            {
                var task = AppDownloadManager.Instance.InitializeAsync();
            }, null, 3);
            countDownTimer.Start();
        }

        private static async void appDownloadManager_DownloadCompleted(AppDownloadItem appDownloadItem)
        {
            await PackageManager.Instance.InstallAppAsync(appDownloadItem);
        }

        private static void CheckForCurrentAppUpdate(object obj)
        {
            if (!SettingManager.AutomaticallyUpdateCurrentApp) return;

            try {
                UpdateService.Instance.CheckForCurrentAppUpdatesAsync()
                    .ContinueWith(task =>
                    {
                        if (!task.IsCompleted || !UpdateService.Instance.IsUpdateAvailableForCurrentApp) return;

                        if (SettingManager.AutomaticallyUpdateCurrentApp || UpdateService.Instance.IsMandatoryUpdateAvailableForCurrentApp) {
                            var downloadTask = AppDownloadManager.Instance.StartDownloadAsync(new AppDownloadItem()
                            {
                                AppGuid = CurrentApplication.Guid,
                                AppName = CurrentApplication.Name
                            });
                        }
                    }, TaskScheduler.FromCurrentSynchronizationContext());
            }
            catch {
                // Do nothing.
            }
        }

        private static void updateService_UpdateIsAvailable(AppVersion appVersion)
        {
        }
    }
}
