using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsStore.Client.User.Common.Enum;
using WindowsStore.Client.User.Common.Infrastructure;
using WindowsStore.Client.User.Common.PresentationModel;
using WindowsStore.Client.User.Service.Remote.Wcf;
using WindowsStore.Client.User.Service.Remote.Http;
using Windows.UI.Xaml.Media.Imaging;

namespace WindowsStore.Client.User.Service.ApplicationService
{
    public class AppManager
    {
        static AppManager _instance;
        Remote.Wcf.UserService _userService;

        public static AppManager Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new AppManager();
                return _instance;
            }
        }

        private AppManager()
        {
            _userService = new Remote.Wcf.UserService();
        }

        public async Task<IEnumerable<AppCategory>> GetAppCategoriesAsync()
        {
            return await _userService.GetAppCategoriesAsync();
        }

        public async Task<IEnumerable<StoreApp>> GetAppsAsync(AppQueryParameters appQueryParameters)
        {
            return await _userService.GetAppsAsync(appQueryParameters);
        }

        public async Task<IEnumerable<StoreApp>> GetRandomAppsAsync(AppQueryParameters appQueryParameters)
        {
            return await _userService.GetRandomAppsAsync(appQueryParameters);
        }

        public async Task<StoreApp> GetAppDetailsAsync(Guid appGuid)
        {
            return await _userService.GetAppDetailsAsync(new AppQueryParameters()
            {
                AppGuid = appGuid,
                Include128x128Icon = false,
                Include256x256Icon = false,
            });
        }

        public async Task<Screenshot> GetAppScreenShotAsync(Guid appGuid, AppScreenshotType appScreenshotType, AppScreenshotSize appScreenshotSize,  int screenShotIndex)
        {
            return await HttpTransfer.GetAppScreenshotAsync(
                appGuid,
                appScreenshotType,
                appScreenshotSize,
                screenShotIndex);
        }

        public async Task<BitmapImage> GetAppBackgroundImageAsync(Guid appGuid)
        {
            return await HttpTransfer.GetAppBackgroundImageAsync(appGuid);
        }
    }
}
