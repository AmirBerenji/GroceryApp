using GroceryApp.Models;

namespace GroceryApp.Services
{
    public class ProductService : BaseApiService 
    {
        public ProductService(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {
        }
        public async Task<IEnumerable<Product>> GetPopularProductAsync()
        {
            var response = await HttpClient.GetAsync("/popular-products");
            return await HandleApiResponseAsync(response, Enumerable.Empty<Product>());
        }
    }
}
