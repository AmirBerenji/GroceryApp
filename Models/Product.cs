﻿namespace GroceryApp.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public int CartQuantity { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
    
}
