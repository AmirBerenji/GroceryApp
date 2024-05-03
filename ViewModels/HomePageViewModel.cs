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
        private readonly OfferService _offerService;

        public HomePageViewModel(CategoryService categoryService, OfferService offerService)
        {
            _categoryService = categoryService;
            _offerService = offerService;
        }

        public ObservableCollection<Category> Categories { get; set; } = new();
        public ObservableCollection<Offer> Offers  { get; set; } = new();

        public async Task InitializeAsync()
        {
            var listOffer = _offerService.GetActiveOfferAsync();
            var mainCategory  = await _categoryService.GetMainCategoriesAsync();
            foreach (var category in mainCategory) 
                Categories.Add(category);

            foreach (var offer in await listOffer)
                Offers.Add(offer);
            
        }
    }
}
