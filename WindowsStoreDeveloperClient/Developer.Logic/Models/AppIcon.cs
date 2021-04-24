using Windows.Storage;
using Windows.UI.Xaml.Media.Imaging;

namespace WindowsStore.Client.Developer.Logic.Models
{
    public class AppIcon
    {
        public int AppId { get; set; }
        public BitmapImage Icon128X128 { get; set; }
        public BitmapImage Icon256X256 { get; set; }

        public StorageFile Icon256X256StorageFile { get; set; }

        public bool IsComplete => Icon128X128 != null && Icon256X256 != null;
    }
}
