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
using WindowsStore.Client.User.UI.View.Interface;

namespace WindowsStore.Client.User.UI.ViewModel
{
    public class MainPageViewModel : ViewModelBase
    {
        string _pageTitle;

        public IMainPage View { get; set; }

        public MainPageViewModel()
        {
            DeviceRegistrationService.Instance.DeviceRegistered += appRegistrationService_DeviceRegistered;
            DeviceRegistrationService.Instance.DeviceRegisterationFailed += Instance_DeviceRegisterationFailed; ;

            AppDownloadManager.Instance.CurrentDownloads.CollectionChanged += CurrentDownloads_CollectionChanged;
            UserManager.Instance.SignInOperationCompleted += UserManager_SignInOperationCompleted;
            UserManager.Instance.SignedOutOperationCompleted += UserManager_UserSignedOut;
            UpdateService.Instance.UpdateIsAvailable += UpdateService_UpdateIsAvailable;
        }

        private void Instance_DeviceRegisterationFailed()
        {
            UiManager.HideLoading();
            UiManager.ShowModalMessage(
                "NoInternetAccessMessage".Localize(),
                "ReTry".Localize(), (object sender, EventArgs e) =>
                {
                    UiManager.HideModalMessage();
                    UiManager.ShowLoading();
                    var task = DeviceRegistrationService.Instance.RegisterDeviceAsync();
                });
        }

        private async void appRegistrationService_DeviceRegistered(ServerDescriptor serverDescriptor)
        {
            if (DeviceRegistrationService.Instance.IsMandatoryUpdateAvailable)
            {
                await View.NavigateToDownloadsPageForMandatoryUpdateAsync();
                return;
            }

            View.NavigateToHomePage();
        }

        private void UserManager_SignInOperationCompleted()
        {
            var um = UserManager.Instance;
            var content = um.IsSignedIn ? um.User.PrimaryEmail : "SignIn".Localize();
            View.ShowSignInButton(content);
        }

        private void UpdateService_UpdateIsAvailable(AppVersion appVersion)
        {
        }

        private void CurrentDownloads_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            base.RaisePropertyChanged("CurrentDownloadsCount");
        }

        private void UserManager_UserSignedOut()
        {
            View.ShowSignInButton("SignIn".Localize());
        }

        public string PageTitle
        {
            set
            {
                _pageTitle = value;
                base.RaisePropertyChanged();
            }

            get
            {
                return _pageTitle;
            }
        }

        public int CurrentDownloadsCount
        {
            get
            {
                return AppDownloadManager.Instance.CurrentDownloads.Count;
            }
        }

        public bool AreInteractiveControlsEnabled
        {
            get
            {
                return View.AreInteractiveControlsEnabled;
            }

            set
            {
                View.AreInteractiveControlsEnabled = value;
            }
        }

        public void ShowModalMessage(string message, string firstActionText, EventHandler firstActionClickEventHandler)
        {
            View.ShowModalMessage(message, firstActionText, firstActionClickEventHandler);
        }

        internal void HideModalMessage()
        {
            View.HideModalMessage();
        }
    }
}
