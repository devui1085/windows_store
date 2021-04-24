using System;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;


namespace Store.StoreService.AppCode.Security
{
    public class AuthorizeOperationBehaviorAttribute : Attribute, IOperationBehavior
    {
        public string RoleNames { get; set;}
        public void AddBindingParameters(OperationDescription operationDescription, BindingParameterCollection bindingParameters)
        {
    
        }

        public void ApplyClientBehavior(OperationDescription operationDescription, ClientOperation clientOperation)
        {
         
        }

        public void ApplyDispatchBehavior(OperationDescription operationDescription, DispatchOperation dispatchOperation)
        {
            var operationFullName = operationDescription.DeclaringContract.Namespace + "/" +
                operationDescription.DeclaringContract.Name + "/" + operationDescription.Name;

            dispatchOperation.Invoker =
       new AuthorizeOperationInvoker(dispatchOperation.Invoker, operationFullName, this.RoleNames);
        }

        public void Validate(OperationDescription operationDescription)
        {
     
        }
    }
}