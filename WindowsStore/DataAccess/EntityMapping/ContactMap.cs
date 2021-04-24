using Store.DomainModel.Entity;
using System.Data.Entity.ModelConfiguration;

namespace Store.DataAccess.EntityMapping
{
    public class ContactMap : EntityTypeConfiguration<Contact>
    {
        public ContactMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Value)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("Contact");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.PersonId).HasColumnName("PersonId");
            this.Property(t => t.Type).HasColumnName("Type");
            this.Property(t => t.Value).HasColumnName("Value");

            // Relationships
            this.HasRequired(t => t.Person)
                .WithMany(t => t.Contacts)
                .HasForeignKey(d => d.PersonId);

        }
    }
}
