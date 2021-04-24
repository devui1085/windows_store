using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsStore.Client.User.Common.ExtensionMethod;
using WindowsStore.Client.User.Common.PresentationModel;
using WindowsStore.Client.User.Service.ApplicationService;
using WindowsStore.Client.User.Service.Local;

namespace WindowsStore.Client.User.Service.ApplicationService.Initilize
{
    public static class DeviceRegistrationServiceInitializer
    {
        static DeviceRegistrationServiceInitializer()
        {

        }

        public static void Initialize()
        {
            DeviceRegistrationService.Instance.DeviceRegistered += appRegistrationService_DeviceRegistered;
            var task = DeviceRegistrationService.Instance.RegisterDeviceAsync();
        }

        private static void appRegistrationService_DeviceRegistered(Common.PresentationModel.ServerDescriptor serverDescriptor)
        {
            var minVersion = serverDescriptor.SupportedUserClientMinVersion.ToVersion();
            if (CurrentApplication.Version >= minVersion)
                return;

            // Mandatory update is available for paasteel
            var downloadTask = AppDownloadManager.Instance.StartDownloadPaasteelAsync();
        }
    }
}
