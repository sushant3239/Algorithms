using OfflineSync.Core.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OfflineSync.Core.Repository.Interfaces
{
    public interface IBmsRepository
    {
        Task<IEnumerable<Banners>> GetBanners();
    }
}
