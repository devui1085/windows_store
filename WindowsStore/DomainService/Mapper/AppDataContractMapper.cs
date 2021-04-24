using Store.Common.Enum;
using Store.DataContract;
using Store.DomainModel.Entity;
using System.Linq;

namespace Store.DomainService.Mapper
{
    internal static class AppDataContractMapper
    {
        public static App ToApp(this AppDataContract appDataContract)
        {
            return new App()
            {
                Id = appDataContract.Id,
                Guid = appDataContract.Guid,
                Name = appDataContract.Name,
                Description = appDataContract.Description,
                DeveloperId = appDataContract.DeveloperId,
                Icon128X128 = appDataContract.Icon128X128
            };
        }

        public static AppDataContract ToAppDataContract(this App app)
        {
            var dataContract = new AppDataContract()
            {
                Id = app.Id,
                Guid = app.Guid,
                Description = app.Description,
                Icon128X128 = app.Icon128X128,
                Name = app.Name,
                DeveloperId = app.DeveloperId,
                AppCategory = app.AppCategory?.ToAppCategoryDataContract(),
                NumberOfMobileScreenshots = app.Screenshots.Where(ss => ss.Type == ScreenshotType.Mobile).Count() 
            };

            if (app.Developer is NaturalPerson)
                dataContract.DeveloperName = (app.Developer as NaturalPerson).FullName;
            if (app.Developer is LegalPerson)
                dataContract.DeveloperName = (app.Developer as LegalPerson).Name;
            return dataContract;
        }
    }
}
