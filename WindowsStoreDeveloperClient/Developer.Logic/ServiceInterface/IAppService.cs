using System.Collections.Generic;
using System.Threading.Tasks;
using WindowsStore.Client.Developer.Logic.Models;

namespace WindowsStore.Client.Developer.Logic.ServiceInterface
{
    public interface IAppService
    {
        Task<IEnumerable<Task<AppDetail>>> GetDeveloperAppsAsync();

        bool UpdateAppInfo(AppInfo appInfo);
    }
}
