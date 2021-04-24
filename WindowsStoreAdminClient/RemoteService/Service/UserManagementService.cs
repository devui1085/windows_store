using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsStore.Client.Admin.Common.Model;
using System.ServiceModel.Channels;
using System.ServiceModel;
using WindowsStore.Client.Admin.RemoteService.ModelMapping;
using WindowsStore.Client.Admin.Common.Model.Security;
using WindowsStore.Client.Admin.Common.Infrastructure;

namespace WindowsStore.Client.Admin.RemoteService.Service
{
    public class UserManagementService : RemoteServiceBase
    {
        static UserManagementService _instance;

        private UserManagementService()
        {
        }

        public static UserManagementService Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UserManagementService();
                return _instance;
            }
        }

        public async Task<AuthenticationResult> SignInAsync(string email, string password)
        {
            return (await RemoteAdminService.SignInAsync(email, password)).GetAuthenticationResult();
        }

        public async Task<IEnumerable<Person>> GetUsersAsync(PagingParameters pagingParameters)
        {
            return (await RemoteAdminService.GetUsersAsync(pagingParameters.GetPagingParametersDC()))
                .Select(personDataContract => personDataContract.GetPerson());
        }

        public async Task<IEnumerable<Person>> GetUsersAsync()
        {
            var p = await GetUsersAsync(new PagingParameters()
            {
                PageIndex = 0,
                PageSize = Int32.MaxValue
            });
            return p;
        }

        public async Task RegisterNaturalPersonAsync(NaturalPerson naturalPerson)
        {
            await RemoteAdminService.RegisterNaturalPersonAsync(naturalPerson.GetNaturalPersonDC());
        }

        public async Task UpdateNaturalPersonAsync(NaturalPerson naturalPerson)
        {
            await RemoteAdminService.UpdateNaturalPersonAsync(naturalPerson.GetNaturalPersonDC());
        }

        public async Task RegisterLegalPersonAsync(LegalPerson legalPerson)
        {
            await RemoteAdminService.RegisterLegalPersonAsync(legalPerson.GetLegalPersonDC());
        }

        public async Task UpdateNaturalPersonAsync(LegalPerson legalPerson)
        {
            await RemoteAdminService.UpdateLegalPersonAsync(legalPerson.GetLegalPersonDC());
        }

        public async Task DeletePersonAsync(Person person)
        {
            await RemoteAdminService.DeletePersonAsync(person.GetPersonDC());
        }

    }
}
