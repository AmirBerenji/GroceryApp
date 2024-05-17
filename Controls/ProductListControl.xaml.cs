using CommunityToolkit.Mvvm.Input;
using Grocery.Shared.Dtos;

namespace GroceryApp.Controls;

public class ProductCartItemChangeEventArgs : EventArgs
{
    public int ProductId { get; set; }
    public int Count { get; set; }

    public ProductCartItemChangeEventArgs(int productId, int count)
    {
        ProductId = productId;
        Count = count;
    }
}

public partial class ProductListControl : ContentView
{
	public static readonly BindableProperty ProductsProperty = 
		BindableProperty.Create(nameof(Products),typeof(IEnumerable<ProductDto>),typeof(ProductListControl),Enumerable.Empty<ProductDto>());

	public ProductListControl()
	{
		InitializeComponent(); 
	}

	public event EventHandler<ProductCartItemChangeEventArgs> AddRemoveCartClick;

    public IEnumerable<ProductDto> Products 
	{
		get => (IEnumerable<ProductDto>)GetValue(ProductsProperty);  
		set => SetValue(ProductsProperty, value);
	}

	[RelayCommand]
	private void AddToCart(int productId) => AddRemoveCartClick?.Invoke(this, new ProductCartItemChangeEventArgs(productId, 1));

	[RelayCommand]
	private void RemoveFromCard(int productId) => AddRemoveCartClick?.Invoke(this, new ProductCartItemChangeEventArgs(productId, -1));


}