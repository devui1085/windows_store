using WindowsStore.Client.User.Common.PresentationModel;
using WindowsStore.Client.User.Service.UserService;

namespace WindowsStore.Client.User.Service.Remote.ModelMapping
{
    public static class StoreAppMapper
    {
        public static AppDataContract GetAppDC(this StoreApp model)
        {
            return new AppDataContract()
            {
                AppCategory = model.AppCategory?.GetAppCategoryDC(),
                Description = model.Description,
                DeveloperId = model.DeveloperId,
                DeveloperName = model.DeveloperName,
                Icon128X128 = model.Icon128x128Bytes,
                Icon256X256 = model.Icon256x256Bytes,
                Id = model.Id,
                Guid = model.Guid,
                Name = model.Name,
                Price = model.Price,
                LatestVersion = model?.LatestVersion.GetAppVersionDC()
            };
        }

        public static StoreApp GetStoreApp(this AppDataContract dataContract)
        {
            return new StoreApp()
            {
                AppCategory = dataContract.AppCategory?.GetAppCategory(),
                Description = dataContract.Description,
                DeveloperId = dataContract.DeveloperId,
                DeveloperName = dataContract.DeveloperName,
                Icon128x128Bytes = dataContract.Icon128X128,
                Icon256x256Bytes = dataContract.Icon256X256,
                Id = dataContract.Id,
                Guid = dataContract.Guid,
                Name = dataContract.Name,
                Price = dataContract.Price,
                LatestVersion = dataContract.LatestVersion?.GetAppVersion(),
                NumberOfMobileScreenshots = dataContract.NumberOfMobileScreenshots
            };
        }
    }
}
