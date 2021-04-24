using WindowsStore.Client.User.Common.Infrastructure;
using WindowsStore.Client.User.Common.PresentationModel;
using WindowsStore.Client.User.Service.UserService;

namespace WindowsStore.Client.User.Service.Remote.ModelMapping
{
    public static class AppQueryParametersMapper
    {
        public static AppFilterDataContract GetAppQueryParametersDC(this AppQueryParameters appQueryParams)
        {
            return new AppFilterDataContract()
            {
                AppCategoryId = appQueryParams.AppCategoryId,
                AppPricing = (WindowsStore.Client.User.Service.UserService.AppPricing?)appQueryParams.AppPricing,
                AppType = (WindowsStore.Client.User.Service.UserService.AppType?)appQueryParams.AppType,
                AppOrderMethod = (WindowsStore.Client.User.Service.UserService.AppOrderMethod?)appQueryParams.AppOrderMethod,
                PageIndex = appQueryParams.PageIndex,
                PageSize = appQueryParams.PageSize,
                Include128X128Icon = appQueryParams.Include128x128Icon,
                Include256X256Icon = appQueryParams.Include256x256Icon,
                AppId = appQueryParams.AppId,
                AppGuid = appQueryParams.AppGuid,
                FeaturedApp = appQueryParams.FeaturedApp
            };
        }
    }
}
