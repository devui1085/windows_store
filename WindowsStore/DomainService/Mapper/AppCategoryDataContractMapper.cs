using Store.DataContract;
using Store.DomainModel.Entity;

namespace Store.DomainService.Mapper
{
    internal static class AppCategoryDataContractMapper
    {
        public static AppCategory ToAppCategory(this AppCategoryDataContract appCategoryDataContract)
        {
            return new AppCategory()
            {
                Id= appCategoryDataContract.Id,
                Title= appCategoryDataContract.Title,
                AppType= appCategoryDataContract.AppType,
            };
        }

        public static AppCategoryDataContract ToAppCategoryDataContract(this AppCategory app)
        {
            return new AppCategoryDataContract()
            {
                Id = app.Id,
                Title = app.Title,
                AppType= app.AppType
            };
        }
    }
}
