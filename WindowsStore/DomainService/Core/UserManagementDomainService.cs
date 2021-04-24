using System.Collections.Generic;
using System.Linq;
using Store.Business.Core;
using Store.Business.Interface;
using Store.Common.Enum;
using Store.Common.Infrastructure;
using Store.DataAccess.Context;
using Store.DataContract;
using Store.DomainModel.Entity;
using Store.DomainService.Interface;
using Store.DomainService.Mapper;

namespace Store.DomainService.Core
{
    public class UserManagementDomainService : IUserManagementDomainService
    {
        private readonly WindowsStoreContext _context;
        private INaturalPersonBiz NaturalPersonBiz { get; }
        private ILegalPersonBiz LegalPersonBiz { get; }
        private IMembershipBiz MembershipBiz { get; }
        private IPersonBiz PersonBiz { get; }

        private IRoleBiz RoleBiz { get; }

        public UserManagementDomainService()
        {
            _context = new WindowsStoreContext();
            NaturalPersonBiz = new NaturalPersonBiz(_context);
            LegalPersonBiz = new LegalPersonBiz(_context);
            MembershipBiz = new MembershipBiz(_context);
            PersonBiz = new PersonBiz(_context);
            RoleBiz = new RoleBiz(_context);
        }

        public void RegisterNaturalPerson(NaturalPersonDataContract naturalPersonDataContract, string password, string[] userRoles)
        {
            // Create User
            var person = NaturalPersonBiz.Create(naturalPersonDataContract.ToNaturalPerson());
            MembershipBiz.CreateMembershipForPerson(person, password);

            // Assign Roles
            if (userRoles.Count() > 0) {
                RoleBiz
                    .Where(role => userRoles.Contains(role.Name))
                    .ToList()
                    .ForEach(role => person.Roles.Add(role));
            }

            //
            _context.SaveChanges();
        }

        public void RegisterLegalPerson(LegalPersonDataContract legalPersonDataContract, string password)
        {
            var person = legalPersonDataContract.ToLegalPerson();
            LegalPersonBiz.Create(person);
            MembershipBiz.CreateMembershipForPerson(person, password);
            _context.SaveChanges();
        }

        //public AuthenticationResultDataContract SignIn(string userName, string password)
        //{
        //    AuthenticationResultDataContract authenticationResult = new AuthenticationResultDataContract();

        //    // Validate user membership
        //    //
        //    Membership membership = MembershipBiz.SingleOrDefault(m => m.Person.PrimaryEmail == userName);

        //    if (membership == null)
        //    {
        //        authenticationResult.Result = AuthenticationResult.UserIsNotExist;
        //    }
        //    else if (membership.IsLockedOut)
        //    {
        //        authenticationResult.Result = AuthenticationResult.UserIsBlocked;
        //    }

        //    // Start authenticate user
        //    //
        //    byte[] passwordHash = SecurityHelper.ComputeSha256Hash(password);
        //    if (membership.Password.SequenceEqual(passwordHash))
        //    {
        //        authenticationResult.Authenticated = true;
        //        authenticationResult.Result = membership.IsApproved ? AuthenticationResult.Successed : AuthenticationResult.SuccessedButUserIsNotActivated;

        //        Person person = PersonBiz.SingleOrDefault(p => p.Id == membership.Id);

        //        IdentificationInformationDataContract userIdentity = new IdentificationInformationDataContract();
        //        authenticationResult.UserIdentity = userIdentity;

        //        userIdentity.PrimaryEmail = person.PrimaryEmail;

        //        if (person is NaturalPerson)
        //        {
        //            NaturalPerson naturalPerson = (NaturalPerson)person;
        //            userIdentity.FirstName = naturalPerson.FirstName;
        //            userIdentity.LastName = naturalPerson.LastName;
        //            userIdentity.IsNaturalPerson = true;
        //        }
        //        else
        //        {
        //            LegalPerson legalPerson = (LegalPerson)person;
        //            userIdentity.FirstName = legalPerson.Name;
        //            userIdentity.LastName = string.Empty;
        //            userIdentity.IsNaturalPerson = false;
        //        }
        //    }
        //    else
        //    {
        //        authenticationResult.Result = AuthenticationResult.UserOrPasswordIsInvalid;
        //    }

        //    return authenticationResult;
        //}

        public AuthenticationResultDataContract SignIn(string userName, string password)
        {
            var authResult = new AuthenticationResultDataContract();
            var person = PersonBiz.GetPersonByCredentials(userName, password);

            if (person == null) {
                return authResult;
            }

            authResult.Authenticated = true;
            authResult.UserAccountStatus = PersonBiz.GetAccountStatus(person);
            authResult.UserId = person.Id;
            authResult.PrimaryEmail = person.PrimaryEmail;

            // if person is a natural person
            var naturalPerson = person as NaturalPerson;

            authResult.IsNaturalPerson = naturalPerson != null;
            authResult.FirstName = naturalPerson?.FirstName;
            authResult.LastName = naturalPerson?.LastName;
            authResult.Name = $"{naturalPerson?.LastName} {naturalPerson?.FirstName}";

            // if person is legal person
            var legalPerson = person as LegalPerson;

            authResult.Name = legalPerson?.Name;

            return authResult;
        }

        public bool ExistEmail(string email)
        {
            return MembershipBiz.ExistEmail(email);
        }

        public bool ActivateAccount(string email, int activationCode)
        {
            var result = MembershipBiz.ActivateAccount(email, activationCode);
            _context.SaveChanges();

            return result;
        }

        public int SetNewActivationCode(string email)
        {
            var verficationCode = MembershipBiz.SetNewVerificationCode(email);
            _context.SaveChanges();

            return verficationCode;
        }

        public Person GetPersonByPrimaryEmail(string primaryEmail)
        {
            return PersonBiz.SingleOrDefault(p => p.PrimaryEmail == primaryEmail);
        }

        public List<Role> GetPersonRoles(int personId) => PersonBiz.GetPersonRoles(personId).ToList();
        public IEnumerable<PersonDataContract> GetUsers(PagingParameters pagingParameters)
        {
            return PersonBiz.GetAll()
                            .OrderBy(p => p.Id)
                            .Skip(pagingParameters.PageIndex * pagingParameters.PageSize)
                            .Take(pagingParameters.PageSize)
                            .ToList()
                            .Select(p => p.ToPersonDataContract()); ;
        }

        public void AddRoleToUser(int userId, string roleName)
        {
            var person = PersonBiz.Single(p => p.Id == userId);
            var role = RoleBiz.Single(r => r.Name == roleName);

            person.Roles.Add(role);

            _context.SaveChanges();
        }
    }
}
