
using System;
using Windows.UI.Xaml.Media.Imaging;
using WindowsStore.Client.Developer.Logic.DeveloperService;

namespace WindowsStore.Client.Developer.Logic.Models
{
    public class App
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int AppCategoryId { get; set; }
        public BitmapImage IconBytes { get; set; }
        public DateTime LastUpdate { get; set; }
        public string Version { get; set; } 
        public AppState AppStatus { get; set; }

    }
}
