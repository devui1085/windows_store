using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store.DataContract;
using Store.DomainModel.Entity;

namespace Store.DomainService.Mapper
{
    internal static class ScreenshotDataContractMapper
    {
        public static Screenshot ToScreenshot(this ScreenshotDataContract screenshotDataContract)
        {
            return new Screenshot()
            {
                Id = screenshotDataContract.Id,
                AppId = screenshotDataContract.AppId,
                FileName =screenshotDataContract.FileName,
                Type = screenshotDataContract.ScreenshotType
            };
        }

        public static ScreenshotDataContract ToScreenshotDataContract(this Screenshot screenshot)
        {
            return new ScreenshotDataContract()
            {
                Id = screenshot.Id,
                AppGuid= screenshot.App.Guid,
                AppId = screenshot.AppId,
                FileName = screenshot.FileName,
                ScreenshotType = screenshot.Type
            };
        }
    }
}
