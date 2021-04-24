using System.Runtime.Serialization;

namespace Store.DataContract.SoapFaults
{
    [DataContract]
   public class AuthorizationFault
    {
        [DataMember]
        public string Operation { get; set; }

        [DataMember]
        public string Reason { get; set; }

        [DataMember]
        public string Message { get; set; }
    }
}
