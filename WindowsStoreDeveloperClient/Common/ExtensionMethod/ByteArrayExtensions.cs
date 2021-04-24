using System;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Media.Imaging;

namespace WindowsStore.Client.Developer.Common.ExtensionMethod
{
    public static class ByteArrayExtensions
    {
        public static async Task<BitmapImage> AsBitmapImageAsync(this byte[] byteArray)
        {
            if (byteArray == null) return null;

            using (var stream = new InMemoryRandomAccessStream())
            {
                await stream.WriteAsync(byteArray.AsBuffer());
                var image = new BitmapImage();
                stream.Seek(0);
                image.SetSource(stream);
                return image;
            }
        }

        public static async Task<byte[]> AsByteArrayAsync(this StorageFile bitmapImage)
        {
            if (bitmapImage == null)
                return null;

            using (var stream = await bitmapImage.OpenReadAsync())
            {
                var fileBytes= new byte[stream.Size];

                using (var reader = new DataReader(stream))
                {
                    await reader.LoadAsync((uint)stream.Size);
                    reader.ReadBytes(fileBytes);
                    return fileBytes;
                }
            }
        }
        /*
        Async Function bitmapTObyte(ByVal bitmapimage1 As StorageFile) As Task(Of Byte())
    Dim fileBytes As Byte() = Nothing
    Using stream As IRandomAccessStreamWithContentType = Await bitmapimage1.OpenReadAsync()
        fileBytes = New Byte(stream.Size - 1) {}
        Using reader As New DataReader(stream)
            Await reader.LoadAsync(CUInt(stream.Size))
            reader.ReadBytes(fileBytes)
            Return fileBytes
        End Using
    End Using
    */
    }
}
