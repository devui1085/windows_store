using Store.Business.Interface;
using Store.DataAccess.Context;
using Store.DomainModel.Entity;
using System.Linq;
using Store.Common.Enum;
using Store.DomainModel.EntityFilter;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Store.Common.Configuration;
using System.IO;

namespace Store.Business.Core
{
    public class AppBiz : BaseBiz<App>, IAppBiz
    {
        private readonly WindowsStoreContext _context;

        public AppBiz(WindowsStoreContext context) : base(context)
        {
            _context = context;
        }

        public IQueryable<App> GetPersonApps(int userId)
        {
            return Where(app => app.DeveloperId == userId);
        }


        public void AssociatePlatformToApp(int appId, int platformId)
        {
            var platform = _context.Platforms.Single(p => p.Id == platformId);
            var app = _context.Apps.Single(a => a.Id == appId);

            app.Platforms.Add(platform);
        }

        public IQueryable<App> GetApps(AppFilter filter)
        {
            var query = GetAvailableAppsForEndUser();

            // Applying filters
            if (filter.FeaturedApp.HasValue) {
                if (filter.FeaturedApp.Value)
                    query = query.Where(app => app.FeaturedApp != null);
                else
                    query = query.Where(app => app.FeaturedApp == null);
            }

            if (filter.AppCategoryId.HasValue)
                query = query.Where(app => app.AppCategoryId == filter.AppCategoryId);

            if (filter.AppPricing.HasValue) {
                query =
                    filter.AppPricing.Value == AppPricing.FreeApp
                    ? query.Where(app => app.Price == 0)
                    : query.Where(app => app.Price > 0);
            }

            if (filter.AppType.HasValue) {
                query = query.Where(app => app.AppCategory.AppType == filter.AppType.Value);
            }

            if (filter.AppOrderMethod == AppOrderMethod.Top)
                query = query.OrderBy(app => app.AppVersions.Sum(appVersion => appVersion.Downloads));
            else
                // Ordering apps are necessery for server side Paging
                query = query.OrderBy(app => app.Id);

            
            return query;
        }

        public IQueryable<App> GetAvailableAppsForEndUser()
        {
            return _context.Apps.Where(app => app.State == AppState.Published);
        }

        public IQueryable<AppVersion> GetAppsLatestVersion(IEnumerable<Guid> appGuids)
        {
            return
              _context.AppVersions
             .Where(appVersion => appGuids.Contains(appVersion.App.Guid))
             .GroupBy(appVersion => appVersion.AppId)
             .Select(group => group.OrderByDescending(appVersion => appVersion.PublishDate).FirstOrDefault());
        }

        public void IncrementAppLatestVersionDownloads(int appId, int incrementValue = 1)
        {
            var latestVersion = _context.AppVersions
                .Where(appVersion => appVersion.App.Id == appId)
               .OrderByDescending(appVersion => appVersion.PublishDate)
               .First();
            latestVersion.Downloads += incrementValue;
        }

        public void IncrementAppLatestVersionDownloads(Guid guid, int incrementValue = 1)
        {
            var latestVersion = _context.AppVersions
                .Where(appVersion => appVersion.App.Guid == guid)
               .OrderByDescending(appVersion => appVersion.PublishDate)
               .First();
            latestVersion.Downloads += incrementValue;
        }
        public App GetAppWithIcons(Expression<Func<App, bool>> appPredicate)
        {
            return _context.Apps.Single(appPredicate);
        }

        public App GetAppWith128X128Icon(Expression<Func<App, bool>> appPredicate)
        {
            var app = _context.Apps
                .Where(appPredicate)
                .Select(a => new
                {
                    AppCategory = a.AppCategory,
                    AppCategoryId = a.AppCategoryId,
                    CpuArchitectureFlags = a.CpuArchitectureFlags,
                    AppVersions = a.AppVersions,
                    Description = a.Description,
                    Developer = a.Developer,
                    DeveloperId = a.DeveloperId,
                    Icon128x128 = a.Icon128X128,
                    Guid = a.Guid,
                    Id = a.Id,
                    State = a.State,
                    Title = a.Name
                })
                .Single();

            return new App()
            {
                AppCategory = app.AppCategory,
                AppCategoryId = app.AppCategoryId,
                CpuArchitectureFlags = app.CpuArchitectureFlags,
                AppVersions = app.AppVersions,
                Description = app.Description,
                Developer = app.Developer,
                DeveloperId = app.DeveloperId,
                Icon128X128 = app.Icon128x128,
                Guid = app.Guid,
                Id = app.Id,
                State = app.State,
                Name = app.Title
            };

        }

        public App GetAppWith256X256Icon(Expression<Func<App, bool>> appPredicate)
        {
            var app = _context.Apps
                .Where(appPredicate)
                .Select(a => new
                {
                    AppCategory = a.AppCategory,
                    AppCategoryId = a.AppCategoryId,
                    CpuArchitectureFlags = a.CpuArchitectureFlags,
                    AppVersions = a.AppVersions,
                    Description = a.Description,
                    Developer = a.Developer,
                    DeveloperId = a.DeveloperId,
                    Icon256x256 = a.Icon256X256,
                    Guid = a.Guid,
                    Id = a.Id,
                    State = a.State,
                    Title = a.Name
                })
                .Single();

            return new App()
            {
                AppCategory = app.AppCategory,
                AppCategoryId = app.AppCategoryId,
                CpuArchitectureFlags = app.CpuArchitectureFlags,
                AppVersions = app.AppVersions,
                Description = app.Description,
                Developer = app.Developer,
                DeveloperId = app.DeveloperId,
                Icon256X256 = app.Icon256x256,
                Guid = app.Guid,
                Id = app.Id,
                State = app.State,
                Name = app.Title
            };
        }

        public App GetAppWithoutIcons(Expression<Func<App, bool>> appPredicate)
        {
            var app = _context.Apps
                .Where(appPredicate)
                .Select(a => new
                {
                    AppCategory = a.AppCategory,
                    AppCategoryId = a.AppCategoryId,
                    CpuArchitectureFlags = a.CpuArchitectureFlags,
                    AppVersions = a.AppVersions,
                    Screenshots = a.Screenshots,
                    Description = a.Description,
                    Developer = a.Developer,
                    DeveloperId = a.DeveloperId,
                    Guid = a.Guid,
                    Id = a.Id,
                    State = a.State,
                    Title = a.Name
                })
                .Single();

            return new App()
            {
                AppCategory = app.AppCategory,
                AppCategoryId = app.AppCategoryId,
                CpuArchitectureFlags = app.CpuArchitectureFlags,
                AppVersions = app.AppVersions,
                Screenshots = app.Screenshots,
                Description = app.Description,
                Developer = app.Developer,
                DeveloperId = app.DeveloperId,
                Guid = app.Guid,
                Id = app.Id,
                State = app.State,
                Name = app.Title
            };
        }

        public void UpdateApp(App app, params Expression<Func<App, object>>[] changedProperties)
        {
            _context.Apps.Attach(app);

            foreach (var property in changedProperties) {
                _context.Entry(app).Property(property).IsModified = true;
            }
        }

        public byte[] GetAppScreenshot(Guid appGuid, ScreenshotType screenshotType, ScreenshotSize screenshotSize, int screenshotIndex)
        {
            var path = GetAppScreenshotFilePath(appGuid, screenshotType, screenshotSize, screenshotIndex);
            return File.ReadAllBytes(path);
        }

        public string GetAppScreenshotFilePath(Guid appGuid, ScreenshotType screenshotType, ScreenshotSize screenshotSize, int screenshotIndex)
        {
            var appScreenshot = _context.Apps
                .Single(app => app.Guid == appGuid)
                .Screenshots
                .Where(screenshot => screenshot.Type == screenshotType)
                .Skip(screenshotIndex)
                .Take(1)
                .Single();
            return
                $@"{ConfigurationReader.AppsDirectoryPath}\{appGuid}\Screenshots\{screenshotSize}\{
                    appScreenshot.FileName}";
        }
    }
}
