using Store.DomainModel.Entity;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Store.DataContract
{
    [DataContract]
    public class ServerDescriptorDataContract
    {
        [DataMember]
        public string SupportedUserClientMinVersion { get; set; }

        [DataMember]
        public string SupportedUserClientMaxVersion { get; set; }

        [DataMember]
        public string SupportedDeveloperClientMinVersion { get; set; }

        [DataMember]
        public string SupportedDeveloperClientMaxVersion { get; set; }

        [DataMember]
        public IEnumerable<AppCategoryDataContract> AppCategories { get; set; }

    }
}
