using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.Foundation;
using Windows.Graphics.Display;
using Windows.Security.ExchangeActiveSyncProvisioning;
using Windows.System;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using WindowsStore.Client.User.Common.Enum;
using WindowsStore.Client.User.Common.PresentationModel;

namespace WindowsStore.Client.User.Service.Local
{
    public static class LocalDeviceInfo
    {
        private static ProcessorArchitecture GetProcessorArchitecture()
        {
            if (Package.Current.Id.Architecture == ProcessorArchitecture.Arm)
                return ProcessorArchitecture.Arm;
            return Marshal.SizeOf<IntPtr>() == 8 ? ProcessorArchitecture.X64 : ProcessorArchitecture.X86;
        }

        public static LocalDeviceInformation GetDeviceInfo()
        {
            EasClientDeviceInformation eas = new EasClientDeviceInformation();
            return new LocalDeviceInformation()
            {
                DeviceId = eas.Id,
                OperatingSystem = eas.OperatingSystem,
                FriendlyName = eas.FriendlyName,
                SystemFirmwareVersion = eas.SystemFirmwareVersion,
                SystemHardwareVersion = eas.SystemFirmwareVersion,
                SystemManufacturer = eas.SystemManufacturer,
                SystemProductName = eas.SystemProductName,
                SystemSku = eas.SystemSku,
                ProcessorArchitecture = GetProcessorArchitecture()
            };
        }
    }
}
