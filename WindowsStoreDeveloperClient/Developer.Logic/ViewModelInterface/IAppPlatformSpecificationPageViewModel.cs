using WindowsStore.Client.Developer.Logic.DeveloperService;
using WindowsStore.Client.Developer.Logic.Models;

namespace WindowsStore.Client.Developer.Logic.ViewModelInterface
{
  public  interface IAppPlatformSpecificationPageViewModel
    {
       AppDetail AppDetail { get; set; }
      void AddPlatformToDectionary(string key,int value);
      void RemovePlatformFromDictionary(string key);

      void AddCpuArchitecture(CpuArchitecture cpuArchitecture);
      void RemoveCpuArchitecture(CpuArchitecture cpuArchitecture);
    }
}
