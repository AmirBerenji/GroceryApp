using Grocery.Shared.Enumerations;

namespace Grocery.Api.Data.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public decimal TotalAmount { get; set; }
        public OrderStatus Status { get; set; } = OrderStatus.Placed;

        public ICollection<OrderItem> OrderItems { get; set; }

    }
}
