using System;
using System.Runtime.Serialization;

namespace Store.DataContract
{
    [DataContract]
    public class AppDataContract
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public Guid Guid { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public AppCategoryDataContract AppCategory { get; set; }
        
        [DataMember]
        public string Description { get; set; }
        
        [DataMember]
        public byte[] Icon128X128 { get; set; }

        [DataMember]
        public byte[] Icon256X256 { get; set; }
        
        [DataMember]
        public int DeveloperId { get; set; }

        [DataMember]
        public string DeveloperName { get; set; }

        [DataMember]
        public AppVersionDataContract LatestVersion { get; set; }

        [DataMember]
        public int Price { get; set; }

        [DataMember]
        public int NumberOfMobileScreenshots { get; set; }


        [DataMember]
        public long Size { get; set; }
    }
}
