using Store.DomainModel.Entity;
using System.Data.Entity.ModelConfiguration;

namespace Store.DataAccess.EntityMapping
{
    public class RatingMap : EntityTypeConfiguration<Rating>
    {
        public RatingMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Comment)
                .HasMaxLength(1000)
                .IsRequired();

            this.Property(t => t.RegistrationDate)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("Rating");

            // Relationships
            this.HasRequired(t => t.Person)
                .WithMany(t => t.Ratings)
                .HasForeignKey(d => d.PersonId)
                .WillCascadeOnDelete(false);

            this.HasRequired(t => t.App)
                .WithMany(t => t.Ratings)
                .HasForeignKey(d => d.AppId);
        }
    }
}
