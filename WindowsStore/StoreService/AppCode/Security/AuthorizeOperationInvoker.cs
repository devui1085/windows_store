using System;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Dispatcher;
using Store.Common.InternalException;
using Store.DataContract.SoapFaults;
using FaultCode= Store.Common.Enum.FaultCode;

namespace Store.StoreService.AppCode.Security
{
    public class AuthorizeOperationInvoker : IOperationInvoker
    {
        readonly IOperationInvoker _innerOperationInvoker;
        readonly string _operationName;
        readonly string[] _roleNames;

        public AuthorizeOperationInvoker(IOperationInvoker innerOperationInvoker, string operationName, string roleNames)
        {
            _innerOperationInvoker = innerOperationInvoker;
            _operationName = operationName;
            _roleNames = roleNames.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        }

        public bool IsSynchronous => _innerOperationInvoker.IsSynchronous;

        public object[] AllocateInputs()
        {
            return _innerOperationInvoker.AllocateInputs();
        }

        public object Invoke(object instance, object[] inputs, out object[] outputs)
        {
            object val;

            if (!Principal.IsAuthenticated)
            {
                throw new GeneralInternalException(FaultCode.NotAuthenticated);
            }

            if (_roleNames == null || _roleNames.Any(r => Principal.CurrentUser.Roles.Contains(r)))
            {
                val = _innerOperationInvoker.Invoke(instance, inputs, out outputs);
            }
            else
            {
                throw new GeneralInternalException(FaultCode.Unauthorized);
                /*
                //throw new FaultException<AuthorizationFault>(new AuthorizationFault()
                //{
                //    Message = "Authorization Failed",
                //    Operation = _operationName,
                //    Reason = "Authorization Expired"
                //});
                */
            }

            outputs = new object[0];

            return val;
        }

        public IAsyncResult InvokeBegin(object instance, object[] inputs, AsyncCallback callback, object state)
        {
            throw new NotImplementedException();
        }

        public object InvokeEnd(object instance, out object[] outputs, IAsyncResult result)
        {
            throw new NotImplementedException();
        }
    }
}