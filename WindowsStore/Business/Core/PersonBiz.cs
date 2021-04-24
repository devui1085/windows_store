using System;
using Store.Business.Interface;
using Store.DataAccess.Context;
using Store.DomainModel.Entity;
using Store.Common.Security;
using System.Linq;
using System.Collections.Generic;
using Store.Common.Enum;

namespace Store.Business.Core
{
    public class PersonBiz : BaseBiz<Person>, IPersonBiz
    {
        private readonly WindowsStoreContext _context;

        public PersonBiz(WindowsStoreContext context) : base(context)
        {
            _context = context;
        }

        public void CreateMembershipForPerson(Person person, string password)
        {
            var membership = new Membership()
            {
                Person = person,
                Password = SecurityHelper.ComputeSha256Hash(password),
                CreateDate = DateTime.Now,
                FailedPasswordAttemptCount = 0,
                IsApproved = false,
                IsIdentityVerified = false,
                IsLockedOut = false,
                LastLoginDate = null,
                VerificationCode = 0,
                VerificationCodeLastSendDate = DateTime.Now,
                LastLockoutDate = DateTime.Now,
                LastPasswordChangedDate = null
            };

            _context.Memberships.Add(membership);
        }

        public UserAccountStatus GetAccountStatus(Person person)
        {
            var membership = person.Membership;
            if (membership.IsLockedOut)
                return UserAccountStatus.Blocked;

            return !membership.IsApproved ? UserAccountStatus.NotActivated : UserAccountStatus.Activated;
        }

        public ICollection<Role> GetPersonRoles(int personId)
        {
            return SingleOrDefault(p => p.Id == personId).Roles;
        }

        public Person GetPersonByCredentials(string primaryEmail, string password)
        {
            var person = SingleOrDefault(p => p.PrimaryEmail == primaryEmail, p => p.Membership);

            if (person != null && person.Membership.Password.SequenceEqual(SecurityHelper.ComputeSha256Hash(password)))
                return person;
            return null;
        }


    }
}
