using Store.DomainModel.Entity;
using System.Data.Entity.ModelConfiguration;

namespace Store.DataAccess.EntityMapping
{
    public class NaturalPersonMap : EntityTypeConfiguration<NaturalPerson>
    {
        public NaturalPersonMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.FirstName)
                .IsOptional()
                .HasMaxLength(50);

            this.Property(t => t.LastName)
                .IsOptional()
                .HasMaxLength(50);

            this.Property(t => t.NationalCode)
                .HasMaxLength(11);

            this.Property(t => t.Sexuality)
                .IsOptional();

            // Table & Column Mappings
            this.ToTable("NaturalPerson");
            this.Property(t => t.FirstName).HasColumnName("FirstName");
            this.Property(t => t.LastName).HasColumnName("LastName");
            this.Property(t => t.Age).HasColumnName("Age");
            this.Property(t => t.NationalCode).HasColumnName("NationalCode");
            this.Property(t => t.Sexuality).HasColumnName("Sexuality");
        }
    }
}
