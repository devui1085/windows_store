using Store.DomainModel.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Store.DataAccess.EntityMapping
{
    public class MembershipMap : EntityTypeConfiguration<Membership>
    {
        public MembershipMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            this.Property(t => t.Password).IsRequired().IsFixedLength().HasMaxLength(32);
            this.Property(t => t.IsApproved).IsRequired();
            this.Property(t => t.IsLockedOut).IsRequired();
            this.Property(t => t.CreateDate).IsRequired();
            this.Property(t => t.FailedPasswordAttemptCount).IsRequired();
            this.Property(t => t.VerificationCode).IsRequired();
            this.Property(t => t.VerificationCodeLastSendDate).IsRequired();
            this.Property(t => t.IsIdentityVerified).IsRequired();
                
            // Table & Column Mappings
            this.ToTable("Membership");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Password).HasColumnName("Password");
            this.Property(t => t.IsApproved).HasColumnName("IsApproved");
            this.Property(t => t.IsLockedOut).HasColumnName("IsLockedOut");
            this.Property(t => t.CreateDate).HasColumnName("CreateDate");
            this.Property(t => t.LastLoginDate).HasColumnName("LastLoginDate");
            this.Property(t => t.LastPasswordChangedDate).HasColumnName("LastPasswordChangedDate");
            this.Property(t => t.LastLockoutDate).HasColumnName("LastLockoutDate");
            this.Property(t => t.FailedPasswordAttemptCount).HasColumnName("FailedPasswordAttemptCount");
            this.Property(t => t.VerificationCode).HasColumnName("VerificationCode");
            this.Property(t => t.VerificationCodeLastSendDate).HasColumnName("VerificationCodeLastSendDate");
            this.Property(t => t.IsIdentityVerified).HasColumnName("IsIdentityVerified");

            // Relationships
            this.HasRequired(t => t.Person)
                .WithRequiredDependent(t => t.Membership);

        }
    }
}
