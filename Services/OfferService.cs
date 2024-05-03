using GroceryApp.Constants;
using GroceryApp.Models;
using System.Text.Json;

namespace GroceryApp.Services
{
    public class OfferService 
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private IEnumerable<Offer>? _offers;
        public OfferService(IHttpClientFactory httpClientFactory) 
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IEnumerable<Offer>> GetActiveOfferAsync()
        {
            if (_offers is not null)
                return _offers;

            var httpClient = _httpClientFactory.CreateClient(AppConstants.HttpClientName);
            var response = await httpClient.GetAsync("/masters/offers");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                _offers = JsonSerializer.Deserialize<IEnumerable<Offer>>(content, new JsonSerializerOptions 
                {
                    PropertyNameCaseInsensitive = true
                });
                return _offers;
            }

            return Enumerable.Empty<Offer>();
        }
    }
}
