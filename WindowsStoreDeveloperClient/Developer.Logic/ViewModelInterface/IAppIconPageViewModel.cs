using WindowsStore.Client.Developer.Logic.Models;

namespace WindowsStore.Client.Developer.Logic.ViewModelInterface
{
    public interface IAppIconPageViewModel
    {
        AppDetail AppDetail { get; set; }

        void ShowImageSizeError();
    }
}
