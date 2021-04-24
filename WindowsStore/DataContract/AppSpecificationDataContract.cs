using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Store.Common.Enum;

namespace Store.DataContract
{
    [DataContract]
    public class AppSpecificationDataContract
    {
        [DataMember]
        public int AppId { get; set; }

        [DataMember]
        public Guid Guid { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public AppType AppType { get; set; }
        [DataMember]
        public int CategoryId { get; set; }

        [DataMember]
        public int Price { get; set; }

        [DataMember]
        public AppState State { get; set; }
        
        [DataMember]
        public int DownloadsCount { get; set; }
        [DataMember]
        public int CommentsCount { get; set; }

        [DataMember]
        public int ScreenshotsCount { get; set; }

        [DataMember]
        public int MobileScreenshotsCount { get; set; }

        [DataMember]
        public int DesktopScreenshotsCount { get; set; }
    }
}
