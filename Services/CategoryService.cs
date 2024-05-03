
using GroceryApp.Constants;
using GroceryApp.Models;
using System.Text.Json;

namespace GroceryApp.Services
{


    public class CategoryService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private IEnumerable<Category>? _categories;
        public CategoryService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async ValueTask<IEnumerable<Category>> GetCategoriesAsync() 
        {
            if (_categories is not null)
                return _categories;

            var httpClient = _httpClientFactory.CreateClient(AppConstants.HttpClientName);
            var response = await httpClient.GetAsync("/masters/categories");

            if (response.IsSuccessStatusCode)
            {
                var content  = await response.Content.ReadAsStringAsync();
                _categories = JsonSerializer.Deserialize<IEnumerable<Category>>(content, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
                return _categories;
            }
            
            return Enumerable.Empty<Category>();
        }

        public async ValueTask<IEnumerable<Category>> GetMainCategoriesAsync() => (await GetCategoriesAsync()).Where(x => x.ParentId == 0);
        

    }
}
