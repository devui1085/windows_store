using Store.DomainModel.Entity;
using System.Data.Entity.ModelConfiguration;

namespace Store.DataAccess.EntityMapping
{
    public class FeaturedAppMap : EntityTypeConfiguration<FeaturedApp>
    {
        public FeaturedAppMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Description)
                .IsOptional()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("FeaturedApp");

            // Relationships
            this.HasRequired(t => t.App)
                .WithRequiredDependent(t => t.FeaturedApp);
        }
    }
}
