using Store.StoreService.ServiceContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using Store.DataContract;
using Store.Common.Infrastructure;
using Store.DomainService.Core;
using Store.DomainService.Interface;
using Store.StoreService.AppCode.Extensibility;
using Store.StoreService.AppCode.Security;

namespace Store.StoreService.Service
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    [ServiceFaultBehavior]
    public class AdminService : IAdminService
    {
        private IUserManagementDomainService UserManagementDomainService { get; }

        public AdminService()
        {
            UserManagementDomainService = new UserManagementDomainService();
        }


        public AuthenticationResultDataContract SignIn(string email, string password)
        {
            var result = UserManagementDomainService.SignIn(email, password);

            if (!result.Authenticated) return result;

            // build user principal
            //
            var userPrincipal = new UserPrincipal
            {
                UserId = result.UserId,
                UserName = result.PrimaryEmail,
                Roles = UserManagementDomainService.GetPersonRoles(result.UserId).Select(r => r.Name).ToArray()
            };

            // register user principal in session
            Principal.CurrentUser = userPrincipal;

            return result;
        }

        public IEnumerable<PersonDataContract> GetUsers(PagingParameters pagingParameters)
        {
            return UserManagementDomainService.GetUsers(pagingParameters);
        }

        public void RegisterNaturalPerson(NaturalPersonDataContract naturalPerson)
        {
            throw new NotImplementedException();
        }

        public void RegisterLegalPerson(LegalPersonDataContract legalPerson)
        {
            throw new NotImplementedException();
        }

        public void UpdateNaturalPerson(NaturalPersonDataContract naturalPerson)
        {
            throw new NotImplementedException();
        }

        public void UpdateLegalPerson(LegalPersonDataContract legalPerson)
        {
            throw new NotImplementedException();
        }

        public void DeletePerson(PersonDataContract person)
        {
            throw new NotImplementedException();
        }
    }
}
