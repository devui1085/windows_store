using WindowsStore.Client.User.Common.PresentationModel;
using WindowsStore.Client.User.Service.UserService;

namespace WindowsStore.Client.User.Service.Remote.ModelMapping
{
    public static class AppCategoryMapper
    {
        public static AppCategoryDataContract GetAppCategoryDC(this AppCategory appCategory)
        {
            return new AppCategoryDataContract()
            {
                Id = appCategory.Id,
                Title = appCategory.Title,
                AppType = (WindowsStore.Client.User.Service.UserService.AppType)appCategory.AppType
            };
        }

        public static AppCategory GetAppCategory(this AppCategoryDataContract appCategoryDataContract)
        {
            return new AppCategory()
            {
                Id = appCategoryDataContract.Id,
                Title = appCategoryDataContract.Title,
                AppType = (WindowsStore.Client.User.Common.Enum.AppType)appCategoryDataContract.AppType
            };
        }
    }
}
