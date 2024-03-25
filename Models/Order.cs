using Grocery.Shared.Enumerations;

namespace GroceryApp.Models
{
    public class Order
    {
        public int Id { get; set; }
        public IEnumerable<CartItem> Items { get; set; } = Enumerable.Empty<CartItem>();
        public DateTime Date { get; set; } = DateTime.Now;
        public decimal TotalAmount => Items.Sum(x => x.Amount);
        public OrderStatus Status { get; set; } = OrderStatus.Placed;
        public Color Color => _orderStatuscolorsMap[Status];
        private static readonly IReadOnlyDictionary<OrderStatus, Color> _orderStatuscolorsMap =
            new Dictionary<OrderStatus, Color>
            {
                [OrderStatus.Placed] = Colors.Yellow,
                [OrderStatus.Confirmed] = Colors.Blue,
                [OrderStatus.Deliverd] = Colors.Green,
                [OrderStatus.Cancelled] = Colors.Red,
            }; 
    }

}
