using System;
using System.Runtime.Serialization;
using Store.Common.Enum;

namespace Store.DataContract
{
    [DataContract]
    public class AppVersionDataContract
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public Guid AppGuid { get; set; }

        [DataMember]
        public string Version { get; set; }

        [DataMember]
        public DateTime PublishDate { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public int AppId { get; set; }

        [DataMember]
        public int Downloads { get; set; }

        [DataMember]
        public long Size { get; set; }

        [DataMember]
        public long? ArmPackageSize { get; set; }

        [DataMember]
        public long? X64PackageSize { get; set; }

        [DataMember]
        public long? X86PackageSize { get; set; }

        [DataMember]
        public CpuArchitecture? CpuArchitectureFlags { get; set; }

        [DataMember]
        public bool HasX64Package { get; set; }

        [DataMember]
        public bool HasX86Package { get; set; }

        [DataMember]
        public bool HasArmPackage { get; set; }
    }
}
