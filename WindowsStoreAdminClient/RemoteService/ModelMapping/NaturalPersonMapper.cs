using WindowsStore.Client.Admin.Common.Model;
using WindowsStore.Client.Admin.RemoteService.AdminService;

namespace WindowsStore.Client.Admin.RemoteService.ModelMapping
{
    public static class NaturalPersonMapper
    {
        public static NaturalPersonDataContract GetNaturalPersonDC(this NaturalPerson naturalPerson)
        {
            return new NaturalPersonDataContract()
            {
                Age = naturalPerson.Age,
                FirstName = naturalPerson.FirstName,
                Id = naturalPerson.Id,
                LastName = naturalPerson.LastName,
                NationalCode = naturalPerson.NationalCode,
                PrimaryEmail = naturalPerson.PrimaryEmail,
                Sexuality = (Sexuality)naturalPerson.Sexuality,
                Password = naturalPerson.Password,
                IsAdmin = naturalPerson.IsAdmin,
                IsDeveloper = naturalPerson.IsDeveloper,
                IsLockedOut = naturalPerson.IsLockedOut
            };
        }

        public static NaturalPerson GetNaturalPerson(this NaturalPersonDataContract dataContract)
        {
            return new NaturalPerson()
            {
                Age = dataContract.Age,
                FirstName = dataContract.FirstName,
                Id = dataContract.Id,
                LastName = dataContract.LastName,
                NationalCode = dataContract.NationalCode,
                PrimaryEmail = dataContract.PrimaryEmail,
                Sexuality = (Common.Enum.Sexuality)dataContract.Sexuality,
                IsAdmin = dataContract.IsAdmin,
                IsDeveloper = dataContract.IsDeveloper,
                IsLockedOut = dataContract.IsLockedOut,
                Password = dataContract.Password,
            };
        }
    }
}
