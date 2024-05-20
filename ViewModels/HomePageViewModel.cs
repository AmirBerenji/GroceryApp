using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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
        private readonly CartViewModel _cartViewModel;

        public HomePageViewModel(CategoryService categoryService, OfferService offerService, ProductService productService,CartViewModel cartViewModel )
        {
            _categoryService = categoryService;
            _offerService = offerService;
            _productService = productService;
            _cartViewModel = cartViewModel;
        }

        public ObservableCollection<Category> Categories { get; set; } = new();
        public ObservableCollection<Offer> Offers  { get; set; } = new();

        public ObservableCollection<ProductDto> PopularProducts { get; set; } = new();


        [ObservableProperty]
        private bool _isBusy = true;

        [ObservableProperty]
        private int _cartCount;

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

        [RelayCommand]
        private void AddToCart(int productId) => UpdateCart(productId, 1);
        
        [RelayCommand]
        private void RemoveFromCart(int productId) => UpdateCart(productId, -1);


        private void UpdateCart(int productId,int count)
        {
            var product = PopularProducts.FirstOrDefault(x => x.Id == productId);
            if (product is not null)
            {
                product.CartQuantity += count;

                if (count == -1)
                {
                    //We are remove from Cart
                    _cartViewModel.RemoveFromCartCommand.Execute(product.Id);
                }
                else
                {
                    //Adding Cart
                    _cartViewModel.AddToCartCommand.Execute(product);
                }

                CartCount = _cartViewModel.Count;
            }
        }
    }
}
