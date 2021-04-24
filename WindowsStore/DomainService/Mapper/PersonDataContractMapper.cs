using Store.DataContract;
using Store.DomainModel.Entity;

namespace Store.DomainService.Mapper
{
    internal static class PersonDataContractMapper
    {
        public static Person ToPerson(this PersonDataContract personDataContract)
        {
            return new Person()
            {
                Id = personDataContract.Id,
                PrimaryEmail = personDataContract.PrimaryEmail,
            };
        }

        public static PersonDataContract ToPersonDataContract(this Person person)
        {
            return new PersonDataContract()
            {
                Id = person.Id,
                PrimaryEmail = person.PrimaryEmail,
                IsNaturalPerson = person is NaturalPerson,
                NaturalPersonDataContract = (person as NaturalPerson)?.ToNaturalPersonDataContract(),
                LegalPersonDataContract = (person as LegalPerson)?.ToLegalPersonDataContract()
            };
        }
    }
}