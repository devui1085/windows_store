using WindowsStore.Client.Admin.Common.Model;
using WindowsStore.Client.Admin.RemoteService.AdminService;

namespace WindowsStore.Client.Admin.RemoteService.ModelMapping
{
    public static class PersonMapper
    {
        public static PersonDataContract GetPersonDC(this Person model)
        {
            return new PersonDataContract()
            {
                Id = model.Id,
                IsNaturalPerson = model.IsNaturalPerson,
                NaturalPersonDataContract = model.IsNaturalPerson ? model.NaturalPerson.GetNaturalPersonDC() : null,
                LegalPersonDataContract = model.IsNaturalPerson ? null : model.LegalPerson.GetLegalPersonDC()
            };
        }

        public static Person GetPerson(this PersonDataContract dataContract)
        {
            return new Person()
            {
                Id = dataContract.Id,
                IsNaturalPerson = dataContract.IsNaturalPerson,
                NaturalPerson = dataContract.IsNaturalPerson ? dataContract.NaturalPersonDataContract.GetNaturalPerson() : null,
                LegalPerson = dataContract.IsNaturalPerson ? null : dataContract.LegalPersonDataContract.GetLegalPerson(),
            };
        }
    }
}
