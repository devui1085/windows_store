using WindowsStore.Client.User.Common.PresentationModel;
using WindowsStore.Client.User.Service.Local;

namespace WindowsStore.Client.User.Service.ApplicationService.Initilize
{
    public static class UpdateServiceInitializer
    {
        static UpdateServiceInitializer()
        {
            UpdateService.Instance.UpdateIsAvailable += updateService_UpdateIsAvailable;
        }

        public static void Initialize()
        {
            if (!SettingManager.AutomaticallyUpdateCurrentApp) return;
            var task = UpdateService.Instance.CheckForCurrentAppUpdatesAsync();
        }

        private async static void updateService_UpdateIsAvailable(AppVersion appVersion)
        {
            if (appVersion.AppGuid != CurrentApplication.Guid) return;
            await AppDownloadManager.Instance.StartDownloadPaasteelAsync();
        }
    }
}
