using WindowsStore.Client.User.Common.PresentationModel;
using WindowsStore.Client.User.Service.UserService;

namespace WindowsStore.Client.User.Service.Remote.ModelMapping
{
    public static class AppVersionMapper
    {
        public static AppVersionDataContract GetAppVersionDC(this AppVersion appVersion)
        {
            return new AppVersionDataContract()
            {
                Id = appVersion.Id,
                Version = appVersion.Version,
                PublishDate = appVersion.PublishDate,
                Description = appVersion.Description,
                AppId = appVersion.AppId,
                Downloads = appVersion.Downloads,
                Size = appVersion.Size,
                AppGuid = appVersion.AppGuid
            };
        }

        public static AppVersion GetAppVersion(this AppVersionDataContract dataContract)
        {
            return new AppVersion()
            {
                Id = dataContract.Id,
                Version = dataContract.Version,
                PublishDate = dataContract.PublishDate,
                Description = dataContract.Description,
                AppId = dataContract.AppId,
                Downloads = dataContract.Downloads,
                Size = dataContract.Size,
                AppGuid = dataContract.AppGuid
            };
        }
    }
}
