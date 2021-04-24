using System.Threading.Tasks;
using WindowsStore.Client.Developer.Logic.DeveloperService;
using WindowsStore.Client.Developer.Common.ExtensionMethod;
using WindowsStore.Client.Developer.Logic.Models;

namespace WindowsStore.Client.Developer.Logic.ModelMapping
{
    public static class AppIconMapper
    {
        public async static Task<AppIconDataContract> ToAppIconDataContract(this AppIcon appIcon)
        {
            return new AppIconDataContract()
            {
                AppId = appIcon.AppId,
                Icon128X128 = null,  // this set on the server by resize Icon256X256
                Icon256X256 = await appIcon.Icon256X256StorageFile.AsByteArrayAsync(),
            };
        }

        public async static Task<AppIcon> ToAppIconAsync(this AppIconDataContract appIconDataContract)
        {
            return new AppIcon()
            {
                AppId = appIconDataContract.AppId,
                Icon128X128 = await appIconDataContract.Icon128X128.AsBitmapImageAsync(),
                Icon256X256 = await appIconDataContract.Icon256X256.AsBitmapImageAsync()
            };
        }
    }

}
