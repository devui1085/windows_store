using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using WindowsStore.Client.User.Common.Enum;

namespace WindowsStore.Client.User.Common.Infrastructure
{
    public class AppQueryParameters : QueryParametersBase
    {
        public int? AppId { get; set; }
        public Guid? AppGuid { get; set; }
        public AppType? AppType { set; get; }
        public AppPricing? AppPricing { set; get; }
        public int? AppCategoryId { set; get; }
        public AppOrderMethod? AppOrderMethod { set; get; }
        public bool? FeaturedApp { get; set; }
        public bool Include128x128Icon { get; set; }
        public bool Include256x256Icon { get; set; }

        public static AppQueryParameters TopFreeApplications(
            int pageIndex = 0, int pageSize = 2, bool include128x128Icon = true, bool include256x256Icon = false)
        {
            return new AppQueryParameters()
            {
                AppType = Enum.AppType.Application,
                AppPricing = Enum.AppPricing.FreeApp,
                AppOrderMethod = Enum.AppOrderMethod.Top,
                PageIndex = pageIndex,
                PageSize = pageSize,
                Include128x128Icon = include128x128Icon,
                Include256x256Icon = include256x256Icon
            };
        }

        public static AppQueryParameters TopApplications(
            int pageIndex = 0, int pageSize = 2, bool include128x128Icon = true, bool include256x256Icon = false)
        {
            return new AppQueryParameters()
            {
                AppType = Enum.AppType.Application,
                AppOrderMethod = Enum.AppOrderMethod.Top,
                PageIndex = pageIndex,
                PageSize = pageSize,
                Include128x128Icon = include128x128Icon,
                Include256x256Icon = include256x256Icon
            };
        }

        public static AppQueryParameters TopFreeGames(int pageIndex = 0, int pageSize = 2, bool include128x128Icon = true, bool include256x256Icon = false)
        {
            return new AppQueryParameters()
            {
                AppOrderMethod = Enum.AppOrderMethod.Top,
                AppPricing = Enum.AppPricing.FreeApp,
                AppType = Enum.AppType.Game,
                PageIndex = pageIndex,
                PageSize = pageSize,
                Include128x128Icon = include128x128Icon,
                Include256x256Icon = include256x256Icon
            };
        }

        public static AppQueryParameters TopGames(
            int pageIndex = 0, int pageSize = 2, bool include128x128Icon = true, bool include256x256Icon = false)
        {
            return new AppQueryParameters()
            {
                AppOrderMethod = Enum.AppOrderMethod.Top,
                AppType = Enum.AppType.Game,
                PageIndex = pageIndex,
                PageSize = pageSize,
                Include128x128Icon = include128x128Icon,
                Include256x256Icon = include256x256Icon
            };
        }

        public static AppQueryParameters RandomApps(int pageSize = 2, bool include128x128Icon = true, bool include256x256Icon = false)
        {
            return new AppQueryParameters()
            {
                Include128x128Icon = include128x128Icon,
                Include256x256Icon = include256x256Icon,
                PageSize = pageSize,
            };
        }

        public static AppQueryParameters FeaturedApps()
        {
            return new AppQueryParameters()
            {
                FeaturedApp = true,
                Include128x128Icon = false,
                Include256x256Icon = false,
                PageSize = 10,
                PageIndex = 0
            };
        }


    }
}
