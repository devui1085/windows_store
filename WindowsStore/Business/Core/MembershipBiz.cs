using System;
using Store.Business.Interface;
using Store.DataAccess.Context;
using Store.DomainModel.Entity;
using Store.Common.Security;
using System.Linq;

namespace Store.Business.Core
{
    public class MembershipBiz : BaseBiz<Membership>, IMembershipBiz
    {
        private readonly WindowsStoreContext _context;

        public MembershipBiz(WindowsStoreContext context):base(context)
        {
            _context = context;
        }

        public bool ActivateAccount(string email, int activationCode)
        {
            Membership membership = SingleOrDefault(m => m.Person.PrimaryEmail == email);

            if (((DateTime.Now - membership.VerificationCodeLastSendDate).TotalHours > 48) || membership.VerificationCode != activationCode)
            {
                return false;
            }

            membership.IsApproved = true;
            return true;
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

            Create(membership);
        }

        public bool ExistEmail(string email)
        {
            email = email.Trim().ToString();
            return _context.People.Any(p => p.PrimaryEmail == email);
        }

        public int SetNewVerificationCode(string email)
        {
            var rand = new Random();
            Membership membership = SingleOrDefault(m => m.Person.PrimaryEmail == email);
            membership.VerificationCode = rand.Next(1000,9999);
            membership.VerificationCodeLastSendDate = DateTime.Now;
            return membership.VerificationCode;
        }

    }
}
