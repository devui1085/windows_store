using System.Collections.Generic;
using Store.Common.Infrastructure;
using Store.DataContract;
using System;
using Store.Common.Enum;

namespace Store.DomainService.Interface
{
    public interface IAppDomainService
    {
        IEnumerable<AppCategoryDataContract> GetAppCategories();
        void RegisterApp(AppDataContract appDataContract);
        IEnumerable<AppDetailDataContract> GetDeveloperApps(int developerId);
        AppDetailDataContract GetDeveloperAppDetail(int developerId,int appId);
        void RegisterUploadedAppExtraInformation(int appId, int platformId);
        AppDataContract GetAppDetail(AppFilterDataContract filter, bool includeAppLatestVersion = false);
        AppDataContract GetAppDetail(Guid appGuid, bool include128X128Icon, bool include256X256Icon, bool includeAppLatestVersion = false);
        string GetAppBackgroundFilePath(Guid appGuid);
        IEnumerable<AppDataContract> GetApps(AppFilterDataContract filter);
        IEnumerable<AppVersionDataContract> GetAppsLatestVersionInfo(IEnumerable<Guid> appGuids);
        void IncrementAppLatestVersionDownloads(int appId, int incerementValue = 1);
        void IncrementAppLatestVersionDownloads(Guid guid, int incerementValue = 1);
        ServerDescriptorDataContract GetServerDescriptor(UserClientDescriptorDataContract userClientDescriptor);
        bool ExistsAppName(string appName,int appId);
        void UpdateAppSpecification(AppSpecificationDataContract appSpecification);
        AppSpecificationDataContract RegisterAppSpecification(AppSpecificationDataContract appSpecification,int developerId);
        IEnumerable<AppDataContract> GetRandomApps(AppFilterDataContract filter);
        void RegisterAppIcon(AppIconDataContract appIconDataContract);
        void RegisterAppPlatformSpecification(AppPlatformSpecificationDataContract appPlatformSpecificationDataContract);
        ScreenshotDataContract GetAppScreenshot(ScreenshotFilterDataContract filter);
        AppVersionDataContract RegisterAppVersion(AppVersionDataContract appVersionDataContract);
        void UpdateAppVersion(AppVersionDataContract appVersionDataContract);
        void SaveScreenshot(ScreenshotDataContract screenshotDataContract);
        void RemoveScreenshot(ScreenshotDataContract screenshotDataContract,int developerId);
        string GetAppScreenshotFilePath(Guid appGuid, ScreenshotType screenshotType, ScreenshotSize screenshotSize, int screenshotIndex);
        List<int> GetScreenshotIds(ScreenshotFilterDataContract filter);
        ScreenshotDataContract GetScreenshot(ScreenshotFilterDataContract filter);
        byte[] GetAppIcon256(Guid appGuid);
        byte[] GetAppIcon128(Guid appGuid);
    }
}