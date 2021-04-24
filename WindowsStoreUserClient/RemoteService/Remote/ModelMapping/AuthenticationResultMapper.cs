
using WindowsStore.Client.User.Common.PresentationModel;
using WindowsStore.Client.User.Service.UserService;

namespace WindowsStore.Client.User.Service.Remote.ModelMapping
{
    public static class AuthenticationResultMapper
    {
        public static AuthenticationResult GetAuthenticationResult(this AuthenticationResultDataContract dc)
        {
            var result = new AuthenticationResult();
            
            result.Authenticated = dc.Authenticated;
            result.IsNaturalPerson = dc.IsNaturalPerson;
            result.UserAccountStatus = (Common.Enum.UserAccountStatus)dc.UserAccountStatus;
            result.Person =  dc.IsNaturalPerson ?
                (Person)new NaturalPerson()
                {
                    PrimaryEmail = dc.PrimaryEmail,
                    FirstName = dc.FirstName,
                    LastName = dc.LastName,
                } :
                (Person)new LegalPerson()
                {
                    PrimaryEmail = dc.PrimaryEmail,
                    Name = dc.Name
                };
            return result;
        }
    }
}
