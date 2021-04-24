using WindowsStore.Client.Developer.Logic.DeveloperService;
using AppCategory = WindowsStore.Client.Developer.Logic.Models.AppCategory;

namespace WindowsStore.Client.Developer.Logic.ModelMapping
{
    public static class AppCategoryMapper
    {
        public static AppCategoryDataContract ToAppCategoryDataContract(this AppCategory appCategory)
        {
            return new AppCategoryDataContract()
            {
                Id = appCategory.Id,
                Title = appCategory.Title,
                AppType = (AppType)appCategory.AppType
            };
        }

        public static AppCategory ToAppCategory(this AppCategoryDataContract appCategoryDataContract)
        {
            return new AppCategory()
            {
                Id = appCategoryDataContract.Id,
                Title = appCategoryDataContract.Title,
                AppType = appCategoryDataContract.AppType
            };
        }
    }
}
