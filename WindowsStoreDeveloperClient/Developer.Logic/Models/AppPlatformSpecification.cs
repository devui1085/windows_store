using System.Collections.Generic;
using System.Linq;
using WindowsStore.Client.Developer.Logic.DeveloperService;

namespace WindowsStore.Client.Developer.Logic.Models
{
    public class AppPlatformSpecification
    {
        public int AppId { get; set; }
        public CpuArchitecture? CpuArchitectureFlags { get; set; }
        public IEnumerable<int> PlatformCategories { get; set; }
        public bool IsComplete => CpuArchitectureFlags != CpuArchitecture.None && PlatformCategories.Any();
    }
}
