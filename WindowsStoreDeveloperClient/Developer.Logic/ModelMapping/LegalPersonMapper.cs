using WindowsStore.Client.Developer.Logic.DeveloperService;
using WindowsStore.Client.Developer.Logic.Models;


namespace WindowsStore.Client.Developer.Logic.ModelMapping
{
    public static class LegalPersonMapper
    {
        public static LegalPersonDataContract ToLegalPersonDataContract(this LegalPerson LegalPerson)
        {
            return new LegalPersonDataContract()
            {
                Name = LegalPerson.Name,
                PrimaryEmail = LegalPerson.PrimaryEmail,
                //Age = LegalPerson.Age,
                //FirstName = LegalPerson.FirstName,
                //Id = LegalPerson.Id,
                //LastName = LegalPerson.LastName,
                //NationalCode = LegalPerson.NationalCode,
                //PrimaryEmail = LegalPerson.PrimaryEmail,
                //Sexuality = (Sexuality)LegalPerson.Sexuality
            };
        }

        public static LegalPerson ToLegalPerson(this LegalPersonDataContract LegalPersonDataContract)
        {
            return new LegalPerson()
            {
                Name = LegalPersonDataContract.Name,
                PrimaryEmail = LegalPersonDataContract.PrimaryEmail,
                //Age = LegalPersonDataContract.Age,
                //FirstName = LegalPersonDataContract.FirstName,
                //Id = LegalPersonDataContract.Id,
                //LastName = LegalPersonDataContract.LastName,
                //NationalCode = LegalPersonDataContract.NationalCode,
                //PrimaryEmail = LegalPersonDataContract.PrimaryEmail,
                //Sexuality = (Common.Enum.Sexuality)LegalPersonDataContract.Sexuality
            };
        }
    }
}
