using WindowsStore.Client.Developer.Logic.DeveloperService;
using WindowsStore.Client.Developer.Logic.Models;

namespace WindowsStore.Client.Developer.Logic.ModelMapping
{
    public static class AppScreenshotFilterMapper
    {
        public static ScreenshotFilterDataContract ToScreenshotFilterDataContract(this AppScreenshotFilter screenshotFitler)
        {
            return new ScreenshotFilterDataContract()
            {
                AppId = screenshotFitler.AppId,
                AppGuid = screenshotFitler.AppGuid,
                ScreenshotType =screenshotFitler.ScreenshotType,
                ScreenshotSize = screenshotFitler.ScreenshotSize,
                ScreenshotId  = screenshotFitler.ScreenshotId
            };
        }

        public static AppScreenshotFilter ToAppScreenshotFilter(this ScreenshotFilterDataContract screenShotFilterDataContract)
        {
            return new AppScreenshotFilter()
            {
                AppId = screenShotFilterDataContract.AppId,
                AppGuid = screenShotFilterDataContract.AppGuid,
                ScreenshotType= screenShotFilterDataContract.ScreenshotType,
                ScreenshotSize= screenShotFilterDataContract.ScreenshotSize,
                ScreenshotId= screenShotFilterDataContract.ScreenshotId
            };
        }
    }
}
