using WindowsStore.Client.Developer.Logic.Models;

namespace WindowsStore.Client.Developer.Logic.ViewModelInterface
{
    public interface ICredentialUserControlViewModel
    {
        UserCredential UserCredential { get;  }

        bool ValidateForm();
    }
}
