using Store.Common.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Store.DataContract
{
    [DataContract]
    public class ScreenshotDataContract
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int AppId { get; set; }

        [DataMember]
        public string FileName { get; set; }

        [DataMember]
        public byte[] ImageSource { get; set; }

        [DataMember]
        public byte[] Original { get; set; }

        [DataMember]
        public byte[] Thumbnail { get; set; }


        [DataMember]
        public ScreenshotType ScreenshotType { get; set; }

        [DataMember]
        public ScreenshotSize ScreenshotSize{ get; set; }

        [DataMember]
        public Guid AppGuid { get; set; }
    }
}
