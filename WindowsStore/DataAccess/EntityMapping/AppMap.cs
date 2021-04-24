using Store.DomainModel.Entity;
using System.Data.Entity.ModelConfiguration;

namespace Store.DataAccess.EntityMapping
{
    public class AppMap : EntityTypeConfiguration<App>
    {
        public AppMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.Guid)
                .IsRequired();

            this.Property(t => t.Description)
                .HasMaxLength(4000)
                .IsRequired();

            this.Property(t => t.Icon128X128)
                .IsOptional();

            this.Property(t => t.Icon256X256)
                .IsOptional();

            this.Property(t => t.Price)
                .IsRequired();

            this.Property(t => t.CpuArchitectureFlags)
                .IsOptional();

            // Table & Column Mappings
            this.ToTable("App");

            // Relationships
            this.HasRequired(t => t.Developer)
                .WithMany(t => t.Apps)
                .HasForeignKey(d => d.DeveloperId);

            this.HasRequired(t => t.AppCategory)
                .WithMany(t => t.Apps)
                .HasForeignKey(d => d.AppCategoryId);

            this.HasMany(t => t.Platforms)
                .WithMany(t => t.App)
                .Map(map =>
                {
                    map.MapLeftKey("AppId");
                    map.MapRightKey("PlatformId");
                    map.ToTable("AppPlatform");
                });
        }
    }
}
