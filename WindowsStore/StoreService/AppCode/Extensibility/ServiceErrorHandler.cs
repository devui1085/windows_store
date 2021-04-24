using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using Store.Common.InternalException;
using Store.Common.Loggers;
using Store.DataContract.SoapFaults;

namespace Store.StoreService.AppCode.Extensibility
{
    public class ServiceErrorHandler : IErrorHandler 
    {
        public ServiceErrorHandler(ServiceFaultBehavior behaviour)
        {
        }

        public void ProvideFault(Exception error, MessageVersion version, ref Message fault)
        {
            var exception = error as GeneralInternalException;
            if (exception == null)
            {
                // log exception
                AppLogger.Error(error);

                var serverInternalFault = new FaultException("Internal Server Error!");

                MessageFault messageFault = serverInternalFault.CreateMessageFault();
                fault = Message.CreateMessage(version, messageFault, null);
            }
            else
            {
                var generalInternalFault = new FaultException<GeneralInternalFault>(new GeneralInternalFault()
                {
                    FaultCode = exception.FaultCode
                });

                MessageFault messageFault = generalInternalFault.CreateMessageFault();
                fault = Message.CreateMessage(version, messageFault, null);
            }
        }

        public bool HandleError(Exception error)
        {
            //return error is GeneralInternalException;
            return true;
        }
    }
}