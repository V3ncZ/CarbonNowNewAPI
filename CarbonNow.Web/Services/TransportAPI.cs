using System.Net.Http.Json;
using CarbonNow.Web.Response;

namespace CarbonNow.Web.Services
{
    public class TransportAPI
    {

        private readonly HttpClient _httpClient;

        public TransportAPI(IHttpClientFactory factory)
        {
            _httpClient = factory.CreateClient("API");
        }

        public async Task<ICollection<TransportResponse>?> GetTransportAsync()
        {
            return await _httpClient.GetFromJsonAsync<ICollection<TransportResponse>>("Transport/ListAll");
        }
    }
}
