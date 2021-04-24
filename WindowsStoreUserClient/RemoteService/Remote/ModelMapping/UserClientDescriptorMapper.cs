using Windows.System;
using WindowsStore.Client.User.Common.PresentationModel;
using WindowsStore.Client.User.Service.UserService;

namespace WindowsStore.Client.User.Service.Remote.ModelMapping
{
    public static class UserClientDescriptorMapper
    {
        public static UserClientDescriptorDataContract GetUserClientrDescriptorDC(this UserClientDescriptor descriptor)
        {
            return new UserClientDescriptorDataContract()
            {
                DeviceId = descriptor.DeviceId,
                OperatingSystem = descriptor.OperatingSystem,
                FriendlyName = descriptor.FriendlyName,
                SystemFirmwareVersion = descriptor.SystemFirmwareVersion,
                SystemHardwareVersion = descriptor.SystemFirmwareVersion,
                SystemManufacturer = descriptor.SystemManufacturer,
                SystemProductName = descriptor.SystemProductName,
                SystemSku = descriptor.SystemSku,
                PaasteelVersion = descriptor.PaasteelVersion,
                AutomaticUpdateEnabled = descriptor.AutomaticUpdateEnabled,
                CpuArchitecture =
                    descriptor.ProcessorArchitecture == ProcessorArchitecture.Arm ? CpuArchitecture.Arm :
                    (descriptor.ProcessorArchitecture == ProcessorArchitecture.X86 ? CpuArchitecture.X86 : CpuArchitecture.X64),
            };
        }
    }
}
