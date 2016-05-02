using OfflineSync.Core.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OfflineSync.Core.Service.Interfaces
{
    public interface IBmsService
    {
        Task<IEnumerable<Banners>> GetBanners();
    }
}
