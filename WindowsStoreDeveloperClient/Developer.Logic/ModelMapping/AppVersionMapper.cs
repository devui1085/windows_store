using WindowsStore.Client.Developer.Logic.DeveloperService;
using WindowsStore.Client.Developer.Logic.Models;

namespace WindowsStore.Client.Developer.Logic.ModelMapping
{
    public static class AppVersionMapper
    {
        public static AppVersionDataContract ToAppVersionDataContract(this AppVersion appVersion)
        {
            return new AppVersionDataContract()
            {
                Id= appVersion.Id ,
                AppId = appVersion.AppId,
                Description = appVersion.Description,
                PublishDate = appVersion.PublishDate,
                Version = appVersion.Version,
                Size = appVersion.Size,
                ArmPackageSize =appVersion.ArmPackageSize,
                X64PackageSize =appVersion.X64PackageSize,
                X86PackageSize =appVersion.X86PackageSize
            };
            
        }

        public  static AppVersion ToAppVersion(this AppVersionDataContract appVersionDataContract)
        {
            if (appVersionDataContract == null) return null;

            return new AppVersion()
            {
                Id = appVersionDataContract.Id,
                AppId = appVersionDataContract.AppId,
                Description = appVersionDataContract.Description,
                Version = appVersionDataContract.Version,
                PublishDate = appVersionDataContract.PublishDate,
                Downloads = appVersionDataContract.Downloads,
                CpuArchitectureFlags = appVersionDataContract.CpuArchitectureFlags,
                //ArmPackageSize = appVersionDataContract.ArmPackageSize,
                //X64PackageSize = appVersionDataContract.X64PackageSize,
                //X86PackageSize = appVersionDataContract.X86PackageSize
            };
        }
    }
}
