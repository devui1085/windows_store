using Store.DomainModel.Entity;
using System.Data.Entity.ModelConfiguration;

namespace Store.DataAccess.EntityMapping
{
    public class DeviceMap : EntityTypeConfiguration<Device>
    {
        public DeviceMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.DeviceId)
                .IsRequired();

            this.Property(t => t.OperatingSystem)
                .HasMaxLength(50);

            this.Property(t => t.FriendlyName)
                .HasMaxLength(50);

            this.Property(t => t.SystemFirmwareVersion)
                .HasMaxLength(50);

            this.Property(t => t.SystemHardwareVersion)
                .HasMaxLength(50);

            this.Property(t => t.SystemManufacturer)
                .HasMaxLength(50);

            this.Property(t => t.SystemProductName)
                .HasMaxLength(50);

            this.Property(t => t.SystemSku)
                .HasMaxLength(50);

            this.Property(t => t.PaasteelVersion)
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("Device");

            // Relationships
        }
    }
}
