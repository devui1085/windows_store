using Store.DomainModel.Entity;
using System.Data.Entity.ModelConfiguration;

namespace Store.DataAccess.EntityMapping
{
    public class DownloadHistoryMap : EntityTypeConfiguration<DownloadHistory>
    {
        public DownloadHistoryMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.Date)
                .IsRequired();

            this.Property(t => t.AppVersionId)
                .IsRequired();

            this.Property(t => t.Downloads)
                .IsRequired();

            this.Property(t => t.Updates)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("DownloadHistory");

            // Relationships
            this.HasRequired(t => t.AppVersion)
                .WithMany(t => t.DownloadHistories)
                .HasForeignKey(d => d.AppVersionId);
        }
    }
}
