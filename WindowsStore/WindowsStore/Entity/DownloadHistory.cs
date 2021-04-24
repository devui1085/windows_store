using Store.Common.Enum;
using System;
using System.Collections.Generic;

namespace Store.DomainModel.Entity
{
    public partial class DownloadHistory
    {
        public DownloadHistory()
        {
        }

        public int Id { get; set; }
        public int AppVersionId  { get; set; }
        public DateTime Date { get; set; }
        public int Downloads { get; set; }
        public int Updates { get; set; }

        public virtual AppVersion AppVersion { get; set; }
    }
}
