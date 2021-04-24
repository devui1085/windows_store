using System.Runtime.Serialization;

namespace Store.DataContract
{
    [DataContract]
   public class PersonDataContract
    {
        [DataMember]
        public int Id { set; get; }

        [DataMember]
        public string PrimaryEmail { set; get; }

        [DataMember]
        public bool IsNaturalPerson { get; set; }

        [DataMember]
        public NaturalPersonDataContract NaturalPersonDataContract { get; set; }

        [DataMember]
        public LegalPersonDataContract LegalPersonDataContract { get; set; }
    }
}
