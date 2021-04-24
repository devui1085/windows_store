using Store.DomainModel.Entity;
using System.Data.Entity.ModelConfiguration;

namespace Store.DataAccess.EntityMapping
{
    public class LegalPersonMap : EntityTypeConfiguration<LegalPerson>
    {
        public LegalPersonMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("LegalPerson");
            this.Property(t => t.Name).HasColumnName("Name");
        }
    }
}
