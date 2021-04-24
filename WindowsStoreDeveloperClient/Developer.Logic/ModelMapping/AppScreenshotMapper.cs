using System.Threading.Tasks;
using WindowsStore.Client.Developer.Logic.DeveloperService;
using WindowsStore.Client.Developer.Common.ExtensionMethod;
using WindowsStore.Client.Developer.Logic.Models;

namespace WindowsStore.Client.Developer.Logic.ModelMapping
{
    public static class AppScreenshotMapper
    {
        public async static Task<ScreenshotDataContract> ToAppScreenshotDataContract(this AppScreenshot screenshot)
        {
            return new ScreenshotDataContract()
            {
                Id = screenshot.Id,
                AppId = screenshot.AppId,
                AppGuid = screenshot.AppGuid,
                FileName = screenshot.FileName,
                ScreenshotSize = screenshot.ScreenshotSize,
                ScreenshotType = screenshot.ScreenshotType,
                ImageSource = await screenshot.SourceImageStorageFile.AsByteArrayAsync(),
            };
        }

        public async static Task<AppScreenshot> ToAppScreenshotAsync(this ScreenshotDataContract screenshotDatacontract)
        {
            return new AppScreenshot()
            {
                AppId = screenshotDatacontract.AppId,
                AppGuid = screenshotDatacontract.AppGuid,
                FileName = screenshotDatacontract.FileName,
                Id = screenshotDatacontract.Id,
                ScreenshotSize = screenshotDatacontract.ScreenshotSize,
                ScreenshotType = screenshotDatacontract.ScreenshotType,
                Thumbnail = await screenshotDatacontract.Thumbnail.AsBitmapImageAsync(),
                Original = await screenshotDatacontract.Original.AsBitmapImageAsync()
            };
        }
    }
}
