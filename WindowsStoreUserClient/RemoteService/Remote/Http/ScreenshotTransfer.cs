using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Web.Http;
using WindowsStore.Client.User.Common.ExtensionMethod;
using WindowsStore.Client.User.Common.PresentationModel;
using WindowsStore.Client.User.Service.Remote.Address;
using WindowsStore.Client.User.Common.Enum;
using Windows.Web.Http.Filters;
using WindowsStore.Client.User.Service.UserService;

namespace WindowsStore.Client.User.Service.Remote.Http
{
    public static class ScreenshotTransfer
    {
        public static async Task<Screenshot> GetAppScreenshotAsync(Guid appGuid, AppScreenshotType screenshotType, AppScreenshotSize screenshotSize, int screenshotIndex)
        {
            //var rootFilter = new HttpBaseProtocolFilter();
            //rootFilter.CacheControl.ReadBehavior = Windows.Web.Http.Filters.HttpCacheReadBehavior.MostRecent;
            //rootFilter.CacheControl.WriteBehavior = Windows.Web.Http.Filters.HttpCacheWriteBehavior.NoCache;
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("appGuid", appGuid.ToString());
            client.DefaultRequestHeaders.Add("screenshotType", screenshotType.ToString());
            client.DefaultRequestHeaders.Add("screenshotSize", screenshotSize.ToString());
            client.DefaultRequestHeaders.Add("screenshotIndex", screenshotIndex.ToString());
            var response = await client.GetAsync(ServerUri.GetScreenshotDownloadUri(appGuid,screenshotIndex, (ScreenshotType)screenshotType, (ScreenshotSize)screenshotSize));
            var bytes = response.Content.ReadAsBufferAsync().AsTask().Result.ToArray();
            var image = await bytes.ConvertToBitmapImageAsync();

            return new Screenshot()
            {
                AppGuid = appGuid,
                OriginalImage = screenshotSize == AppScreenshotSize.Original ? image : null,
                ThumbnailImage = screenshotSize == AppScreenshotSize.Thumbnail ? image : null,
                Index = screenshotIndex
            };
        }
    }
}
