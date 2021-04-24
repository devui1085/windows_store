
using System.Runtime.Serialization;

namespace Store.DataContract
{
    [DataContract]
    public class FilterDataContractBase
    {
        [DataMember]
        public int PageSize { get; set; }

        [DataMember]
        public int PageIndex { get; set; }
    }
}
