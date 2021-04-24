using Store.Common.Enum;
using System;
using System.Runtime.Serialization;

namespace Store.DataContract
{
    [DataContract]
    public class UserClientDescriptorDataContract
    {
        [DataMember]
        public Guid DeviceId { get; set; }

        [DataMember]
        public string OperatingSystem { get; set; }

        [DataMember]
        public string FriendlyName { get; set; }

        [DataMember]
        public string SystemFirmwareVersion { get; set; }

        [DataMember]
        public string SystemHardwareVersion { get; set; }

        [DataMember]
        public string SystemManufacturer { get; set; }

        [DataMember]
        public string SystemProductName { get; set; }

        [DataMember]
        public string SystemSku { get; set; }

        [DataMember]
        public CpuArchitecture CpuArchitecture { get; set; }

        [DataMember]
        public string PaasteelVersion { get; set; }

        [DataMember]
        public bool AutomaticUpdateEnabled { get; set; }
    }
}
