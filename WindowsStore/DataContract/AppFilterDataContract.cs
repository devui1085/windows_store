using System.Runtime.Serialization;
using Store.Common.Enum;
using System;

namespace Store.DataContract
{
    [DataContract]
    public class AppFilterDataContract : FilterDataContractBase
    {
        [DataMember]
        public AppType? AppType { set; get; }

        [DataMember]
        public AppPricing? AppPricing { set; get; }

        [DataMember]
        public int? AppCategoryId { set; get; }

        [DataMember]
        public bool? FeaturedApp { get; set; }

        [DataMember]
        public AppOrderMethod? AppOrderMethod { set; get; }

        [DataMember]
        public bool Include128X128Icon { get; set; }

        [DataMember]
        public bool Include256X256Icon { get; set; }

        [DataMember]
        public int? AppId { get; set; }

        [DataMember]
        public bool IncludeAppPrice { get; set; }

        [DataMember]
        public Guid? AppGuid { get; set; }


    }
}
