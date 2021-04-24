using Store.Common.Enum;
using System.Runtime.Serialization;

namespace Store.DataContract
{
    [DataContract]
    public class AppCategoryDataContract
    {
        [DataMember]
        public int Id;

        [DataMember]
        public string Title;

        [DataMember]
        public AppType AppType;
    }

}
