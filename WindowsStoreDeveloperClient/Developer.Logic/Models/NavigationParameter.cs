using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsStore.Client.Developer.Logic.Models
{
    public class NavigationParameter<T>
    {
        public int EntityId { get; set; }
        public bool LoadServerVersion { get; set; }
        public T Entity { get; set; }
    }
}
