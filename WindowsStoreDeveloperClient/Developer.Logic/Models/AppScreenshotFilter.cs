using System;
using WindowsStore.Client.Developer.Logic.DeveloperService;

namespace WindowsStore.Client.Developer.Logic.Models
{
    public class AppScreenshotFilter 
    {
        public int AppId { get; set; }
        public Guid AppGuid { set; get; }

        public ScreenshotType ScreenshotType { set; get; }

        public ScreenshotSize ScreenshotSize { set; get; }

        public int ScreenshotId { set; get; }
    }
}
