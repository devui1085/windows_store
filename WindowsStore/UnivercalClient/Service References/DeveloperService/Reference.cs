﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This code was auto-generated by Microsoft.VisualStudio.ServiceReference.Platforms, version 14.0.23107.0
// 
namespace App1.DeveloperService {
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="NaturalPersonDataContract", Namespace="http://schemas.datacontract.org/2004/07/Store.StoreService.DataContracts")]
    public partial class NaturalPersonDataContract : object, System.ComponentModel.INotifyPropertyChanged {
        
        private System.Nullable<byte> AgeField;
        
        private string FirstNameField;
        
        private int IdField;
        
        private string LastNameField;
        
        private string NationalCodeField;
        
        private string PasswordField;
        
        private string PrimaryEmailField;
        
        private App1.DeveloperService.Sexuality SexualityField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.Nullable<byte> Age {
            get {
                return this.AgeField;
            }
            set {
                if ((this.AgeField.Equals(value) != true)) {
                    this.AgeField = value;
                    this.RaisePropertyChanged("Age");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string FirstName {
            get {
                return this.FirstNameField;
            }
            set {
                if ((object.ReferenceEquals(this.FirstNameField, value) != true)) {
                    this.FirstNameField = value;
                    this.RaisePropertyChanged("FirstName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Id {
            get {
                return this.IdField;
            }
            set {
                if ((this.IdField.Equals(value) != true)) {
                    this.IdField = value;
                    this.RaisePropertyChanged("Id");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string LastName {
            get {
                return this.LastNameField;
            }
            set {
                if ((object.ReferenceEquals(this.LastNameField, value) != true)) {
                    this.LastNameField = value;
                    this.RaisePropertyChanged("LastName");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string NationalCode {
            get {
                return this.NationalCodeField;
            }
            set {
                if ((object.ReferenceEquals(this.NationalCodeField, value) != true)) {
                    this.NationalCodeField = value;
                    this.RaisePropertyChanged("NationalCode");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Password {
            get {
                return this.PasswordField;
            }
            set {
                if ((object.ReferenceEquals(this.PasswordField, value) != true)) {
                    this.PasswordField = value;
                    this.RaisePropertyChanged("Password");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string PrimaryEmail {
            get {
                return this.PrimaryEmailField;
            }
            set {
                if ((object.ReferenceEquals(this.PrimaryEmailField, value) != true)) {
                    this.PrimaryEmailField = value;
                    this.RaisePropertyChanged("PrimaryEmail");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public App1.DeveloperService.Sexuality Sexuality {
            get {
                return this.SexualityField;
            }
            set {
                if ((this.SexualityField.Equals(value) != true)) {
                    this.SexualityField = value;
                    this.RaisePropertyChanged("Sexuality");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Sexuality", Namespace="http://schemas.datacontract.org/2004/07/Store.Common.Enum")]
    public enum Sexuality : byte {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Male = 1,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Female = 2,
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="SessionFault", Namespace="http://schemas.datacontract.org/2004/07/WindowsStore.StoreService.DataContracts.S" +
        "oapFaults")]
    public partial class SessionFault : object, System.ComponentModel.INotifyPropertyChanged {
        
        private string SessionMessageField;
        
        private string SessionOperationField;
        
        private string SessionReasonField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string SessionMessage {
            get {
                return this.SessionMessageField;
            }
            set {
                if ((object.ReferenceEquals(this.SessionMessageField, value) != true)) {
                    this.SessionMessageField = value;
                    this.RaisePropertyChanged("SessionMessage");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string SessionOperation {
            get {
                return this.SessionOperationField;
            }
            set {
                if ((object.ReferenceEquals(this.SessionOperationField, value) != true)) {
                    this.SessionOperationField = value;
                    this.RaisePropertyChanged("SessionOperation");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string SessionReason {
            get {
                return this.SessionReasonField;
            }
            set {
                if ((object.ReferenceEquals(this.SessionReasonField, value) != true)) {
                    this.SessionReasonField = value;
                    this.RaisePropertyChanged("SessionReason");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="Paasteel.com", ConfigurationName="DeveloperService.IDeveloperService")]
    public interface IDeveloperService {
        
        [System.ServiceModel.OperationContractAttribute(Action="Paasteel.com/IDeveloperService/RegisterNaturalPerson", ReplyAction="Paasteel.com/IDeveloperService/RegisterNaturalPersonResponse")]
        System.Threading.Tasks.Task RegisterNaturalPersonAsync(App1.DeveloperService.NaturalPersonDataContract dataContract);
        
        [System.ServiceModel.OperationContractAttribute(Action="Paasteel.com/IDeveloperService/GetName", ReplyAction="Paasteel.com/IDeveloperService/GetNameResponse")]
        System.Threading.Tasks.Task<string> GetNameAsync(int x);
        
        [System.ServiceModel.OperationContractAttribute(Action="Paasteel.com/IDeveloperService/SetSession", ReplyAction="Paasteel.com/IDeveloperService/SetSessionResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(App1.DeveloperService.SessionFault), Action="Paasteel.com/IDeveloperService/SetSessionSessionFaultFault", Name="SessionFault", Namespace="http://schemas.datacontract.org/2004/07/WindowsStore.StoreService.DataContracts.S" +
            "oapFaults")]
        System.Threading.Tasks.Task SetSessionAsync(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="Paasteel.com/IDeveloperService/GetSession", ReplyAction="Paasteel.com/IDeveloperService/GetSessionResponse")]
        System.Threading.Tasks.Task<string> GetSessionAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="Paasteel.com/IDeveloperService/SetRealSession", ReplyAction="Paasteel.com/IDeveloperService/SetRealSessionResponse")]
        [System.ServiceModel.FaultContractAttribute(typeof(App1.DeveloperService.SessionFault), Action="Paasteel.com/IDeveloperService/SetRealSessionSessionFaultFault", Name="SessionFault", Namespace="http://schemas.datacontract.org/2004/07/WindowsStore.StoreService.DataContracts.S" +
            "oapFaults")]
        System.Threading.Tasks.Task SetRealSessionAsync(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="Paasteel.com/IDeveloperService/GetRealSession", ReplyAction="Paasteel.com/IDeveloperService/GetRealSessionResponse")]
        System.Threading.Tasks.Task<string> GetRealSessionAsync();
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IDeveloperServiceChannel : App1.DeveloperService.IDeveloperService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class DeveloperServiceClient : System.ServiceModel.ClientBase<App1.DeveloperService.IDeveloperService>, App1.DeveloperService.IDeveloperService {
        
        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public DeveloperServiceClient() : 
                base(DeveloperServiceClient.GetDefaultBinding(), DeveloperServiceClient.GetDefaultEndpointAddress()) {
            this.Endpoint.Name = EndpointConfiguration.NetHttpBinding_IDeveloperService.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public DeveloperServiceClient(EndpointConfiguration endpointConfiguration) : 
                base(DeveloperServiceClient.GetBindingForEndpoint(endpointConfiguration), DeveloperServiceClient.GetEndpointAddress(endpointConfiguration)) {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public DeveloperServiceClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(DeveloperServiceClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress)) {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public DeveloperServiceClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(DeveloperServiceClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress) {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public DeveloperServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public System.Threading.Tasks.Task RegisterNaturalPersonAsync(App1.DeveloperService.NaturalPersonDataContract dataContract) {
            return base.Channel.RegisterNaturalPersonAsync(dataContract);
        }
        
        public System.Threading.Tasks.Task<string> GetNameAsync(int x) {
            return base.Channel.GetNameAsync(x);
        }
        
        public System.Threading.Tasks.Task SetSessionAsync(string name) {
            return base.Channel.SetSessionAsync(name);
        }
        
        public System.Threading.Tasks.Task<string> GetSessionAsync() {
            return base.Channel.GetSessionAsync();
        }
        
        public System.Threading.Tasks.Task SetRealSessionAsync(string name) {
            return base.Channel.SetRealSessionAsync(name);
        }
        
        public System.Threading.Tasks.Task<string> GetRealSessionAsync() {
            return base.Channel.GetRealSessionAsync();
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync() {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        public virtual System.Threading.Tasks.Task CloseAsync() {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginClose(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndClose));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration) {
            if ((endpointConfiguration == EndpointConfiguration.NetHttpBinding_IDeveloperService)) {
                System.ServiceModel.Channels.CustomBinding result = new System.ServiceModel.Channels.CustomBinding();
                result.Elements.Add(new System.ServiceModel.Channels.BinaryMessageEncodingBindingElement());
                System.ServiceModel.Channels.HttpTransportBindingElement httpBindingElement = new System.ServiceModel.Channels.HttpTransportBindingElement();
                httpBindingElement.AllowCookies = true;
                httpBindingElement.MaxBufferSize = int.MaxValue;
                httpBindingElement.MaxReceivedMessageSize = int.MaxValue;
                result.Elements.Add(httpBindingElement);
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration) {
            if ((endpointConfiguration == EndpointConfiguration.NetHttpBinding_IDeveloperService)) {
                return new System.ServiceModel.EndpointAddress("http://localhost:1578/Service/DeveloperService.svc/~/Service/Developer.svc");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding() {
            return DeveloperServiceClient.GetBindingForEndpoint(EndpointConfiguration.NetHttpBinding_IDeveloperService);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress() {
            return DeveloperServiceClient.GetEndpointAddress(EndpointConfiguration.NetHttpBinding_IDeveloperService);
        }
        
        public enum EndpointConfiguration {
            
            NetHttpBinding_IDeveloperService,
        }
    }
}