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

        public async ValueTask<IEnumerable<Category>> GetMainCategoriesAsync() => 
                (await GetCategoriesAsync()).Where(x => x.ParentId == 0);

        public async Task<IEnumerable<Category>> GetSubOrSiblingCategoriesAsync(int categoryId)
        {
            var allCategories = await GetCategoriesAsync();
            var thisCategory = allCategories.First(c => c.Id == categoryId);

            var mainCategoryId = thisCategory.IsMainCategory ? categoryId : thisCategory.ParentId;

            return allCategories.Where(x => x.ParentId == mainCategoryId).ToList();

        }
    }
}
