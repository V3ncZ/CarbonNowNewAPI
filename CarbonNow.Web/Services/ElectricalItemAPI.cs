using System.Net.Http;
using System.Net.Http.Json;
using CarbonNow.Web.Response;

namespace CarbonNow.Web.Services
{
    public class ElectricalItemAPI
    {

        private readonly HttpClient _httpClient;

        public ElectricalItemAPI(IHttpClientFactory factory)
        {
            _httpClient = factory.CreateClient("API");
        }

        public async Task<ICollection<ElectricalItemResponse>?> GetElectricalItemAsync()
        {
            return await _httpClient.GetFromJsonAsync<ICollection<ElectricalItemResponse>>("electricalItem");
        }

    }
}
