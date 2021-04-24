using System.ServiceModel;
using WindowsStore.Client.Admin.RemoteService.AdminService;

namespace WindowsStore.Client.Admin.RemoteService.Service
{
    public abstract class RemoteServiceBase
    {
        IAdminService _adminService;

        protected IAdminService RemoteAdminService
        {
            get
            {
                if (_adminService == null ||
                    (_adminService as AdminServiceClient).State == System.ServiceModel.CommunicationState.Closed ||
                    (_adminService as AdminServiceClient).State == System.ServiceModel.CommunicationState.Faulted)
                {
                    _adminService = CreateDeveloperService();
                }
                return _adminService;
            }
        }

        private IAdminService CreateDeveloperService()
        {
            const string serviceUrl = "http://localhost:1578/Service/AdminService.svc/~/Service/Admin.svc";
            NetHttpBinding binding = new NetHttpBinding();
            var channelFactory = new ChannelFactory<IAdminService>(binding, new EndpointAddress(serviceUrl));
            return channelFactory.CreateChannel();
        }
    }
}
