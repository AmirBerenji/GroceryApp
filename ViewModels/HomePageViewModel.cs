using CommunityToolkit.Mvvm.ComponentModel;
using GroceryApp.Models;
using GroceryApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroceryApp.ViewModels
{
    public partial class HomePageViewModel : ObservableObject
    {
        private readonly CategoryService _categoryService;
        public HomePageViewModel(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public ObservableCollection<Category> Categories { get; set; } = new();

        public async Task InitializeAsync()
        {
            var mainCategory  = await _categoryService.GetMainCategoriesAsync();
            foreach (var category in mainCategory) 
                Categories.Add(category);
            
        }
    }
}
