using Store.DataContract;
using Store.DomainModel.Entity;
using Store.DomainModel.EntityFilter;

namespace Store.DomainService.Mapper
{
    internal static class UserClientDescriptorMapper
    {
        public static Device GetDevice(this UserClientDescriptorDataContract userClientDescriptorDC)
        {
            return new Device()
            {
                DeviceId = userClientDescriptorDC.DeviceId,
                FriendlyName = userClientDescriptorDC.FriendlyName,
                OperatingSystem = userClientDescriptorDC.OperatingSystem,
                SystemFirmwareVersion = userClientDescriptorDC.SystemFirmwareVersion,
                SystemHardwareVersion = userClientDescriptorDC.SystemHardwareVersion,
                SystemManufacturer = userClientDescriptorDC.SystemManufacturer,
                SystemProductName = userClientDescriptorDC.SystemProductName,
                SystemSku = userClientDescriptorDC.SystemSku,
                PaasteelVersion = userClientDescriptorDC.PaasteelVersion,
                AutomaticUpdateEnabled = userClientDescriptorDC.AutomaticUpdateEnabled,
                CpuArchitecture = userClientDescriptorDC.CpuArchitecture
            };
        }
    }
}
