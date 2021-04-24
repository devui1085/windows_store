using System;

namespace Store.DomainModel.Entity
{
    public partial class Membership
    {
        public int Id { get; set; }
        public byte[] Password { get; set; }
        public bool IsApproved { get; set; }
        public bool IsLockedOut { get; set; }
        public System.DateTime CreateDate { get; set; }
        public Nullable<System.DateTime> LastLoginDate { get; set; }
        public Nullable<System.DateTime> LastPasswordChangedDate { get; set; }
        public Nullable<System.DateTime> LastLockoutDate { get; set; }
        public int FailedPasswordAttemptCount { get; set; }
        public int VerificationCode { get; set; }
        public System.DateTime VerificationCodeLastSendDate { get; set; }
        public bool IsIdentityVerified { get; set; }
        public virtual Person Person { get; set; }
    }
}
