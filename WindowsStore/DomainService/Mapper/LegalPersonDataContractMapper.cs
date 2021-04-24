using Store.DataContract;
using Store.DomainModel.Entity;

namespace Store.DomainService.Mapper
{
    internal static class LegalPersonDataContractMapper
    {
        public static LegalPerson ToLegalPerson(this LegalPersonDataContract legalPersonDataContract)
        {
            return new LegalPerson()
            {
                Id = legalPersonDataContract.Id,
                PrimaryEmail = legalPersonDataContract.PrimaryEmail,
                Name = legalPersonDataContract.Name
            };
        }

        public static LegalPersonDataContract ToLegalPersonDataContract(this LegalPerson legalPerson)
        {
            return new LegalPersonDataContract()
            {
                Id = legalPerson.Id,
                Name = legalPerson.Name,
                PrimaryEmail = legalPerson.PrimaryEmail
            };
        }
    }
}