using Store.DataContract;
using Store.DomainModel.Entity;

namespace Store.DomainService.Mapper
{
    internal static class AppSpecificationDataContractMapper
    {
        public static App ToApp(this AppSpecificationDataContract appSpecification)
        {
            return new App()
            {
                Id = appSpecification.AppId,
                Guid = appSpecification.Guid,
                Name = appSpecification.Name,
                Description = appSpecification.Description,
                Price = appSpecification.Price,
                AppCategoryId =appSpecification.CategoryId     
            };
        }

        public static AppSpecificationDataContract ToAppSpecificationDataContract(this App app)
        {
            var appSpecification = new AppSpecificationDataContract()
            {
                AppId = app.Id,
                Guid = app.Guid,
                Name = app.Name,
                Description = app.Description,
                Price = app.Price,
                CategoryId = app.AppCategoryId,
            };
            return appSpecification;
        }
    }
}
