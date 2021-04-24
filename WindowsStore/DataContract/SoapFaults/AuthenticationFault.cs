using System.Runtime.Serialization;

namespace Store.DataContract.SoapFaults
{
    [DataContract]
    public class AuthenticationFault
    {
        [DataMember]
        public string Reason { get; set; }

        [DataMember]
        public string Message { get; set; }
    }
}