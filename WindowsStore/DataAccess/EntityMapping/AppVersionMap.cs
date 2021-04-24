using Store.DomainModel.Entity;
using System.Data.Entity.ModelConfiguration;

namespace Store.DataAccess.EntityMapping
{
    public class AppVersionMap : EntityTypeConfiguration<AppVersion>
    {
        public AppVersionMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Version)
                .IsRequired()
                .HasMaxLength(30);

            this.Property(t => t.Description)
                .HasMaxLength(4000);

            this.Property(t => t.Size).IsRequired();
            this.Property(t => t.ArmPackageSize).IsOptional();
            this.Property(t => t.X64PackageSize).IsOptional();
            this.Property(t => t.X86PackageSize).IsOptional();

            this.Property(t => t.PublishDate).IsRequired();

            // Table & Column Mappings
            this.ToTable("AppVersion");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Version).HasColumnName("Version");
            this.Property(t => t.PublishDate).HasColumnName("PublishDate");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.AppId).HasColumnName("AppId");
            this.Property(t => t.Downloads).HasColumnName("Downloads");
            this.Property(t => t.Size).HasColumnName("Size");
            this.Property(t => t.ArmPackageSize).HasColumnName("ArmPackageSize");
            this.Property(t => t.X64PackageSize).HasColumnName("X64PackageSize");
            this.Property(t => t.X86PackageSize).HasColumnName("X86PackageSize");

            // Relationships
            this.HasRequired(t => t.App)
                .WithMany(t => t.AppVersions)
                .HasForeignKey(d => d.AppId);
        }
    }
}
