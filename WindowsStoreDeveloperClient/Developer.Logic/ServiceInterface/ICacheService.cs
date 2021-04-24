using System.Threading.Tasks;

namespace WindowsStore.Client.Developer.Logic.ServiceInterface
{
    public interface ICacheService
    {
        Task<T> GetDataAsync<T>(string cacheKey);

        Task SaveDataAsync<T>(string cacheKey, T content);
    }
}
