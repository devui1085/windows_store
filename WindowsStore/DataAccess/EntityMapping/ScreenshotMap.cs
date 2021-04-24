using Store.DomainModel.Entity;
using System.Data.Entity.ModelConfiguration;

namespace Store.DataAccess.EntityMapping
{
    public class ScreenshotMap : EntityTypeConfiguration<Screenshot>
    {
        public ScreenshotMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.FileName).HasMaxLength(50);
            this.Property(t => t.FileName).IsRequired();

            // Table & Column Mappings
            this.ToTable("Screenshot");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.AppId).HasColumnName("AppId");
            this.Property(t => t.FileName).HasColumnName("FileName");

            // Relationships
            this.HasRequired(t => t.App)
                .WithMany(t => t.Screenshots)
                .HasForeignKey(d => d.AppId);
        }
    }
}
