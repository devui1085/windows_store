using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Store.Common.Enum;
using Store.DomainModel.Entity;

namespace Store.DataContract
{
    [DataContract]
    public class AppPlatformSpecificationDataContract
    {
        public AppPlatformSpecificationDataContract()
        {
            CpuArchitectureFlags = CpuArchitecture.None;
        }

        [DataMember]
        public int AppId { get; set; }

        [DataMember]
        public CpuArchitecture? CpuArchitectureFlags { get; set; }

        [DataMember]
        public IEnumerable<int> PlatformCategories { get; set; }
    }
}
