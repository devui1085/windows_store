using Store.Common.Enum;
using System.Runtime.Serialization;

namespace Store.DataContract
{
    [DataContract]
    public class AuthenticationResultDataContract
    {
        [DataMember]
        public bool Authenticated { get; set; }
        [DataMember]
        public UserAccountStatus UserAccountStatus { get; set; }

        public int UserId { set; get; }

        [DataMember]
        public string PrimaryEmail { set; get; }

        [DataMember]
        public bool IsNaturalPerson { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember] 
        public string LastName { get; set; }

        [DataMember]
        public string Name { get; set; }
        //[DataMember]
        //public PersonDataContract UserIdentity { get; set; }
    }
}
