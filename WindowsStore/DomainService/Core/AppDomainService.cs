using Store.Business.Core;
using Store.Business.Interface;
using Store.DataAccess.Context;
using Store.DomainService.Interface;
using System.Collections.Generic;
using System.Linq;
using Store.DataContract;
using Store.DomainService.Mapper;
using Store.Common.ExtensionMethod;
using System;
using System.IO;
using Store.DomainModel.Entity;
using System.Linq.Expressions;
using Store.Common.Configuration;
using Store.Common.Drawing;
using Store.Common.Enum;

namespace Store.DomainService.Core
{
    public class AppDomainService : IAppDomainService
    {
        private readonly WindowsStoreContext _context;

        private IAppBiz AppBiz { get; }
        private IPlatformBiz PlatformBiz { get; }
        private IAppVersionBiz AppVersionBiz { get; }

        private IAppCategoryBiz AppCategoryBiz { get; }
        private IScreenshotBiz ScreenshotBiz { get; }
        public AppDomainService()
        {
            _context = new WindowsStoreContext();
            AppBiz = new AppBiz(_context);
            PlatformBiz = new PlatformBiz(_context);
            AppCategoryBiz = new AppCategoryBiz(_context);
            AppVersionBiz = new AppVersionBiz(_context);
            ScreenshotBiz = new ScreenshotBiz(_context);
        }

        public IEnumerable<AppCategoryDataContract> GetAppCategories()
        {
            return AppCategoryBiz.Where(app => true)
                          .ToList()
                          .Select(app => app.ToAppCategoryDataContract());
        }

        public void RegisterApp(AppDataContract appDataContract)
        {
            AppBiz.Create(appDataContract.ToApp());
            _context.SaveChanges();
        }

        public IEnumerable<AppDetailDataContract> GetDeveloperApps(int developerId)
        {
            var result =
                (from a in AppBiz.GetAll(a => a.AppVersions, a => a.Platforms, a => a.AppCategory, a => a.Ratings)
                 where a.DeveloperId == developerId
                 select new
                 {
                     AppId = a.Id,
                     a.Guid,
                     a.AppCategory.AppType,
                     CategoryId = a.AppCategoryId,
                     a.Description,
                     a.Name,
                     a.State,
                     a.Price,
                     a.Icon128X128,
                     a.Icon256X256,
                     a.CpuArchitectureFlags,
                     PlatformCategories = a.Platforms.Select(p => p.Id),
                     DownloadsCount =
                         a.AppVersions.Any(v => v.AppId == a.Id)
                             ? a.AppVersions.Where(v => v.AppId == a.Id).Sum(v => v.Downloads)
                             : 0,
                     CommentsCount = a.Ratings.Count(r => r.AppId == a.Id),
                     LastVersion = a.AppVersions.OrderByDescending(v => v.PublishDate).FirstOrDefault(),
                     MobileScreenshotsCount = a.Screenshots.Count(sc => sc.AppId == a.Id && sc.Type == ScreenshotType.Mobile),
                     DesktopScreenshotsCount = a.Screenshots.Count(sc => sc.AppId == a.Id && sc.Type == ScreenshotType.Mobile)
                 }).ToList();

            var dataContractResult = (from a in result
                                      select new AppDetailDataContract
                                      {
                                          AppSpecificationDataContract =
                                              new AppSpecificationDataContract
                                              {
                                                  AppId = a.AppId,
                                                  Guid = a.Guid,
                                                  AppType = a.AppType,
                                                  CategoryId = a.CategoryId,
                                                  Description = a.Description,
                                                  Name = a.Name,
                                                  Price = a.Price,
                                                  State = a.State,
                                                  DownloadsCount = a.DownloadsCount,
                                                  CommentsCount = a.CommentsCount,
                                                  MobileScreenshotsCount = a.MobileScreenshotsCount,
                                                  DesktopScreenshotsCount = a.DesktopScreenshotsCount
                                              },
                                          AppIconDataContract =
                                              new AppIconDataContract
                                              {
                                                  AppId = a.AppId,
                                                  Icon128X128 = a.Icon128X128,
                                                  Icon256X256 = a.Icon256X256
                                              },
                                          AppPlatformSpecificationDataContract = new AppPlatformSpecificationDataContract
                                          {
                                              AppId = a.AppId,
                                              CpuArchitectureFlags = a.CpuArchitectureFlags,
                                              PlatformCategories = a.PlatformCategories
                                          },
                                          AppVersionDataContract = a.LastVersion?.ToAppVersionDataContract()
                                      }).ToList();


            foreach (var item in dataContractResult.Where(item => item.AppVersionDataContract != null)) {
                item.AppVersionDataContract.CpuArchitectureFlags =
                    item.AppPlatformSpecificationDataContract.CpuArchitectureFlags;
                item.AppVersionDataContract.HasArmPackage = ExistPackage(item.AppSpecificationDataContract.Guid,
                    CpuArchitecture.Arm);
                item.AppVersionDataContract.HasX64Package = ExistPackage(item.AppSpecificationDataContract.Guid,
                    CpuArchitecture.X64);
                item.AppVersionDataContract.HasX86Package = ExistPackage(item.AppSpecificationDataContract.Guid,
                    CpuArchitecture.X86);
            }

            return dataContractResult;
        }

        public AppDetailDataContract GetDeveloperAppDetail(int developerId,int appId)
        {
            var result =
               (from a in AppBiz.GetAll(a => a.AppVersions, a => a.Platforms, a => a.AppCategory, a => a.Ratings)
                where a.DeveloperId == developerId
                && a.Id == appId
                select new
                {
                    AppId = a.Id,
                    a.Guid,
                    a.AppCategory.AppType,
                    CategoryId = a.AppCategoryId,
                    a.Description,
                    a.Name,
                    a.State,
                    a.Price,
                    a.Icon128X128,
                    a.Icon256X256,
                    a.CpuArchitectureFlags,
                    PlatformCategories = a.Platforms.Select(p => p.Id),
                    DownloadsCount =
                        a.AppVersions.Any(v => v.AppId == a.Id)
                            ? a.AppVersions.Where(v => v.AppId == a.Id).Sum(v => v.Downloads)
                            : 0,
                    CommentsCount = a.Ratings.Count(r => r.AppId == a.Id),
                    LastVersion = a.AppVersions.OrderByDescending(v => v.PublishDate).FirstOrDefault(),
                    MobileScreenshotsCount = a.Screenshots.Count(sc => sc.AppId == a.Id && sc.Type == ScreenshotType.Mobile),
                    DesktopScreenshotsCount = a.Screenshots.Count(sc => sc.AppId == a.Id && sc.Type == ScreenshotType.Mobile)
                }).ToList();

            var dataContractResult = (from a in result
                                      select new AppDetailDataContract
                                      {
                                          AppSpecificationDataContract =
                                              new AppSpecificationDataContract
                                              {
                                                  AppId = a.AppId,
                                                  Guid = a.Guid,
                                                  AppType = a.AppType,
                                                  CategoryId = a.CategoryId,
                                                  Description = a.Description,
                                                  Name = a.Name,
                                                  Price = a.Price,
                                                  State = a.State,
                                                  DownloadsCount = a.DownloadsCount,
                                                  CommentsCount = a.CommentsCount,
                                                  MobileScreenshotsCount = a.MobileScreenshotsCount,
                                                  DesktopScreenshotsCount = a.DesktopScreenshotsCount
                                              },
                                          AppIconDataContract =
                                              new AppIconDataContract
                                              {
                                                  AppId = a.AppId,
                                                  Icon128X128 = a.Icon128X128,
                                                  Icon256X256 = a.Icon256X256
                                              },
                                          AppPlatformSpecificationDataContract = new AppPlatformSpecificationDataContract
                                          {
                                              AppId = a.AppId,
                                              CpuArchitectureFlags = a.CpuArchitectureFlags,
                                              PlatformCategories = a.PlatformCategories
                                          },
                                          AppVersionDataContract = a.LastVersion?.ToAppVersionDataContract()
                                      }).ToList();


            foreach (var item in dataContractResult.Where(item => item.AppVersionDataContract != null))
            {
                item.AppVersionDataContract.CpuArchitectureFlags =
                    item.AppPlatformSpecificationDataContract.CpuArchitectureFlags;
                item.AppVersionDataContract.HasArmPackage = ExistPackage(item.AppSpecificationDataContract.Guid,
                    CpuArchitecture.Arm);
                item.AppVersionDataContract.HasX64Package = ExistPackage(item.AppSpecificationDataContract.Guid,
                    CpuArchitecture.X64);
                item.AppVersionDataContract.HasX86Package = ExistPackage(item.AppSpecificationDataContract.Guid,
                    CpuArchitecture.X86);
            }

            return dataContractResult.Single();
        }

        private static bool ExistPackage(Guid appGuid, CpuArchitecture cpuArchitecture)
        {
            var exist = false;
            switch (cpuArchitecture) {
                case CpuArchitecture.Arm:
                    exist = File.Exists($"{ConfigurationReader.AppsDirectoryPath}\\{appGuid}\\arm.pstl");
                    break;
                case CpuArchitecture.X86:
                    exist = File.Exists($"{ConfigurationReader.AppsDirectoryPath}\\{appGuid}\\x86.pstl");
                    break;
                case CpuArchitecture.X64:
                    exist = File.Exists($"{ConfigurationReader.AppsDirectoryPath}\\{appGuid}\\x64.pstl");
                    break;
            }

            return exist;
        }

        public void RegisterUploadedAppExtraInformation(int appId, int platformId)
        {
            AppBiz.AssociatePlatformToApp(appId, platformId);
            _context.SaveChanges();
        }

        public AppDataContract GetAppDetail(AppFilterDataContract filter, bool includeAppLatestVersion = false)
        {
            Expression<Func<App, bool>> predicate = (a => a.Guid == filter.AppGuid);
            App app;

            if (!filter.Include128X128Icon && !filter.Include256X256Icon)
                app = AppBiz.GetAppWithoutIcons(predicate);
            else if (filter.Include128X128Icon && !filter.Include256X256Icon)
                app = AppBiz.GetAppWith128X128Icon(predicate);
            else if (!filter.Include128X128Icon && filter.Include256X256Icon)
                app = AppBiz.GetAppWith256X256Icon(predicate);
            else
                app = AppBiz.GetAppWithIcons(predicate);

            var appDc = app.ToAppDataContract();
            if (!includeAppLatestVersion) return appDc;
            appDc.LatestVersion = app.AppVersions.OrderByDescending(appVersion => appVersion.PublishDate).First().ToAppVersionDataContract();
            return appDc;
        }

        public AppDataContract GetAppDetail(Guid appGuid, bool include128X128Icon, bool include256X256Icon, bool includeAppLatestVersion = false)
        {
            return GetAppDetail(new AppFilterDataContract()
            {
                AppGuid = appGuid,
                Include128X128Icon = include128X128Icon,
                Include256X256Icon = include256X256Icon
            }, includeAppLatestVersion);
        }

        public IEnumerable<AppDataContract> GetApps(AppFilterDataContract filter)
        {
            var appFilter = filter.ToAppFilter();
            var appsQuery = AppBiz.GetApps(appFilter)
                .Page(appFilter);

            if (filter.Include128X128Icon && !filter.Include256X256Icon) {
                return appsQuery.Select(app => new AppDataContract()
                {
                    Guid = app.Guid,
                    Name = app.Name,
                    Icon128X128 = app.Icon128X128,
                    Price = app.Price
                }).ToList();
            }
            else {
                return appsQuery.Select(app => new AppDataContract()
                {
                    Guid = app.Guid,
                    Name = app.Name,
                    Price = app.Price
                }).ToList();
            }
        }

        public IEnumerable<AppVersionDataContract> GetAppsLatestVersionInfo(IEnumerable<Guid> appGuids)
        {
            return AppBiz.GetAppsLatestVersion(appGuids).Select(appVersion => new AppVersionDataContract()
            {
                AppGuid = appVersion.App.Guid,
                Version = appVersion.Version,
                PublishDate = appVersion.PublishDate,
            }).ToList();
        }

        public void IncrementAppLatestVersionDownloads(int appId, int incerementValue = 1)
        {
            AppBiz.IncrementAppLatestVersionDownloads(appId, incerementValue);
            _context.SaveChanges();
        }

        public void IncrementAppLatestVersionDownloads(Guid guid, int incerementValue = 1)
        {
            AppBiz.IncrementAppLatestVersionDownloads(guid, incerementValue);
            _context.SaveChanges();
        }

        public bool ExistsAppName(string appName, int appId)
        {
            return AppBiz.Any(app => app.Name == appName && app.Id != appId);
        }

        public void UpdateAppSpecification(AppSpecificationDataContract appSpecification)
        {
            AppBiz.UpdatePartially(appSpecification.ToApp()
                , a => a.Name
                , a => a.Price
                , a => a.AppCategoryId
                , a => a.Description);

            _context.SaveChanges();
        }

        public AppSpecificationDataContract RegisterAppSpecification(AppSpecificationDataContract appSpecificationDataContract, int developerId)
        {
            var app = appSpecificationDataContract.ToApp();

            // set app intial state
            app.State = AppState.Incomplete;
            app.Guid = Guid.NewGuid();
            app.DeveloperId = developerId;
            // register app
            var savedApp = AppBiz.Create(app);
            _context.SaveChanges();

            return savedApp.ToAppSpecificationDataContract();
        }

        public void RegisterAppIcon(AppIconDataContract appIconDataContract)
        {
            var app = appIconDataContract.ToApp();

            if (appIconDataContract.Icon128X128 == null)
                app.Icon128X128 = ImageConverter.ResizeByteArrayImage(appIconDataContract.Icon256X256, 128, 128);

            AppBiz.UpdatePartially(appIconDataContract.ToApp(), a => a.Icon128X128, a => a.Icon256X256);
            _context.SaveChanges();
        }

        public void RegisterAppPlatformSpecification(AppPlatformSpecificationDataContract appPlatformSpecificationDataContract)
        {
            // update CpuArchitecture
            AppBiz.UpdatePartially(appPlatformSpecificationDataContract.ToApp(), a => a.CpuArchitectureFlags);


            // update AppPlatformCategories
            // fetch app
            var app = _context.Apps.Include("Platforms").Single(a => a.Id == appPlatformSpecificationDataContract.AppId);

            var oldPlatforms = app.Platforms.ToList();

            //var person = PersonBiz.Single(p => p.Id == userId);
            //var role = RoleBiz.Single(r => r.Name == roleName);

            //person.Roles.Add(role);
            // remove all app platforms
            foreach (var platform in oldPlatforms) {
                app.Platforms.Remove(platform);
            }

            // fetch all platforms
            // var platformCategories = _context.Platforms.ToList();

            var newPlatforms =
    PlatformBiz.Where(p => appPlatformSpecificationDataContract.PlatformCategories.Contains(p.Id));
            // add platforms that exist in list into appPltforms
            foreach (var platform in newPlatforms) {
                app.Platforms.Add(platform);
            }

            _context.SaveChanges();
        }

        public AppVersionDataContract RegisterAppVersion(AppVersionDataContract appVersionDataContract)
        {
            var result = AppVersionBiz.Create(appVersionDataContract.ToAppVersion()).ToAppVersionDataContract();
            var app = AppBiz.Single(a => a.Id == appVersionDataContract.AppId);
            app.State = AppState.Published;
            AppBiz.UpdatePartially(app, a => a.State);     
            _context.SaveChanges();
            return result;
        }

        public void UpdateAppVersion(AppVersionDataContract appVersionDataContract)
        {
            AppVersionBiz.UpdatePartially(appVersionDataContract.ToAppVersion(), v => v.Description, v => v.Version);
            _context.SaveChanges();
        }



        public ServerDescriptorDataContract GetServerDescriptor(UserClientDescriptorDataContract userClientDescriptor)
        {
            return new ServerDescriptorDataContract()
            {
                SupportedUserClientMinVersion = ConfigurationReader.SupportedUserClientMinVersion,
                SupportedUserClientMaxVersion = ConfigurationReader.SupportedUserClientMaxVersion,
                SupportedDeveloperClientMaxVersion = ConfigurationReader.SupportedDeveloperClientMinVersion,
                SupportedDeveloperClientMinVersion = ConfigurationReader.SupportedDeveloperClientMaxVersion,
            };
        }

        #region Screenshots
        public void RemoveScreenshot(ScreenshotDataContract screenshotDataContract, int developerId)
        {
            if (!ScreenshotBiz.Any(sc => sc.App.DeveloperId == developerId && sc.Id == screenshotDataContract.Id))
                return;

            ScreenshotBiz.Delete(screenshotDataContract.ToScreenshot());
            _context.SaveChanges();

            RemoveScreenshotOnFileSystem(screenshotDataContract);
        }
        public void SaveScreenshot(ScreenshotDataContract screenshotDataContract)
        {
            ScreenshotBiz.Create(screenshotDataContract.ToScreenshot());
            SaveScreenshotOnFileSystem(screenshotDataContract);
            _context.SaveChanges();
        }

        private static void SaveScreenshotOnFileSystem(ScreenshotDataContract screenshotDataContract)
        {
            var thumbnailPath = GetScreenshotPath(screenshotDataContract.AppGuid, screenshotDataContract.FileName, ScreenshotSize.Thumbnail);
            var originalPath = GetScreenshotPath(screenshotDataContract.AppGuid, screenshotDataContract.FileName, ScreenshotSize.Original);

            File.WriteAllBytes(originalPath, ImageConverter.ResizeByteArrayImage(screenshotDataContract.ImageSource, 1280));
            File.WriteAllBytes(thumbnailPath, ImageConverter.ResizeByteArrayImage(screenshotDataContract.ImageSource, 400));
        }
        private static void RemoveScreenshotOnFileSystem(ScreenshotDataContract screenshot)
        {
            var thumbnailPath = GetScreenshotPath(screenshot.AppGuid, screenshot.FileName, ScreenshotSize.Thumbnail);
            var originalPath = GetScreenshotPath(screenshot.AppGuid, screenshot.FileName, ScreenshotSize.Original);

            File.Delete(originalPath);
            File.Delete(thumbnailPath);
        }



        public ScreenshotDataContract GetAppScreenshot(ScreenshotFilterDataContract filter)
        {
            var bytes = AppBiz.GetAppScreenshot(filter.AppGuid, filter.ScreenshotType, filter.ScreenshotSize, filter.ScreenshotIndex);
            return new ScreenshotDataContract()
            {
                Original = filter.ScreenshotSize == ScreenshotSize.Original ? bytes : null,
                Thumbnail = filter.ScreenshotSize == ScreenshotSize.Thumbnail ? bytes : null,
            };
        }
        public string GetAppScreenshotFilePath(Guid appGuid, ScreenshotType screenshotType, ScreenshotSize screenshotSize, int screenshotIndex)
        {
            return AppBiz.GetAppScreenshotFilePath(appGuid, screenshotType, screenshotSize, screenshotIndex);
        }


        /// <summary>
        /// need appId and screenshotType paramteres
        /// </summary>
        /// <param name="filter"></param>
        /// <returns>screenshot ids list</returns>
        public List<int> GetScreenshotIds(ScreenshotFilterDataContract filter)
        {
            return ScreenshotBiz.Where(s => s.AppId == filter.AppId && s.Type == filter.ScreenshotType).Select(sc => sc.Id).ToList();
        }
        /// <summary>
        /// needs screenshotId , screenshotSize parameters
        /// </summary>
        /// <param name="filter"></param>
        /// <returns>Screenshot</returns>
        public ScreenshotDataContract GetScreenshot(ScreenshotFilterDataContract filter)
        {
            var appScreenshot = ScreenshotBiz.Single(s => s.Id == filter.ScreenshotId, s => s.App);
            var path = GetScreenshotPath(appScreenshot.App.Guid, appScreenshot.FileName, filter.ScreenshotSize);

            var appScreenshotDataContract = appScreenshot.ToScreenshotDataContract();

            // load screenshot file
            var bytes = File.ReadAllBytes(path);
            appScreenshotDataContract.Original = filter.ScreenshotSize == ScreenshotSize.Original ? bytes : null;
            appScreenshotDataContract.Thumbnail = filter.ScreenshotSize == ScreenshotSize.Thumbnail ? bytes : null;

            return appScreenshotDataContract;
        }

        private static string GetScreenshotPath(Guid appGuid, string fileName, ScreenshotSize screenshotSize)
        {
            var directoryPath = $@"{ConfigurationReader.AppsDirectoryPath}\{appGuid}\Screenshots\{screenshotSize}\";

            if (!Directory.Exists(directoryPath))
                Directory.CreateDirectory(directoryPath);

            return $"{directoryPath}{fileName}";
        }

        public IEnumerable<AppDataContract> GetRandomApps(AppFilterDataContract filter)
        {
            var appFilter = filter.ToAppFilter();
            var apps = AppBiz
                .GetApps(appFilter)
                .OrderBy(app => Guid.NewGuid())
                .Take(filter.PageSize)
                .Select(app => new AppDataContract()
                {
                    Guid = app.Guid,
                    Name = app.Name,
                    Icon128X128 = app.Icon128X128,
                    Price = app.Price
                }).ToList();
            return apps;
        }

        public string GetAppBackgroundFilePath(Guid appGuid)
        {
            var pngPath = $@"{ConfigurationReader.AppsDirectoryPath}\{appGuid}\Background\background.png";
            var jpgPath = $@"{ConfigurationReader.AppsDirectoryPath}\{appGuid}\Background\background.jpg";
            if (File.Exists(pngPath))
                return pngPath;
            else
                return jpgPath;
        }


        public byte[] GetAppIcon256(Guid appGuid)
        {
            return AppBiz.Where(a => a.Guid == appGuid).Select(a => a.Icon256X256).Single();
        }

        public byte[] GetAppIcon128(Guid appGuid)
        {
            return AppBiz.Where(a => a.Guid == appGuid).Select(a => a.Icon128X128).Single();
        }
        #endregion

    }
}
