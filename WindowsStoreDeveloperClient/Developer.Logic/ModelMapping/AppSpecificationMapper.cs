using WindowsStore.Client.Developer.Logic.DeveloperService;
using WindowsStore.Client.Developer.Logic.Models;

namespace WindowsStore.Client.Developer.Logic.ModelMapping
{
    public static class AppSpecificationMapper
    {
        public static AppSpecificationDataContract ToAppSpecificationDataContract(this AppSpecification appSpecification)
        {
            return new AppSpecificationDataContract()
            {
                AppId = appSpecification.AppId,
                Guid = appSpecification.Guid,
                AppType = appSpecification.AppType,
                CategoryId = appSpecification.CategoryId,
                Description = appSpecification.Description,
                Price = appSpecification.Price,
                Name = appSpecification.Name,
                State = appSpecification.State
            };
        }

        public  static AppSpecification ToAppSpecification(this AppSpecificationDataContract appSpecificationDataContract)
        {
            return new AppSpecification()
            {
                AppId = appSpecificationDataContract.AppId,
                Guid = appSpecificationDataContract.Guid,
                AppType = appSpecificationDataContract.AppType,
                CategoryId = appSpecificationDataContract.CategoryId,
                Description = appSpecificationDataContract.Description,
                Price = appSpecificationDataContract.Price,
                Name =appSpecificationDataContract.Name,
                DownloadsCount = appSpecificationDataContract.DownloadsCount,
                CommentsCount =appSpecificationDataContract.CommentsCount,
                DesktopScreenshotsCount = appSpecificationDataContract.DesktopScreenshotsCount,
                MobileScreenshotsCount= appSpecificationDataContract.MobileScreenshotsCount,
                State= appSpecificationDataContract.State
            };
        }
    }
}
