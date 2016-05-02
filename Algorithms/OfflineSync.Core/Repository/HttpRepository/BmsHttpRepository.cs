using System.Collections.Generic;
using OfflineSync.Core.Model;
using OfflineSync.Core.Repository.Interfaces;
using OfflineSync.Core.Infrastructure;
using System.Threading.Tasks;

namespace OfflineSync.Core.Repository.HttpRepository
{
    public class BmsHttpRepository : IBmsRepository
    {
        private readonly IHttpService _client;

        public BmsHttpRepository(IHttpService client)
        {
            _client = client;
        }

        public async Task<IEnumerable<Banners>> GetBanners()
        {
            var address = @"http://data-in.bookmyshow.com/getToken2.bms?f=json&ac=MOBWIN10&fl=|UDID=b846efae31e1933ff46582043345d84f|PUSHTOKEN=|FL=MOBAPP_IOSAND3|DEVICE=System manufacturer|&av=24&sv=0&pt=WIN";
            var response = await _client.Get<RootResponse>(address);
            var banners = response.BookMyShow.AdDetails[0].arrOfferBanners;
            return banners;
        }
    }
}
