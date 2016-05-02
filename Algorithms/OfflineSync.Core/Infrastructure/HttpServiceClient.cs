using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace OfflineSync.Core.Infrastructure
{
    public class HttpServiceClient : IHttpService
    {
        private HttpClient _client;

        public HttpServiceClient()
        {
            _client = new HttpClient();
        }

        public async Task<T> Get<T>(string address)
        {
            var response = await _client.GetAsync(address);
            var responseString = await response.Content.ReadAsStringAsync();
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(responseString);
        }
    }
}
