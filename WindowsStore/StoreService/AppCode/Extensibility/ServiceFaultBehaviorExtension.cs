using System;
using System.ServiceModel.Configuration;

namespace Store.StoreService.AppCode.Extensibility
{
    public class ServiceFaultBehaviorExtension : BehaviorExtensionElement
    {
        public override Type BehaviorType => typeof(ServiceFaultBehavior);

        protected override object CreateBehavior()
        {
            return new ServiceFaultBehavior();
        }
    }
}