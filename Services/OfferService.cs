using GroceryApp.Models;

namespace GroceryApp.Services
{
    public class OfferService : BaseApiService
    {
        public OfferService(IHttpClientFactory httpClientFactory) : base(httpClientFactory) 
        {
        }

        public async Task<IEnumerable<Offer>> GetActiveOfferAsync()
        {
            var response = await HttpClient.GetAsync("/masters/offers");
            return  await HandleApiResponseAsync(response, Enumerable.Empty<Offer>());
        }
    }
}
