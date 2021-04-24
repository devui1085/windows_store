using WindowsStore.Client.User.Common.PresentationModel;
using WindowsStore.Client.User.Service.UserService;

namespace WindowsStore.Client.User.Service.Remote.ModelMapping
{
    public static class ServerDescriptorMapper
    {
        public static ServerDescriptor GetServerDescriptor(this ServerDescriptorDataContract dataContract)
        {
            return new ServerDescriptor()
            {
                 SupportedUserClientMinVersion = dataContract.SupportedUserClientMinVersion,
                 SupportedUserClientMaxVersion = dataContract.SupportedUserClientMaxVersion,
                 SupportedDeveloperClientMinVersion = dataContract.SupportedDeveloperClientMinVersion,
                 SupportedDeveloperClientMaxVersion = dataContract.SupportedDeveloperClientMaxVersion
            };
        }
    }
}
