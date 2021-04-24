using Store.DomainModel.Entity;
using System.Data.Entity.ModelConfiguration;

namespace Store.DataAccess.EntityMapping
{
    public class PlatformMap : EntityTypeConfiguration<Platform>
    {
        public PlatformMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Title).IsRequired().HasMaxLength(50);
            this.Property(t => t.PlatformCategory).IsRequired();
            //this.Property(t => t.Name).IsRequired().HasMaxLength(50);
            //this.Property(t => t.Code).IsRequired();
            //this.Property(t => t.CpuArchitecture ).IsRequired();
            //this.Property(t => t.VersionMinorNumber).IsRequired();
            //this.Property(t => t.VersionMajorNumber).IsRequired();

           // Table & Column Mappings
            this.ToTable("Platform");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.Title).HasColumnName("Title");
            this.Property(t => t.PlatformCategory).HasColumnName("PlatformCategory");
            //this.Property(t => t.Name).HasColumnName("Name");
            //this.Property(t => t.Code).HasColumnName("Code");
            //this.Property(t => t.CpuArchitecture).HasColumnName("CpuArchitecture");
            //this.Property(t => t.VersionMajorNumber).HasColumnName("VersionMajorNumber");
            //this.Property(t => t.VersionMinorNumber).HasColumnName("VersionMinorNumber");
        }
    }
}
