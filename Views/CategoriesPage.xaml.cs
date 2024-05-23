using GroceryApp.Models;
using GroceryApp.Services;
using System.Collections.ObjectModel;

namespace GroceryApp.Views;

public partial class CategoriesPage : ContentPage
{
    private readonly CategoryService _categoryService;

    public CategoriesPage(CategoryService categoryService)
	{
		InitializeComponent();
        _categoryService = categoryService;
        BindingContext = this;
    }

	public ObservableCollection<Category> Categories { get; set; } = new();


    protected override async void OnAppearing()
    {
        base.OnAppearing();
        Categories.Clear();
        foreach (var category in await _categoryService.GetCategoriesAsync())
        {
            Categories.Add(category);

        }
    }
}