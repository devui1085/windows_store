using System;
using Store.Common.Enum;

namespace Store.Common.InternalException
{
    public class GeneralInternalException : Exception
    {
        public GeneralInternalException(FaultCode faultCode)
        {
            FaultCode = faultCode;
        }
        public FaultCode FaultCode { get; set; }
    }
}
