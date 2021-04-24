using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Store.DataContract
{
    [DataContract]
    public class AppVersionSpecificationDataContract
    {
        [DataMember]
        public int AppId { get; set; }

        [DataMember]
        public string Version { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public DateTime PublishDate { get; set; }
    }
}
