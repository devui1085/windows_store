using System;
using System.Collections.Generic;
using System.ServiceModel;
using Store.Common.Enum;
using Store.DataContract;
using Store.DomainService.Core;
using Store.DomainService.Interface;
using Store.StoreService.AppCode.Extensibility;
using Store.StoreService.ServiceContract;

namespace Store.StoreService.Service
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    [ServiceFaultBehavior]
    public class PortalService : IPortalService
    {
        private IAppDomainService AppDomainService { get; }

        public PortalService()
        {
            AppDomainService = new AppDomainService();
        }

        public IEnumerable<AppCategoryDataContract> GetAppCategories()
        {
            return AppDomainService.GetAppCategories();
        }

        public AppDataContract GetAppDetail(AppFilterDataContract filter)
        {
            return AppDomainService.GetAppDetail(filter, true);
        }

        public ScreenshotDataContract GetAppScreenshot(ScreenshotFilterDataContract filter)
        {
            return AppDomainService.GetAppScreenshot(filter);
        }

        public IEnumerable<AppDataContract> GetSpecialApps()
        {
            var filter = new AppFilterDataContract
            {
                AppType = AppType.Application,
                PageIndex = 0,
                PageSize =5
            };

            return AppDomainService.GetApps(filter);
        }

        public IEnumerable<AppDataContract> GetMostPopularApps()
        {
            var filter = new AppFilterDataContract
            {
                AppType = AppType.Application,
                PageIndex = 0,
                PageSize = 12
            };

            return AppDomainService.GetApps(filter);
        }

        public IEnumerable<AppDataContract> GetChosenApps()
        {
            var filter = new AppFilterDataContract
            {
                AppType = AppType.Application,
                PageIndex = 0,
                PageSize = 10
            };

            return AppDomainService.GetApps(filter);
        }

        public IEnumerable<AppDataContract> GetNewApps()
        {
            var filter = new AppFilterDataContract
            {
                AppType = AppType.Application,
                PageIndex = 0,
                PageSize = 6
            };

            return AppDomainService.GetApps(filter);
        }

        public IEnumerable<AppDataContract> GetSpecialGames()
        {
            var filter = new AppFilterDataContract
            {
                AppType = AppType.Application,
                PageIndex = 0,
                PageSize = 8
            };

            return AppDomainService.GetApps(filter);
        }

        public IEnumerable<AppDataContract> GetMostPopularGames()
        {
            var filter = new AppFilterDataContract
            {
                AppType = AppType.Application,
                PageIndex = 0,
                PageSize = 6
            };

            return AppDomainService.GetApps(filter);
        }

        public IEnumerable<AppDataContract> GetChosenGames()
        {
            var filter = new AppFilterDataContract
            {
                AppType = AppType.Application,
                PageIndex = 0,
                PageSize = 5
            };

            return AppDomainService.GetApps(filter);
        }

        public IEnumerable<AppDataContract> GetNewGames()
        {
            var filter = new AppFilterDataContract
            {
                AppType = AppType.Application,
                PageIndex = 0,
                PageSize = 5
            };

            return AppDomainService.GetApps(filter);
        }

        public byte[] GetAppIcon128(Guid guid)
        {
            return AppDomainService.GetAppIcon128(guid);
        }

        public byte[] GetAppIcon256(Guid guid)
        {
            return AppDomainService.GetAppIcon256(guid);
        }
    }
}
