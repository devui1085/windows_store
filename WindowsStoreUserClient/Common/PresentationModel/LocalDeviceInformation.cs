using System;
using Windows.System;
using WindowsStore.Client.User.Common.Enum;

namespace WindowsStore.Client.User.Common.PresentationModel
{
    public class LocalDeviceInformation
    {
        public Guid DeviceId { get; set; }
        public string OperatingSystem { get; set; }
        public string FriendlyName { get; set; }
        public string SystemFirmwareVersion { get; set; }
        public string SystemHardwareVersion { get; set; }
        public string SystemManufacturer { get; set; }
        public string SystemProductName { get; set; }
        public string SystemSku { get; set; }
        public ProcessorArchitecture ProcessorArchitecture { get; set; }
    }
}