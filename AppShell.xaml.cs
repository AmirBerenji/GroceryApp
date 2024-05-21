using GroceryApp.Views;

namespace GroceryApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(CartPage),typeof(CartPage));
        }
    }
}
