using Store.DomainModel.Entity;
using System.Linq;
using Store.DomainModel.EntityFilter;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Store.Common.Enum;

namespace Store.Business.Interface
{
    public interface IAppBiz : IBaseBiz<App>
    {
        IQueryable<App> GetPersonApps(int userId);
        void AssociatePlatformToApp(int appId, int platformId);
        IQueryable<App> GetApps(AppFilter filter);
        IQueryable<App> GetAvailableAppsForEndUser();
        IQueryable<AppVersion> GetAppsLatestVersion(IEnumerable<Guid> appGuids);
        void IncrementAppLatestVersionDownloads(int appId, int incrementValue = 1);
        void IncrementAppLatestVersionDownloads(Guid guid, int incrementValue = 1);
        App GetAppWithIcons(Expression<Func<App, bool>> appPredicate);
        App GetAppWith128X128Icon(Expression<Func<App, bool>> appPredicate);
        App GetAppWith256X256Icon(Expression<Func<App, bool>> appPredicate);
        App GetAppWithoutIcons(Expression<Func<App, bool>> appPredicate);
        byte[] GetAppScreenshot(Guid appGuid, ScreenshotType screenshotType, ScreenshotSize screenShotSize, int screenShotIndex);
        string GetAppScreenshotFilePath(Guid appGuid, ScreenshotType screenshotType, ScreenshotSize screenshotSize, int screenshotIndex);
    }
}
