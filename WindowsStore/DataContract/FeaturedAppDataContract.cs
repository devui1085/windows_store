using System;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace Store.DataContract
{
    [DataContract]
    public class FeaturedAppDataContract
    {
        [DataMember]
        public Guid AppGuid { set; get; }

        [DataMember]
        public string Description { set; get; }

    }

}
