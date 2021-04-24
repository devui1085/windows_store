using System;
using Windows.Storage;
using Windows.UI.Xaml.Media.Imaging;
using WindowsStore.Client.Developer.Logic.DeveloperService;

namespace WindowsStore.Client.Developer.Logic.Models
{
    public class AppScreenshot
    {
        public int Id { get; set; }

        public int AppId { get; set; }

        public string FileName { get; set; }

        public BitmapImage Original { get; set; }

        public BitmapImage Thumbnail { get; set; }
        public StorageFile SourceImageStorageFile { get; set; }
        public ScreenshotType ScreenshotType { get; set; }

        public ScreenshotSize ScreenshotSize { get; set; }

        public Guid AppGuid { get; set; }
    }
}
