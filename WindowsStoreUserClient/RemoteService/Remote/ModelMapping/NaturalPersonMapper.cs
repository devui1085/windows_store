
using WindowsStore.Client.User.Common.PresentationModel;
using WindowsStore.Client.User.Service.UserService;

namespace WindowsStore.Client.User.Service.Remote.ModelMapping
{
    public static class NaturalPersonMapper
    {
        public static NaturalPersonDataContract GetNaturalPersonDC(this NaturalPerson naturalPerson)
        {
            return new NaturalPersonDataContract()
            {
                FirstName = naturalPerson.FirstName,
                Id = naturalPerson.Id,
                LastName = naturalPerson.LastName,
                PrimaryEmail = naturalPerson.PrimaryEmail
            };
        }

        public static NaturalPerson GetNaturalPerson(this NaturalPersonDataContract naturalPersonDataContract)
        {
            return new NaturalPerson()
            {
                FirstName = naturalPersonDataContract.FirstName,
                Id = naturalPersonDataContract.Id,
                LastName = naturalPersonDataContract.LastName,
                PrimaryEmail = naturalPersonDataContract.PrimaryEmail
            };
        }
    }
}
