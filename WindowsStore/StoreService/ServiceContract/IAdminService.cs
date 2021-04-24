using Store.Common.Infrastructure;
using Store.DataContract;
using System.Collections.Generic;
using System.ServiceModel;

namespace Store.StoreService.ServiceContract
{
    [ServiceContract]
    public interface IAdminService
    {
        [OperationContract]
        AuthenticationResultDataContract SignIn(string email, string password);

        [OperationContract]
        IEnumerable<PersonDataContract> GetUsers(PagingParameters pagingParameters);

        [OperationContract]
        void RegisterNaturalPerson(NaturalPersonDataContract naturalPerson);

        [OperationContract]
        void RegisterLegalPerson(LegalPersonDataContract legalPerson);

        [OperationContract]
        void UpdateNaturalPerson(NaturalPersonDataContract naturalPerson);

        [OperationContract]
        void UpdateLegalPerson(LegalPersonDataContract legalPerson);

        [OperationContract]
        void DeletePerson(PersonDataContract personDataContract);
    }
}
