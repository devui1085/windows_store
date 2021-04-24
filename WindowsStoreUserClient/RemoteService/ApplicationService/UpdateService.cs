using System;
using System.Linq;
using System.Threading.Tasks;
using WindowsStore.Client.User.Common.PresentationModel;
using WindowsStore.Client.User.Service.Local;

namespace WindowsStore.Client.User.Service.ApplicationService
{
    public sealed class UpdateService
    {
        public static UpdateService Instance { get; private set; } = new UpdateService();
        Remote.Wcf.UserService _userService;

        #region Events
        public event Action<AppVersion> UpdateIsAvailable;
        public event EventHandler CheckForUpdatesStarted;
        public event EventHandler CheckForUpdatesFinished;
        #endregion

        public DateTime? LastUpdateCheck
        {
            set
            {
                LocalSettings.Set(LocalSettingKeys.LastUpdateCheck, value.Value.Ticks);
            }

            get
            {
                var ticks = LocalSettings.Get(LocalSettingKeys.LastUpdateCheck) as long?;
                if (ticks == null) return null;
                return new DateTime(ticks.Value);
            }
        }

        public AppVersion CurrentAppLatestAvailableVersion { get; set; }

        public bool IsCheckingForUpdates { get; set; }

        private UpdateService()
        {
            _userService = new Remote.Wcf.UserService();
        }

        public async Task CheckForCurrentAppUpdatesAsync()
        {
            AppVersion latestAppVersion;
            var appGuids = new Guid[] { CurrentApplication.Guid };
            CheckForUpdateStarted();

            try
            {
                latestAppVersion = (await _userService.GetAppsLatestVersionInfoAsync(appGuids)).FirstOrDefault();
                if (latestAppVersion == null)
                    throw new Exception("PaasteelNotFound");
                LastUpdateCheck = DateTime.Now;
                CurrentAppLatestAvailableVersion = latestAppVersion;

                if (CurrentApplication.Version < latestAppVersion.GetVersion() && UpdateIsAvailable != null)
                {
                    UpdateIsAvailable(latestAppVersion);
                }
            }
            finally
            {
                CheckForUpdateFinished();
            }
        }

        private void CheckForUpdateStarted()
        {
            IsCheckingForUpdates = true;
            if (CheckForUpdatesStarted != null)
                CheckForUpdatesStarted(this, null);
        }

        private void CheckForUpdateFinished()
        {
            IsCheckingForUpdates = false;
            if (CheckForUpdatesFinished != null)
                CheckForUpdatesFinished(this, null);
        }
    }
}
