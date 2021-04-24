using Store.Common.Enum;
using System.Collections.Generic;

namespace Store.DomainModel.Entity
{
    public partial class AppCategory
    {
        public AppCategory()
        {
            this.Apps = new List<App>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public virtual ICollection<App> Apps { get; set; }
        public virtual AppType AppType { get; set; }
    }
}
