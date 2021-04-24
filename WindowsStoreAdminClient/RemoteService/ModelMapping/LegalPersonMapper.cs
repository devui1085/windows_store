using WindowsStore.Client.Admin.Common.Model;
using WindowsStore.Client.Admin.RemoteService.AdminService;

namespace WindowsStore.Client.Admin.RemoteService.ModelMapping
{
    public static class LegalPersonMapper
    {
        public static LegalPersonDataContract GetLegalPersonDC(this LegalPerson model)
        {
            return new LegalPersonDataContract()
            {
                Id = model.Id,
                Name = model.Name,
                PrimaryEmail = model.PrimaryEmail,
                Password = model.Password,
                IsAdmin = model.IsAdmin,
                IsDeveloper = model.IsDeveloper,
                IsLockedOut = model.IsLockedOut
            };
        }

        public static LegalPerson GetLegalPerson(this LegalPersonDataContract dataContract)
        {
            return new LegalPerson()
            {
                Id = dataContract.Id,
                Name = dataContract.Name,
                PrimaryEmail = dataContract.PrimaryEmail,
                IsAdmin = dataContract.IsAdmin,
                IsDeveloper = dataContract.IsDeveloper,
                IsLockedOut = dataContract.IsLockedOut,
                Password = dataContract.Password
            };
        }
    }
}
