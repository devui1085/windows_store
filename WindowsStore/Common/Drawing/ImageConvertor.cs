using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using Encoder = System.Drawing.Imaging.Encoder;

namespace Store.Common.Drawing
{
    public static class ImageConverter
    {
        public static byte[] ResizeByteArrayImage(byte[] imageBytes, int newWidth, int newHeight)
        {
            using (var ms = new MemoryStream(imageBytes))
            {
                var image = Image.FromStream(ms);
                var resizedImage = new Bitmap(image, newWidth, newHeight);
                return ImageToByteArray(resizedImage, GetImageCodecInfo(image));
            }
        }

        public static byte[] ResizeByteArrayImage(byte[] imageBytes, int newHeight)
        {
            using (var ms = new MemoryStream(imageBytes))
            {
                var image = Image.FromStream(ms);
                var newWidth = newHeight * image.Width / image.Height;
                var resizedImage = new Bitmap(image, newWidth, newHeight);
                return ImageToByteArray(resizedImage, GetImageCodecInfo(image));
            }
        }

        public static byte[] ImageToByteArray(Image image, ImageFormat imageFormat)
        {
            byte[] byteArray;
            using (var stream = new MemoryStream())
            {
            
                image.Save(stream, imageFormat);
                stream.Close();

                byteArray = stream.ToArray();
            }
            return byteArray;
        }

        private static ImageFormat GetImageCodecInfo(Image image)
        {
            if (image.RawFormat.Guid.Equals(ImageFormat.Jpeg.Guid))
                return ImageFormat.Jpeg;
            if (image.RawFormat.Guid.Equals(ImageFormat.Png.Guid))
                return ImageFormat.Png;

            return null;
        }
        private static ImageCodecInfo GetEncoderInfo(ImageFormat format)
        {
            return ImageCodecInfo.GetImageDecoders().SingleOrDefault(c => c.FormatID == format.Guid);
        }
    }
}
