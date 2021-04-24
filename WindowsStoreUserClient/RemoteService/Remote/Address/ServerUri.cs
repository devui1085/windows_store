using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsStore.Client.User.Service.UserService;

namespace WindowsStore.Client.User.Service.Remote.Address
{
    public static class ServerUri
    {
        private static string host;
        static ServerUri()
        {
            host = "api.paasteel.ir";
            //host = "test.paasteel.ir";
            //host = "Mehrdad-PC/StoreService";
            //host = "localhost:1578";
        }

        public static Uri GetUserWcfServiceUri()
        {
            return new Uri($"http://{host}/Service/UserService.svc", UriKind.Absolute);
        }

        public static Uri GetAppDownloadUri(Guid appGuid)
        {
            var url = $"http://{host}/appcode/httphandler/appdownload.ashx/?appguid={appGuid}";
            return new Uri(url, UriKind.Absolute);
        }

        public static Uri GetScreenshotDownloadUri()
        {
            var url = $"http://{host}/appcode/httphandler/AppScreenshotDownload.ashx";
            return new Uri(url, UriKind.Absolute);
        }

        public static Uri GetScreenshotDownloadUri(Guid appId, int index, ScreenshotType type, ScreenshotSize size)
        {
            var url = $"http://{host}/appcode/httphandler/AppScreenshotDownload.ashx?appId={appId}&index={index}&type={type}&size={size}";
            return new Uri(url, UriKind.Absolute);
        }

        internal static Uri GetAppBackgroundImageUri(Guid appGuid)
        {
            var url = $"http://{host}/appcode/httphandler/AppBackgroundImageDownload.ashx?appGuid={appGuid}";
            return new Uri(url, UriKind.Absolute);
        }
    }
}
