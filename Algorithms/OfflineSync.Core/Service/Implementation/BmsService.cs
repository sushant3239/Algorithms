using System.Collections.Generic;
using OfflineSync.Core.Model;
using OfflineSync.Core.Service.Interfaces;
using OfflineSync.Core.Infrastructure;
using OfflineSync.Core.Repository.Interfaces;
using System.Threading.Tasks;

namespace OfflineSync.Core.Service.Implementation
{
    public class BmsService : IBmsService
    {
        private readonly IBmsRepository _bmsRepository;
        private readonly IBmsStorageRepository _bmsStorageRepository;
        private readonly INetworkProfile _networkProfile;

        public BmsService(INetworkProfile networkProfile
            , IBmsRepository bmsRepository
            , IBmsStorageRepository bmsStorageRepository)
        {
            _networkProfile = networkProfile;
            _bmsRepository = bmsRepository;
            _bmsStorageRepository = bmsStorageRepository;
        }

        public async Task<IEnumerable<Banners>> GetBanners()
        {
            if (_networkProfile.HasAccessToNetwork)
            {
                var banners = await _bmsRepository.GetBanners();
                return await _bmsStorageRepository.SaveBanners<Banners>(banners);
            }
            return await _bmsStorageRepository.GetBanners();
        }
    }
}
