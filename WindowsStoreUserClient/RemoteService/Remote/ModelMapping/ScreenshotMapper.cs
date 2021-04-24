using System.Threading.Tasks;
using WindowsStore.Client.User.Common.ExtensionMethod;
using WindowsStore.Client.User.Common.PresentationModel;
using WindowsStore.Client.User.Service.UserService;

namespace WindowsStore.Client.User.Service.Remote.ModelMapping
{
    public static class ScreenshotMapper
    {
        public static async Task<Screenshot> GetScreenShotAsync(this ScreenshotDataContract dataContract)
        {
            var originalImage = dataContract.Original == null ? null : await dataContract.Original.ConvertToBitmapImageAsync();
            var thumbnailImage = dataContract.Thumbnail == null ? null : await dataContract.Thumbnail.ConvertToBitmapImageAsync();
            
            return new Screenshot()
            {
                AppGuid = dataContract.AppGuid,
                OriginalImage = originalImage,
                ThumbnailImage = thumbnailImage,
            };
        }
    }
}
