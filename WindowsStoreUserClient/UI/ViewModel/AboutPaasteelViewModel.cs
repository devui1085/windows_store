using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI;
using Windows.UI.Xaml.Data;
using WindowsStore.Client.User.Common.ExtensionMethod;
using WindowsStore.Client.User.Common.Infrastructure;
using WindowsStore.Client.User.Common.PresentationModel;
using WindowsStore.Client.User.Service.ApplicationService;
using WindowsStore.Client.User.Service.Local;
using WindowsStore.Client.User.UI.Infrastructure;
using WindowsStore.Client.User.UI.Infrastructure.ExtensionMethod;
using WindowsStore.Client.User.UI.View.Interface;

namespace WindowsStore.Client.User.UI.ViewModel
{
    public class AboutPaasteelViewModel : ViewModelBase
    {
        UpdateService updateService;
        public IAboutPaasteelPage View { get; set; }
        public string PaasteelVersion
        {
            get
            {
                var v = CurrentApplication.Version;
                return string.Format("{0}.{1}.{2}", v.Major, v.Minor, v.Build);
            }
        }

        public string LastUpdateCheck
        {
            get
            {
                var lastCheck = updateService.LastUpdateCheck;
                return lastCheck == null ? "NotChecked".Localize() : lastCheck.Value.ToString();
            }
        }

        public bool IsCheckingForUpdates
        {
            get
            {
                return updateService.IsCheckingForUpdates;
            }
        }

        public AboutPaasteelViewModel()
        {
            updateService = UpdateService.Instance;
            updateService.CheckForUpdatesStarted += Instance_CheckForUpdatesStatusChanged;
            updateService.CheckForUpdatesFinished += Instance_CheckForUpdatesStatusChanged;
        }

        private void Instance_CheckForUpdatesStatusChanged(object sender, EventArgs e)
        {
            base.RaisePropertyChanged(nameof(IsCheckingForUpdates));
            CheckForUpdatesCommand.RaiseCanExecuteChanged(null);
        }

        #region CheckForUpdates Command
        public RelayCommand CheckForUpdatesCommand
        {
            get
            {
                return new RelayCommand(async (object obj) => await ExecuteCheckForUpdatesCommandAsync(obj), CanExecuteCheckForUpdatesCommand);
            }
        }

        private async Task ExecuteCheckForUpdatesCommandAsync(object obj)
        {
            try
            {
                await updateService.CheckForCurrentAppUpdatesAsync();
            }
            catch (Exception exp)
            {
                View.ShowCheckForUpdateErrorMessage();
                return;
            }

            RaisePropertyChanged(nameof(LastUpdateCheck));
            if (updateService.IsUpdateAvailableForCurrentApp)
            {
                var version = updateService.CurrentAppLatestAvailableVersion.GetVersion();
                await View.ShowUpdateIsAvailableMessageAsync(
                    string.Format("NewUpdateIsAvailableMessage".Localize(),
                    version.Major,
                    version.Minor,
                    version.Build));
            }
            else
            {
                View.ShowYouHaveLatestVersionMessage();
            }
        }

        private bool CanExecuteCheckForUpdatesCommand(object obj)
        {
            return !updateService.IsCheckingForUpdates;
        }
        #endregion

        public async Task DownloadCurrentAppLatestVersionAsync()
        {
            await AppDownloadManager.Instance.StartDownloadAsync(new AppDownloadItem()
            {
                AppGuid = CurrentApplication.Guid,
                AppName = CurrentApplication.Name
            });
        }
    }
}
