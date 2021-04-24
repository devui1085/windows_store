using System;
using Windows.System;
using Windows.UI.Xaml.Media.Imaging;
using WindowsStore.Client.User.Common.Infrastructure;

namespace WindowsStore.Client.User.Common.PresentationModel
{
    public class UserClientDescriptor : BindableBase
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

        public string PaasteelVersion { get; set; }

        public bool AutomaticUpdateEnabled { get; set; }

    }
}
