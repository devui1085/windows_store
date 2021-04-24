using Store.Common.Enum;
using System.Runtime.Serialization;

namespace Store.DataContract
{
    [DataContract]
    public class NaturalPersonDataContract 
    {
        [DataMember]
        public int Id { set; get; }

        [DataMember]
        public string PrimaryEmail { set; get; }

        [DataMember]
        public string FirstName;

        [DataMember]
        public string LastName { set; get; }

        [DataMember]
        public byte? Age { set; get; }

        [DataMember]
        public Sexuality? Sexuality { set; get; }

        [DataMember]
        public string NationalCode { set; get; }

    }

}
