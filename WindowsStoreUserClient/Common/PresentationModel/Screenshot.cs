using System;
using Windows.UI.Xaml.Media.Imaging;
using WindowsStore.Client.User.Common.Infrastructure;

namespace WindowsStore.Client.User.Common.PresentationModel
{
    public class Screenshot : BindableBase
    {
        const int ThumbnailImageHeight = 130;

        public Guid AppGuid { get; set; }
        public BitmapImage OriginalImage { get; set; }
        public BitmapImage ThumbnailImage { get; set; }

        public int ComputedThumbnailImageWidth
        {
            get
            {
                float ratio = ((float)ThumbnailImageHeight) / ThumbnailImage.PixelHeight;
                return (int)(ThumbnailImage.PixelWidth * ratio);
            }
        }

        public int ComputedOriginalImageWidth
        {
            get
            {
                float ratio = ((float)OriginalImage.PixelHeight) / ThumbnailImageHeight;
                return (int)(ThumbnailImage.PixelWidth * ratio);
            }
        }

        public int Index { get; set; }
    }
}
