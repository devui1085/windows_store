using Store.DomainModel.Entity;
using System.Data.Entity.ModelConfiguration;

namespace Store.DataAccess.EntityMapping
{
    public class ActiveDeviceHistoryMap : EntityTypeConfiguration<ActiveDeviceHistory>
    {
        public ActiveDeviceHistoryMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Date)
                .IsRequired();

            this.Property(t => t.ActiveDeviceCount)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("ActiveDeviceHistory");

            // Relationships
        }
    }
}
