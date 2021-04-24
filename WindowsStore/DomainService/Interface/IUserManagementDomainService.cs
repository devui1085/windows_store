using Store.DomainModel.Entity;
using Store.DataContract;
using System.Collections.Generic;
using Store.Common.Infrastructure;

namespace Store.DomainService.Interface
{
    public interface IUserManagementDomainService
    {
        void RegisterNaturalPerson(NaturalPersonDataContract naturalPersonDataContract, string password, string[] roles);
        void RegisterLegalPerson(LegalPersonDataContract legalPersonDataContract, string password);
        AuthenticationResultDataContract SignIn(string userName, string password);
        bool ExistEmail(string email);
        bool ActivateAccount(string email, int activationCode);
        int SetNewActivationCode(string email);
        Person GetPersonByPrimaryEmail(string primaryEmail);
        List<Role> GetPersonRoles(int personId);
        IEnumerable<PersonDataContract> GetUsers(PagingParameters pagingParameters);
        void AddRoleToUser(int userId, string roleName);
    }
}
