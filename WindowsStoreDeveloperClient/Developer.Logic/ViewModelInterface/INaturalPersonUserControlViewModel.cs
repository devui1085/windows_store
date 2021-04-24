using System.Threading.Tasks;
using WindowsStore.Client.Developer.Logic.Models;

namespace WindowsStore.Client.Developer.Logic.ViewModelInterface
{
    public interface INaturalPersonUserControlViewModel
    {
        NaturalPerson NaturalPerson { get; }
        string Password { get; set; }

        Task ProcessFormAsync();

        bool ValidateForm();

    }
}
