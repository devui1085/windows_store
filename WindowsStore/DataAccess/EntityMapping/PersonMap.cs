using Store.DomainModel.Entity;
using System.Data.Entity.ModelConfiguration;

namespace Store.DataAccess.EntityMapping
{
    public class PersonMap : EntityTypeConfiguration<Person>
    {
        public PersonMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.PrimaryEmail)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("Person");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.PrimaryEmail).HasColumnName("PrimaryEmail");

            // Table & Column Mappings
            this.HasMany(t => t.Roles)
                .WithMany(t => t.People)
                .Map(map =>
                {
                    map.MapLeftKey("PersonId");
                    map.MapRightKey("RoleId");
                    map.ToTable("PersonRole");
                });
        }
    }
}
