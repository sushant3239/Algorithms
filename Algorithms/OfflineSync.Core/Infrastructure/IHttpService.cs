using System.Threading.Tasks;

namespace OfflineSync.Core.Infrastructure
{
    public interface IHttpService
    {
        Task<T> Get<T>(string address);
    }
}
