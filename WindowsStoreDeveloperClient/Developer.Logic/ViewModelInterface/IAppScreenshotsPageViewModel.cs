using WindowsStore.Client.Developer.Logic.Models;
using WindowsStore.Client.Developer.Logic.ServiceInterface;
using Prism.Windows.AppModel;

namespace WindowsStore.Client.Developer.Logic.ViewModelInterface
{
    public interface IAppScreenshotsPageViewModel
    {
        AppDetail AppDetail { get; set; }

        void AddScreenshot(AppScreenshot screenshot);
        IAlertMessageService GetAlertMessageService();
        IResourceLoader GetResourceLoader();
    }
}
