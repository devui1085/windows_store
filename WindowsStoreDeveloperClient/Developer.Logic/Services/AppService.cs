using System.Collections.Generic;
using System.Threading.Tasks;
using WindowsStore.Client.Developer.Logic.Models;
using WindowsStore.Client.Developer.Logic.ServiceInterface;

namespace WindowsStore.Client.Developer.Logic.Services
{
    public class AppService :IAppService
    {
        private readonly IClientDeveloperService _developerService;
        public AppService(IClientDeveloperService developerService)
        {
            _developerService = developerService;
        }

        public async Task<IEnumerable<Task<AppDetail>>> GetDeveloperAppsAsync()
        {
            var result = await _developerService.GetDeveloperAppsAsync();
            return result;
        }

        public  bool UpdateAppInfo(AppInfo appInfo)
        {
            throw new System.NotImplementedException();
        }
    }
}
