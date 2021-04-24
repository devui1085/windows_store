using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsStore.Client.Admin.Common.Enum;

namespace WindowsStore.Client.Admin.Common.Model
{
    public class AppCategory
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public virtual AppType AppType { get; set; }
    }
}
