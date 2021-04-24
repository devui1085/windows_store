using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Store.DataContract
{
    [DataContract]
    public class AppDetailDataContract
    {
        [DataMember]
        public AppSpecificationDataContract AppSpecificationDataContract { get; set; }

        [DataMember]
        public AppIconDataContract AppIconDataContract { get; set; }

        [DataMember]
        public AppPlatformSpecificationDataContract AppPlatformSpecificationDataContract { get; set; }

        [DataMember]
        public AppVersionDataContract AppVersionDataContract { get; set; }


    }
}
