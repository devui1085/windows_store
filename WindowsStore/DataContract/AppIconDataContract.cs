using System.Runtime.Serialization;

namespace Store.DataContract
{
    [DataContract]
    public class AppIconDataContract
    {
        [DataMember]
        public int AppId { get; set; }

        [DataMember]
        public byte[] Icon128X128 { get; set; }

        [DataMember]
        public byte[] Icon256X256 { get; set; }
    }
}
