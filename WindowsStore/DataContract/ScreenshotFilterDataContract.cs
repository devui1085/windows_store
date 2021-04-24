using System.Runtime.Serialization;
using Store.Common.Enum;
using System;

namespace Store.DataContract
{
    [DataContract]
    public class ScreenshotFilterDataContract : FilterDataContractBase
    {
        [DataMember]
        public int AppId { get; set; }

        [DataMember]
        public Guid AppGuid { set; get; }

        [DataMember]
        public int ScreenshotId { get; set; }

        [DataMember]
        public ScreenshotType ScreenshotType  { set; get; }

        [DataMember]
        public ScreenshotSize ScreenshotSize  { set; get; }

        [DataMember]
        public int ScreenshotIndex  { set; get; }
    }
}
