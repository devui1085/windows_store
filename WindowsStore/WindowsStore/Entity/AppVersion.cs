using System.Collections.Generic;

namespace Store.DomainModel.Entity
{
    public partial class AppVersion
    {
        public int Id { get; set; }
        public string Version { get; set; }
        public System.DateTime PublishDate { get; set; }
        public string Description { get; set; }
        public int AppId { get; set; }
        public int Downloads { get; set; }
        public long Size { get; set; }
        public long? ArmPackageSize { get; set; }
        public long? X64PackageSize { get; set; }
        public long? X86PackageSize { get; set; }
        public virtual App App { get; set; }
        public virtual ICollection<DownloadHistory> DownloadHistories { get; set; }

    }
}
