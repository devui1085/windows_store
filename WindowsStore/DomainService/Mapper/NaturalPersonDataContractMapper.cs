using Store.DataContract;
using Store.DomainModel.Entity;

namespace Store.DomainService.Mapper
{
    internal static class NaturalPersonDataContractMapper
    {
        public static NaturalPerson ToNaturalPerson(this NaturalPersonDataContract naturalPersonDataContract)
        {
            return new NaturalPerson()
            {
                Id = naturalPersonDataContract.Id,
                Age = naturalPersonDataContract.Age,
                FirstName = naturalPersonDataContract.FirstName,
                LastName = naturalPersonDataContract.LastName,
                NationalCode = naturalPersonDataContract.NationalCode,
                PrimaryEmail = naturalPersonDataContract.PrimaryEmail,
                Sexuality = naturalPersonDataContract.Sexuality
            };
        }

        public static NaturalPersonDataContract ToNaturalPersonDataContract(this NaturalPerson naturalPerson)
        {
            return new NaturalPersonDataContract()
            {
                Id = naturalPerson.Id,
                Age = naturalPerson.Age,
                FirstName = naturalPerson.FirstName,
                LastName = naturalPerson.LastName,
                NationalCode = naturalPerson.NationalCode,
                PrimaryEmail = naturalPerson.PrimaryEmail,
                Sexuality = naturalPerson.Sexuality
            };
        }
    }
}