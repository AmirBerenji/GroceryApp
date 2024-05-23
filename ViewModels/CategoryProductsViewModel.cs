using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Grocery.Shared.Dtos;
using GroceryApp.Models;
using GroceryApp.Services;
using System.Collections.ObjectModel;

namespace GroceryApp.ViewModels
{
    [QueryProperty(nameof(SelectedCategory), nameof(SelectedCategory))]
    public partial class CategoryProductsViewModel : ObservableObject
    {


        private readonly CategoryService _categoryService;
        private readonly ProductService _productService;
        private readonly CartViewModel _cartViewModel;

        public CategoryProductsViewModel(CategoryService categoryService, ProductService productService, CartViewModel cartViewModel)
        {
            _categoryService = categoryService;
            _productService = productService;
            _cartViewModel = cartViewModel;


            _cartViewModel.CartCountUpdated += CartViewModel_CartCountUpdated;
            _cartViewModel.CartItemUpdated += CartViewModel_CartItemUpdated;
            _cartViewModel.CartItemRemoved += CartViewModel_CartItemRemoved;
        }

        [ObservableProperty, NotifyPropertyChangedFor(nameof(PageTitle))]
        private Category _selectedCategory;

        public string PageTitle => $"{SelectedCategory?.Name ?? "Category"} Products";

        public ObservableCollection<Category> Categories { get; set; } = new();        
        public ObservableCollection<ProductDto> Products { get; set; } = new();

        [ObservableProperty]
        private bool _isBusy = true;

        [ObservableProperty]
        private int _cartCount;

        public async Task InnitializeAsync()
        {
            IsBusy = true;
            try
            {
                Categories.Clear();
                foreach (var category in await _categoryService.GetSubOrSiblingCategoriesAsync(SelectedCategory.Id)
                {
                    Categories.Add(category);   
                }

                Products.Clear();
                foreach (var product in await _productService.GetCategoryProductAsync(SelectedCategory.Id))
                {
                    Products.Add(product);
                }


            }
            finally
            {

                IsBusy = false;
            }
        }

        private void CartViewModel_CartItemRemoved(object? sender, int productId) => ModifyProductQuantity(productId, 0);
        private void CartViewModel_CartItemUpdated(object? sender, CartItem e) => ModifyProductQuantity(e.ProductId, e.Quantity);
        private void ModifyProductQuantity(int productId, int quantity)
        {
            var product = Products.FirstOrDefault(x => x.Id == productId);
            if (product is not null)
            {
                product.CartQuantity = quantity;
            }
        }
        private void CartViewModel_CartCountUpdated(object? sender, int cartCount) => CartCount = cartCount;



        [RelayCommand]
        private void AddToCart(int productId) => UpdateCart(productId, 1);

        [RelayCommand]
        private void RemoveFromCart(int productId) => UpdateCart(productId, -1);


        private void UpdateCart(int productId, int count)
        {
            var product = Products.FirstOrDefault(x => x.Id == productId);
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

        public void Dispose()
        {

            _cartViewModel.CartCountUpdated -= CartViewModel_CartCountUpdated;
            _cartViewModel.CartItemUpdated -= CartViewModel_CartItemUpdated;
            _cartViewModel.CartItemRemoved -= CartViewModel_CartItemRemoved;
        }
    }
}
