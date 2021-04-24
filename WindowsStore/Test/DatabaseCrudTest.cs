using Microsoft.VisualStudio.TestTools.UnitTesting;
using Store.DataAccess.Context;
using System.Linq;
using Store.Business.Core;
using Store.DomainService.Core;
using Store.StoreService.Service;
using Store.DomainModel.Entity;
using Store.Common.Enum;
using System;
using System.IO;
using Store.DataAccess.Migrations;
using Store.Common.Configuration;
using Store.Common.Security;
using Store.Common.ExtensionMethod;
using Store.DataAccess.DbInitializing;

namespace Store.Test
{
    [TestClass]
    public class DatabaseCrudTest
    {
        [TestMethod]
        public void SeedDatabase()
        {
            // Seed Database
            WindowsStoreContext context = new WindowsStoreContext();
            WindowsStoreDatabaseInitializer init = new WindowsStoreDatabaseInitializer();
            init.Seed(context);

            // Update Records
            //var paasteel = context.Apps.Single(app => app.Guid == Guid.Empty);
            //paasteel.Icon128x128 = File.ReadAllBytes(@"C:\paasteel128x128.png");
            //paasteel.Icon256x256 = File.ReadAllBytes(@"C:\paasteel256x256.png");
            //paasteel.AppVersions.First().Size = 0;
        }

        #region Add App
        [TestMethod]
        public void AddApp()
        {
            WindowsStoreContext context = new WindowsStoreContext();
            var paasteelProvider = context.LegalPeople.Single(lp => lp.PrimaryEmail == "provider@paasteel.ir");
            var universalPlatform = context.Platforms.First(p => p.PlatformCategory == PlatformCategory.Windows10Universal);
            var appCategories = context.AppCategories.ToList();

            FileInfo packageInfo = new FileInfo(@"D:\WindowsPhoneApps\Music Beta\arm.appx");
            var icon128X128 = File.ReadAllBytes(@"D:\WindowsPhoneApps\zoomit-ir\128.png");
            var icon256X256 = File.ReadAllBytes(@"D:\WindowsPhoneApps\zoomit-ir\128.png");
            var appTitle = "#Music Beta";
            var appDescription =
                "" + Environment.NewLine +
                "" + Environment.NewLine +
                "" + Environment.NewLine +


                "";
            var appVersionDescription = "رفع اشکال نمایش دیدگاه ها";
            var appCategory = appCategories.ElementAt(6);
            var cpuArchitecture = CpuArchitecture.Arm;
            var version = "1.0.0.0";

            var app = new App
            {
                Guid = Guid.NewGuid(),
                Developer = paasteelProvider,
                Name = appTitle,
                Description = appDescription,
                Icon128X128 = icon128X128,
                Icon256X256 = icon256X256,
                AppCategory = appCategory,
                CpuArchitectureFlags = cpuArchitecture,
                State = AppState.Published,
            };
            app.Platforms.Add(universalPlatform);
            app.AppVersions.Add(new AppVersion()
            {
                Description = appVersionDescription,
                Downloads = 0,
                PublishDate = DateTime.Now,
                Version = version,
                Size = packageInfo.Length
            });
            context.Apps.Add(app);
            context.SaveChanges();
        }
        #endregion

        #region Add Apps For Demo

        [TestMethod]
        public void AddDemoApps()
        {
            Random rnd = new Random();
            WindowsStoreContext context = new WindowsStoreContext();
            var developer = context.People.Single(p => p.PrimaryEmail == "provider@paasteel.ir");
            var appCategories = context.AppCategories.ToList();
            var description = string.Concat(Enumerable.Repeat("توضیحات مربوط به برنامه.", 10));
            var universalPlatform = context.Platforms.First(p => p.PlatformCategory == PlatformCategory.Windows10Universal);

            for (int i = 1; i <= 100; i++) {
                var icon128x128 = File.ReadAllBytes($"D:\\png\\1 ({(i % 13) + 1}).png");
                var app = new App
                {
                    Guid = Guid.NewGuid(),
                    Developer = developer,
                    Name = $"برنامه {i}",
                    Description = $"توضیحات مربوط به برنامه شماره {i}",
                    Icon128X128 = icon128x128,
                    Icon256X256 = icon128x128,
                    AppCategory = appCategories.ElementAt(rnd.Next(appCategories.Count())),
                    CpuArchitectureFlags = CpuArchitecture.Arm,
                    State = AppState.Published,
                };

                for (int versionCounter = 1; versionCounter <= 2; versionCounter++) {
                    app.AppVersions.Add(new AppVersion()
                    {
                        Description = description,
                        Downloads = rnd.Next(1000),
                        PublishDate = DateTime.Now.AddDays(rnd.Next(-1000, 1000)),
                        Version = $"{versionCounter}.0.0.0",
                        Size = 0
                    });
                }

                app.Platforms.Add(universalPlatform);
                context.Apps.Add(app);
            }

            context.SaveChanges();
        }

        [TestMethod]
        public void AddDemoAppFiles()
        {
            WindowsStoreContext context = new WindowsStoreContext();
            var apps = context.Apps.Include("Platforms").ToList();
            string fileName;
            var appsDirectory = "C:\\Paasteel\\Apps";

            foreach (var app in apps) {
                Directory.CreateDirectory($"{appsDirectory}\\{app.Guid}");

                //if ((app.CpuArchitectureFlags & CpuArchitecture.Arm) == CpuArchitecture.Arm)
                //{
                fileName = $"{appsDirectory}\\{app.Guid}\\arm.appx";
                File.Copy(@"d:\MyMusic8AnyCPU.appx", fileName);
                //}
            }

        }

        [TestMethod]
        public void SetApps()
        {
            WindowsStoreContext context = new WindowsStoreContext();
            var apps = context.AppVersions.ToList();// .Include("AppVersion").ToList();

            foreach (var app in apps) {
                app.Size = 3161464;
            };

            context.SaveChanges();
        }


        #endregion

        #region Misc CRUD Test
        [TestMethod]
        public void DoCrudAndEnjoy()
        {
            WindowsStoreContext context = new WindowsStoreContext();
            var apps = context.Apps.Where(app => app.Guid != Guid.Empty && app.AppCategory.AppType == AppType.Game)
                .ToList();
            for (int i = 0; i < apps.Count; i++) {
                apps[i].Name = $"بازی شماره {i}";
            }

            //foreach (var app in apps) {
            //    var thumbnailPath = $"C:\\Paasteel\\Apps\\{app.Guid}\\Screenshots\\Thumbnail";
            //    var thumbnails = Directory.EnumerateFiles(thumbnailPath);

            //    thumbnails.ForEach(thumb =>
            //    {
            //        app.Screenshots.Add(new Screenshot()
            //        {
            //            AppId = app.Id,
            //            FileName = Path.GetFileName(thumb),
            //            Type = ScreenshotType.Mobile
            //        });
            //    });

            //}

            context.SaveChanges();
        }

        #endregion
    }
}
