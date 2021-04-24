using WindowsStore.Client.Developer.Logic.DeveloperService;

namespace WindowsStore.Client.Developer.Logic.Models
{
    public class AppCategory
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public virtual AppType AppType { get; set; }
    }
}
