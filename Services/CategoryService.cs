using GroceryApp.Models;

namespace GroceryApp.Services
{


    public class CategoryService : BaseApiService
    {
        
        private IEnumerable<Category>? _categories;
        public CategoryService(IHttpClientFactory httpClientFactory) : base(httpClientFactory)
        {}
        public async ValueTask<IEnumerable<Category>> GetCategoriesAsync() 
        {
            if (_categories is not null)
                return _categories;

            var response = await HttpClient.GetAsync("/masters/categories");

            var categories = await HandleApiResponseAsync<IEnumerable<Category>>(response, null);
            
            if (categories is null)
                return Enumerable.Empty<Category>();
            
            _categories = categories;
            return _categories;
        }

        public async ValueTask<IEnumerable<Category>> GetMainCategoriesAsync() => (await GetCategoriesAsync()).Where(x => x.ParentId == 0);
        

    }
}
