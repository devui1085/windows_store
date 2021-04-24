using Store.DataContract;
using Store.DomainModel.Entity;

namespace Store.DomainService.Mapper
{
    internal static class AppPlatformSpecificationDataContractMapper
    {
        public static App ToApp(this AppPlatformSpecificationDataContract appPlatformSpecification)
        {
            return new App()
            {
                Id = appPlatformSpecification.AppId,
                CpuArchitectureFlags = appPlatformSpecification.CpuArchitectureFlags
            };
        }

        public static AppPlatformSpecificationDataContract ToAppPlatformSpecificationDataContract(this App app)
        {
            var appPlatformSpecification = new AppPlatformSpecificationDataContract()
            {
                AppId = app.Id,
                CpuArchitectureFlags= app.CpuArchitectureFlags
            };
            return appPlatformSpecification;
        }
    }
}
