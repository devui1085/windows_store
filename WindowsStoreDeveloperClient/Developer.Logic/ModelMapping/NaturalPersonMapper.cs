using WindowsStore.Client.Developer.Logic.DeveloperService;
using WindowsStore.Client.Developer.Logic.Models;


namespace WindowsStore.Client.Developer.Logic.ModelMapping
{
    public static class NaturalPersonMapper
    {
        public static NaturalPersonDataContract ToNaturalPersonDataContract(this NaturalPerson naturalPerson)
        {
            return new NaturalPersonDataContract()
            {
                FirstName = naturalPerson.FirstName,
                Id = naturalPerson.Id,
                LastName = naturalPerson.LastName,
                PrimaryEmail = naturalPerson.PrimaryEmail
            };
        }

        public static NaturalPerson ToNaturalPerson(this NaturalPersonDataContract naturalPersonDataContract)
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
