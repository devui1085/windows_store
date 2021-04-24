using WindowsStore.Client.Developer.Logic.Models;
using WindowsStore.Client.Developer.Logic.ServiceInterface;
using Prism.Windows.AppModel;

namespace WindowsStore.Client.Developer.Logic.ViewModelInterface
{
    public interface IAppVersionSpecificationPageViewModel
    {
        AppDetail AppDetail { get; set; }
        AppVersion AppVersion { get; set; }
        bool IsX64PackageMandatory { get; }
        bool IsX86PackageMandatory { get; }
        bool IsArmPackageMandatory { get; }
        void SaveAppVersionSpecificationAsync(bool updateCurrentVersion);
        bool VersionFormIsValid();
        IAlertMessageService GetAlertMessageService();
        IResourceLoader GetResourceLoader();
        bool PageIsOnUpdateState();
        bool NewVersionIsEqualOrLessThanCurrentVersion();
    }
}
