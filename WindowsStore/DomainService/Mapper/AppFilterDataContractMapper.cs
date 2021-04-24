using Store.DataContract;
using Store.DomainModel.EntityFilter;

namespace Store.DomainService.Mapper
{
    internal static class AppFilterDataContractMapper
    {
        public static AppFilter ToAppFilter(this AppFilterDataContract appFilterDataContract)
        {
            return new AppFilter()
            {
                AppCategoryId = appFilterDataContract.AppCategoryId,
                AppPricing = appFilterDataContract.AppPricing,
                AppType = appFilterDataContract.AppType,
                AppOrderMethod = appFilterDataContract.AppOrderMethod,
                PageIndex = appFilterDataContract.PageIndex,
                PageSize = appFilterDataContract.PageSize,
                Include128X128Icon = appFilterDataContract.Include128X128Icon,
                Include256X256Icon = appFilterDataContract.Include256X256Icon,
                AppId = appFilterDataContract.AppId,
                AppGuid = appFilterDataContract.AppGuid,
                FeaturedApp = appFilterDataContract.FeaturedApp
            };
        }
    }
}
