using System.Collections.Generic;
using System.Threading.Tasks;
using WindowsStore.Client.Developer.Logic.Services;

namespace WindowsStore.Client.Developer.Logic.ServiceInterface
{
    public interface IAlertMessageService
    {
        Task ShowAsync(string message, string title);

        Task ShowAsync(string message, string title, IEnumerable<DialogCommand> dialogCommands);

        Task ShowAsync(string message, string title, params DialogCommand[] dialogCommands);
    }
}
