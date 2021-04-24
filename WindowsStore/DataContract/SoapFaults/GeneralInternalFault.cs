using System.Runtime.Serialization;
using Store.Common.Enum;

namespace Store.DataContract.SoapFaults
{
    [DataContract]
    public class GeneralInternalFault
    {
      
        [DataMember]
        public  FaultCode FaultCode { get; set; }
    }
}