using System.ServiceModel;
using WindowsStore.Client.User.Service.Remote;
using WindowsStore.Client.User.Service.Remote.Address;
using WindowsStore.Client.User.Service.UserService;

namespace WindowsStore.Client.User.Service.Remote.Wcf
{
    internal abstract class RemoteServiceBase
    {
        IUserService _userService;
        ChannelFactory<IUserService> _channelFactory;

        protected IUserService RemoteUserService
        {
            get
            {
                //if (_userService == null ||
                //    (_userService as  UserServiceClient).State == CommunicationState.Closed ||
                //    (_userService as UserServiceClient).State == CommunicationState.Faulted)
                //{
                //    _userService = CreateUserService();
                //}
                _userService = CreateUserService();
                return _userService;
            }
        }

        private IUserService CreateUserService()
        {
            string serviceUrl = ServerUri.GetUserWcfServiceUri().OriginalString;
            NetHttpBinding binding = new NetHttpBinding();
            binding.MaxReceivedMessageSize = 500 * 1024;
            _channelFactory = new ChannelFactory<IUserService>(binding, new EndpointAddress(serviceUrl));
            return _channelFactory.CreateChannel();
        }

        protected void Close()
        {
            _channelFactory.Close();
            _userService = null;
        }
    }
}
