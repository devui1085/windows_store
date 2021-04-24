using WindowsStore.Client.User.Common.PresentationModel;
using WindowsStore.Client.User.Service.UserService;

namespace WindowsStore.Client.User.Service.Remote.ModelMapping
{
    public static class UserClientDescriptorMapper
    {
        public static UserClientDescriptorDataContract GetUserClientrDescriptorDC(this UserClientDescriptor discriptor)
        {
            return new UserClientDescriptorDataContract()
            {
            };
        }
    }
}
