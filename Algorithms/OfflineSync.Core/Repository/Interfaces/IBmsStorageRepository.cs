using OfflineSync.Core.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OfflineSync.Core.Repository.Interfaces
{
    public interface IBmsStorageRepository : IBmsRepository
    {
        Task<IEnumerable<Banners>> SaveBanners<T>(IEnumerable<Banners> Banners) where T : class;
    }
}
