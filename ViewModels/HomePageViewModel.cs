using CommunityToolkit.Mvvm.ComponentModel;
using Grocery.Shared.Dtos;
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
        private readonly OfferService _offerService;
        private readonly ProductService _productService;

        public HomePageViewModel(CategoryService categoryService, OfferService offerService, ProductService productService )
        {
            _categoryService = categoryService;
            _offerService = offerService;
            _productService = productService;
        }

        public ObservableCollection<Category> Categories { get; set; } = new();
        public ObservableCollection<Offer> Offers  { get; set; } = new();

        public ObservableCollection<ProductDto> PopularProducts { get; set; } = new();


        [ObservableProperty]
        private bool _isBusy = true;

        public async Task InitializeAsync()
        {
            try
            {
                var listOffer = _offerService.GetActiveOfferAsync();
                var mainCategory = await _categoryService.GetMainCategoriesAsync();
                var popularProducts = await _productService.GetPopularProductAsync();
                foreach (var category in mainCategory)
                    Categories.Add(category);

                foreach (var offer in await listOffer)
                    Offers.Add(offer);

                foreach (var product in popularProducts)
                    PopularProducts.Add(product);
               
            }
            finally
            {
                IsBusy = false;
            }
            
        }
    }
}
