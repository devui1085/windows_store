using Store.DataContract;
using Store.DomainModel.Entity;
using System;
using Store.Common.Enum;

namespace Store.DomainService.Mapper
{
    internal static class AppVersionDataContractMapper
    {
        public static AppVersion ToAppVersion(this AppVersionDataContract dataContract)
        {
            return new AppVersion()
            {
                Id = dataContract.Id,
                Description = dataContract.Description,
                AppId = dataContract.AppId,
                PublishDate = DateTime.Now,
                Version = dataContract.Version,
                Size = dataContract.Size,
                ArmPackageSize = dataContract.ArmPackageSize,
                X64PackageSize = dataContract.X64PackageSize,
                X86PackageSize = dataContract.X86PackageSize,
                
            };
        }

        public static AppVersionDataContract ToAppVersionDataContract(this AppVersion model)
        {
            return new AppVersionDataContract()
            {
                Id = model.Id,
                Description = model.Description,
                AppId = model.AppId,
                Downloads = model.Downloads,
                PublishDate = model.PublishDate,
                Version = model.Version,
                Size = model.Size,
                ArmPackageSize = model.ArmPackageSize,
                X64PackageSize = model.X64PackageSize,
                X86PackageSize = model.X86PackageSize
            };
        }
    }
}
