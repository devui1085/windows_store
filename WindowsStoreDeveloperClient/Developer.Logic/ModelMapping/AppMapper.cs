using System.Threading.Tasks;
using WindowsStore.Client.Developer.Logic.DeveloperService;
using App = WindowsStore.Client.Developer.Logic.Models.App;
using WindowsStore.Client.Developer.Common.ExtensionMethod;

namespace WindowsStore.Client.Developer.Logic.ModelMapping
{


    public static class AppMapper
    {
        public static AppDataContract ToAppDataContract(this App app)
        {
            return new AppDataContract()
            {

            };
        }

        public async static Task<App> ToAppAsync(this AppDataContract appDataContract)
        {
            return new App()
            {
                Id = appDataContract.Id,
                AppCategoryId = appDataContract.AppCategory.Id,
                Description = appDataContract.Description,
                IconBytes = await appDataContract.Icon128X128.AsBitmapImageAsync(),
                Name = appDataContract.Name,
                Title = appDataContract.Name,
            };
        }
    }
}
