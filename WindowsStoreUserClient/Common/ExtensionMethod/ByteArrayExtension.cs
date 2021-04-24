using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Media.Imaging;

namespace WindowsStore.Client.User.Common.ExtensionMethod
{
    public static class ByteArrayExtension
    {
        public async static Task<BitmapImage> ConvertToBitmapImageAsync(this byte[] imageBytes)
        {
            BitmapImage image;

            if (imageBytes == null || imageBytes.Count() == 0) return null;
            using (InMemoryRandomAccessStream ms = new InMemoryRandomAccessStream())
            {
                using (DataWriter writer = new DataWriter(ms.GetOutputStreamAt(0)))
                {
                    writer.WriteBytes(imageBytes);
                    await writer.StoreAsync();
                }
                image = new BitmapImage();
                await image.SetSourceAsync(ms);
            }
            return image;
        }
    }
}
