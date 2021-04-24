using WindowsStore.Client.Developer.Logic.DeveloperService;
using AppPlatformSpecification = WindowsStore.Client.Developer.Logic.Models.AppPlatformSpecification;

namespace WindowsStore.Client.Developer.Logic.ModelMapping
{
    public static class AppPlatformSpecificationPlatformSpecificationMAppPlatformSpecificationer
    {
        public static AppPlatformSpecificationDataContract ToAppPlatformSpecificationDataContract(
            this AppPlatformSpecification appPlatformSpecification)
        {
            return new AppPlatformSpecificationDataContract()
            {
                AppId = appPlatformSpecification.AppId,
                CpuArchitectureFlags = appPlatformSpecification.CpuArchitectureFlags,
                PlatformCategories =
                    new System.Collections.ObjectModel.ObservableCollection<int>(
                        appPlatformSpecification.PlatformCategories)
            };
        }

        public static AppPlatformSpecification ToAppPlatformSpecification(
            this AppPlatformSpecificationDataContract appPlatformSpecificationDataContract)
        {
            return new AppPlatformSpecification()
            {
                AppId = appPlatformSpecificationDataContract.AppId,
                CpuArchitectureFlags = appPlatformSpecificationDataContract.CpuArchitectureFlags,
                PlatformCategories = appPlatformSpecificationDataContract.PlatformCategories
            };
        }
    }
}