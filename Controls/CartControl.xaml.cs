namespace GroceryApp.Controls;

public partial class CartControl : ContentView
{
    public static readonly BindableProperty CountProperty = BindableProperty.Create(nameof(Count), typeof(int), typeof(CartControl), 0,propertyChanged:OnCountChanged);

    public CartControl()
    {
        InitializeComponent();
    }
    public int Count
    {
        get => (int)GetValue(CountProperty);
        set => SetValue(CountProperty, value);
    }

    private static void OnCountChanged(BindableObject bindable, object oldValue, object newValue)
    {
        int oldCount = (int)oldValue; 
        int newCount = (int)newValue;
        if (oldCount != newCount) 
        {
            if (newCount < 1)
            {

            }
            else if (oldCount < 1 && newCount > 1)
            {

            }
            else
            {
                
            }
            
        }
    }
}