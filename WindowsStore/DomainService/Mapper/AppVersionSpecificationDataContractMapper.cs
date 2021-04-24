using Store.DataContract;
using Store.DomainModel.Entity;

namespace Store.DomainService.Mapper
{
    internal static class AppVersionSpecificationDataContractMapper
    {
        public static AppVersion ToVersionApp(this AppVersionSpecificationDataContract appVersionSpecification)
        {
            return new AppVersion()
            {  
                AppId = appVersionSpecification.AppId,
                Description = appVersionSpecification.Description,
                Version= appVersionSpecification.Version,
                PublishDate = appVersionSpecification.PublishDate
            };
        }

        public static AppVersionSpecificationDataContract ToAppSpecificationDataContract(this AppVersion appVersion)
        {
            return new AppVersionSpecificationDataContract()
            {
                AppId= appVersion.AppId,
                Description =appVersion.Description,
                PublishDate =appVersion.PublishDate,
                Version =appVersion.Version
            };
        }
    }
}
