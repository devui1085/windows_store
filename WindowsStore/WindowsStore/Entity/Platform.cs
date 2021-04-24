using Store.Common.Enum;
using System.Collections.Generic;

namespace Store.DomainModel.Entity
{
    public partial class Platform
    {
        public Platform()
        {
            this.App= new List<App>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public PlatformCategory PlatformCategory { get; set; }
        public virtual ICollection<App> App { get; set; }

    }
}
