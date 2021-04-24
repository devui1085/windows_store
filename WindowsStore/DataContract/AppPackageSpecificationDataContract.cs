using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Store.DataContract
{
    [DataContract]
    public class AppPackageSpecificationDataContract
    {
        [DataMember]
        public int AppId { get; set; }

        [DataMember]
        public bool HasX64Package { get; set; }

        [DataMember]
        public bool HasX86Package { get; set; }

        [DataMember]
        public bool HasArmPackage { get; set; }

        [DataMember]
        public bool IsX64PackageMandatory { get; set; }

        [DataMember]
        public bool IsX86PackageMandatory { get; set; }

        [DataMember]
        public bool IsArmPackageMandatory { get; set; }
    }
}
