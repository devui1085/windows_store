using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using WindowsStore.Client.User.Common.Enum;
using WindowsStore.Client.User.Common.ExtensionMethod;
using WindowsStore.Client.User.Common.Infrastructure;
using WindowsStore.Client.User.Common.PresentationModel;
using WindowsStore.Client.User.Service.Local;
using WindowsStore.Client.User.Service.Remote.Wcf;

namespace WindowsStore.Client.User.Service.ApplicationService
{
    public class DeviceRegistrationService
    {
        static DeviceRegistrationService _instance;
        Remote.Wcf.UserService _userService;

        #region Delegates
        public delegate void DeviceRegisteredEventHandler(ServerDescriptor serverDescriptor);
        #endregion

        #region Events
        public event DeviceRegisteredEventHandler DeviceRegistered;
        public event Action DeviceRegisterationFailed;
        #endregion

        #region Properties
        public bool IsDeviceRegistered { get; set; }
        public ServerDescriptor ServerDescriptor { get; set; }

        public bool IsMandatoryUpdateAvailable
        {
            get
            {
                return CurrentApplication.Version < ServerDescriptor.SupportedUserClientMinVersion.ToVersion();
            }
        }
        #endregion

        public static DeviceRegistrationService Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new DeviceRegistrationService();
                return _instance;
            }
        }

        public DeviceRegistrationService()
        {
            _userService = new Remote.Wcf.UserService();
        }

        public async Task<ServerDescriptor> RegisterDeviceAsync()
        {
            try {
                var device = LocalDeviceInfo.GetDeviceInfo();
                var descriptor = new UserClientDescriptor()
                {
                    DeviceId = device.DeviceId,
                    OperatingSystem = device.OperatingSystem,
                    FriendlyName = device.FriendlyName,
                    SystemFirmwareVersion = device.SystemFirmwareVersion,
                    SystemHardwareVersion = device.SystemFirmwareVersion,
                    SystemManufacturer = device.SystemManufacturer,
                    SystemProductName = device.SystemProductName,
                    SystemSku = device.SystemSku,
                    ProcessorArchitecture = device.ProcessorArchitecture,
                    PaasteelVersion = CurrentApplication.Version.ToString(),
                    AutomaticUpdateEnabled = SettingManager.AutomaticallyUpdateCurrentApp,
                };
                ServerDescriptor = await _userService.RegisterDeviceAsync(descriptor);
            }
            catch {
                ServerDescriptor = null;
            }
            IsDeviceRegistered = ServerDescriptor != null ? true : false;

            // Raise events
            if (IsDeviceRegistered && DeviceRegistered != null) {
                DeviceRegistered(ServerDescriptor);
            }
            if (!IsDeviceRegistered && DeviceRegisterationFailed != null) {
                DeviceRegisterationFailed();
            }

            return ServerDescriptor;
        }
    }
}
