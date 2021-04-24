using Store.Common.Enum;
using System;
using System.Collections.Generic;

namespace Store.DomainModel.Entity
{
    public partial class Device
    {
        public Device()
        {
        }

        public int Id { get; set; }
        public Guid DeviceId { get; set; }
        public string OperatingSystem { get; set; }
        public string FriendlyName { get; set; }
        public string SystemFirmwareVersion { get; set; }
        public string SystemHardwareVersion { get; set; }
        public string SystemManufacturer { get; set; }
        public string SystemProductName { get; set; }
        public string SystemSku { get; set; }
        public string PaasteelVersion { get; set; }
        public bool AutomaticUpdateEnabled { get; set; }
        public CpuArchitecture CpuArchitecture { get; set; }
    }
}
