using System.Collections.Generic;
using OfflineSync.Core.Model;
using OfflineSync.Core.Repository.Interfaces;
using OfflineSync.Core.Infrastructure;
using System.Threading.Tasks;

namespace OfflineSync.Core.Repository.SqliteRepository
{
    public class BmsSqlRepository : IBmsStorageRepository
    {
        private readonly ISqliteConnetion _connection;

        public BmsSqlRepository(ISqliteConnetion connection)
        {
            _connection = connection;
        }

        public async Task<IEnumerable<Banners>> GetBanners()
        {
            return await _connection.Get<Banners>();
        }

        public async Task<IEnumerable<Banners>> SaveBanners<T>(IEnumerable<Banners> banners) where T : class
        {
            return await _connection.SaveAll(banners);
        }
    }
}
