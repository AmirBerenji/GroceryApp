namespace Grocery.Api.Data.Entities
{
    public class OrderItem
    {
        public Guid Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public  decimal Quantity { get; set; }
        public decimal Amount { get; set; }

        public Product Product { get; set; }
        public virtual Order Order { get; set; }
    }
}
