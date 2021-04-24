using System.Threading.Tasks;
using WindowsStore.Client.Developer.Logic.DeveloperService;
using WindowsStore.Client.Developer.Logic.Models;

namespace WindowsStore.Client.Developer.Logic.ModelMapping
{
    public static class AppDetailMapper
    {
        public static AppDetailDataContract ToAppDetailDataContract(this AppDetail appDetail)
        {
            return new AppDetailDataContract()
            {

            };
        }

        public async static Task<AppDetail> ToAppDetailAsync(this AppDetailDataContract appDetailDataContract)
        {
            return new AppDetail()
            {
                AppSpecification=appDetailDataContract.AppSpecificationDataContract.ToAppSpecification(),
                AppPlatformSpecification=appDetailDataContract.AppPlatformSpecificationDataContract.ToAppPlatformSpecification(),
                AppIcon =await appDetailDataContract.AppIconDataContract.ToAppIconAsync(),
                AppVersionSpecification = appDetailDataContract.AppVersionDataContract.ToAppVersion()
           };
        }
    }
}
