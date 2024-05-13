using Grocery.Shared.Dtos;

namespace GroceryApp.Controls;

public partial class ProductListControl : ContentView
{
	public static readonly BindableProperty ProductsProperty = 
		BindableProperty.Create(nameof(Products),typeof(IEnumerable<ProductDto>),typeof(ProductListControl),Enumerable.Empty<ProductDto>());

	public ProductListControl()
	{
		InitializeComponent();
	}

    public IEnumerable<ProductDto> Products 
	{
		get => (IEnumerable<ProductDto>)GetValue(ProductsProperty);  
		set => SetValue(ProductsProperty, value);
	}
}