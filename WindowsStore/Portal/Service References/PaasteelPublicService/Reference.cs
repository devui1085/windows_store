﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Portal.PaasteelPublicService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="PaasteelPublicService.IPublicService")]
    public interface IPublicService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPublicService/UpPaasteelUserAppDownloadNumberById", ReplyAction="http://tempuri.org/IPublicService/UpPaasteelUserAppDownloadNumberByIdResponse")]
        void UpPaasteelUserAppDownloadNumberById(int appId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPublicService/UpPaasteelUserAppDownloadNumberById", ReplyAction="http://tempuri.org/IPublicService/UpPaasteelUserAppDownloadNumberByIdResponse")]
        System.Threading.Tasks.Task UpPaasteelUserAppDownloadNumberByIdAsync(int appId);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPublicService/UpPaasteelUserAppDownloadNumberByGuid", ReplyAction="http://tempuri.org/IPublicService/UpPaasteelUserAppDownloadNumberByGuidResponse")]
        void UpPaasteelUserAppDownloadNumberByGuid(System.Guid guid);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IPublicService/UpPaasteelUserAppDownloadNumberByGuid", ReplyAction="http://tempuri.org/IPublicService/UpPaasteelUserAppDownloadNumberByGuidResponse")]
        System.Threading.Tasks.Task UpPaasteelUserAppDownloadNumberByGuidAsync(System.Guid guid);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IPublicServiceChannel : Portal.PaasteelPublicService.IPublicService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class PublicServiceClient : System.ServiceModel.ClientBase<Portal.PaasteelPublicService.IPublicService>, Portal.PaasteelPublicService.IPublicService {
        
        public PublicServiceClient() {
        }
        
        public PublicServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public PublicServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PublicServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public PublicServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void UpPaasteelUserAppDownloadNumberById(int appId) {
            base.Channel.UpPaasteelUserAppDownloadNumberById(appId);
        }
        
        public System.Threading.Tasks.Task UpPaasteelUserAppDownloadNumberByIdAsync(int appId) {
            return base.Channel.UpPaasteelUserAppDownloadNumberByIdAsync(appId);
        }
        
        public void UpPaasteelUserAppDownloadNumberByGuid(System.Guid guid) {
            base.Channel.UpPaasteelUserAppDownloadNumberByGuid(guid);
        }
        
        public System.Threading.Tasks.Task UpPaasteelUserAppDownloadNumberByGuidAsync(System.Guid guid) {
            return base.Channel.UpPaasteelUserAppDownloadNumberByGuidAsync(guid);
        }
    }
}
