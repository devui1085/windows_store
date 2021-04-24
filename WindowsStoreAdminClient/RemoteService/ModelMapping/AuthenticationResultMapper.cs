using WindowsStore.Client.Admin.Common.Model;
using WindowsStore.Client.Admin.Common.Model.Security;
using WindowsStore.Client.Admin.RemoteService.AdminService;

namespace WindowsStore.Client.Admin.RemoteService.ModelMapping
{
    public static class AuthenticationResultMapper
    {
        public static AuthenticationResultDataContract GetAuthenticationResultDC(this AuthenticationResult model)
        {
            return new AuthenticationResultDataContract()
            {
                Authenticated = model.Authenticated
            };
        }

        public static AuthenticationResult GetAuthenticationResult(this AuthenticationResultDataContract dataContract)
        {
            return new AuthenticationResult()
            {
                Authenticated = dataContract.Authenticated,
                UserIdentity = dataContract.UserIdentity.GetPerson()
            };
        }
    }
}
