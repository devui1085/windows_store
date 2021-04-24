using System.ServiceModel;
using WindowsStore.Client.Developer.Logic.DeveloperService;

namespace WindowsStore.Client.Developer.Logic.Services
{
    public abstract class ServiceBase
    {
        IDeveloperService _developerService;

        protected IDeveloperService RemoteDeveloperService
        {
            get
            {
                var developerServiceClient = _developerService as DeveloperServiceClient;
                if (developerServiceClient != null && (_developerService == null ||
                    developerServiceClient.State == System.ServiceModel.CommunicationState.Closed ||
                    developerServiceClient.State == System.ServiceModel.CommunicationState.Faulted))
                {
                    _developerService = CreateDeveloperService();
                }
                return _developerService;
            }
        }

        private static IDeveloperService CreateDeveloperService()
        {
            const string serviceUrl = "http://localhost:1578/Service/DeveloperService.svc/~/Service/Developer.svc";
            var binding = new NetHttpBinding();
            var channelFactory = new ChannelFactory<IDeveloperService>(binding, new EndpointAddress(serviceUrl));
            return channelFactory.CreateChannel();
        }
    }
}
