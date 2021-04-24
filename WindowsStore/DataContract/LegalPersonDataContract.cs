using System.Runtime.Serialization;

namespace Store.DataContract
{
    [DataContract]
    public class LegalPersonDataContract 
    {
        [DataMember]
        public int Id { set; get; }

        [DataMember]
        public string Name { set; get; }

        [DataMember]
        public string PrimaryEmail { set; get; }

    }

}
