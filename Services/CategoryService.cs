using GroceryApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryApp.Services
{
    public class CategoryService
    {
        private IEnumerable<Category>? _categories;
        public async ValueTask<IEnumerable<Category>> GetCategoriesAsync() 
        {
            if (_categories is not null)
                return _categories;

            var categories = new List<Category>();
            var fruits = new List<Category> 
            {
                new (1, "Fruits",0,"fruits.png","Photo by <a href= \"https://images.unsplash.com/photo-1519996529931-28324d5a630e?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mnx8RnJ1aXRzfGVufDB8fDB8fHww\"></a>"),
                new (2, "seasonal Fruits",1,"seasonal_fruits.png","Photo by <a href= \"https://images.unsplash.com/photo-1519996529931-28324d5a630e?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mnx8RnJ1aXRzfGVufDB8fDB8fHww\"></a>"),
                new (3, "Exotic Fruits",1,"exotic_fruits.png","Photo by <a href= \"https://images.unsplash.com/photo-1519996529931-28324d5a630e?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mnx8RnJ1aXRzfGVufDB8fDB8fHww\"></a>")
            };
            categories.AddRange(fruits);

            var vegetables = new List<Category>
            {
                new (4, "Vegetables",0,"vegetables.png","Photo by <a href= \"https://images.unsplash.com/photo-1519996529931-28324d5a630e?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mnx8RnJ1aXRzfGVufDB8fDB8fHww\"></a>"),
                new (5, "Green Vegetables",4,"green_vegetables.png","Photo by <a href= \"https://images.unsplash.com/photo-1519996529931-28324d5a630e?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mnx8RnJ1aXRzfGVufDB8fDB8fHww\"></a>"),
                new (6, "Leafy Vegetables",4,"leafy_vegetables.png","Photo by <a href= \"https://images.unsplash.com/photo-1519996529931-28324d5a630e?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mnx8RnJ1aXRzfGVufDB8fDB8fHww\"></a>"),
                new (7, "Salads",4,"Salads.png","Photo by <a href= \"https://images.unsplash.com/photo-1519996529931-28324d5a630e?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mnx8RnJ1aXRzfGVufDB8fDB8fHww\"></a>")
            };
            categories.AddRange(vegetables);

            var dairy = new List<Category>
            {
                new (8, "Dairy",0,"dairy.png","Photo by <a href= \"https://images.unsplash.com/photo-1519996529931-28324d5a630e?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mnx8RnJ1aXRzfGVufDB8fDB8fHww\"></a>"),
                new (9, "Milk, Curd & Yogurts",8,"milk_curd_yogurt.png","Photo by <a href= \"https://images.unsplash.com/photo-1519996529931-28324d5a630e?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mnx8RnJ1aXRzfGVufDB8fDB8fHww\"></a>"),
                new (10, "Butter & Cheese",8,"butter_cheese.png","Photo by <a href= \"https://images.unsplash.com/photo-1519996529931-28324d5a630e?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mnx8RnJ1aXRzfGVufDB8fDB8fHww\"></a>"),
            };
            categories.AddRange(dairy);

            var eggsMeat = new List<Category>
            {
                new (11, "Eggs & Meat",0,"eggs_meat.png","Photo by <a href= \"https://images.unsplash.com/photo-1519996529931-28324d5a630e?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mnx8RnJ1aXRzfGVufDB8fDB8fHww\"></a>"),
                new (12, "Eggs",11,"eggs.png","Photo by <a href= \"https://images.unsplash.com/photo-1519996529931-28324d5a630e?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mnx8RnJ1aXRzfGVufDB8fDB8fHww\"></a>"),
                new (13, "Meat",11,"meat.png","Photo by <a href= \"https://images.unsplash.com/photo-1519996529931-28324d5a630e?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mnx8RnJ1aXRzfGVufDB8fDB8fHww\"></a>"),
                new (14, "Seafood",11,"seafood.png","Photo by <a href= \"https://images.unsplash.com/photo-1519996529931-28324d5a630e?w=500&auto=format&fit=crop&q=60&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxzZWFyY2h8Mnx8RnJ1aXRzfGVufDB8fDB8fHww\"></a>"),
            };
            categories.AddRange(eggsMeat);

            _categories = categories;


            return _categories;
        }

        public async ValueTask<IEnumerable<Category>> GetMainCategoriesAsync() => (await GetCategoriesAsync()).Where(x => x.ParentId == 0);
        

    }
}
