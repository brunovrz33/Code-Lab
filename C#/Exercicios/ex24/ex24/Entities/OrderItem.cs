using System;
using System.Collections.Generic;
using System.Text;

namespace ex24.Entities
{
    class OrderItem
    {
        public double Price { get; set; }
        public int Quantity { get; set; }
        public Product? Product { get; set; }

        public OrderItem()
        {
        }
        public OrderItem(double price, int quantity)
        {
            Price = price;
            Quantity = quantity;
        }
        public OrderItem(double price, int quantity, Product product)
        {
            Price = price;
            Quantity = quantity;
            Product = product;
        }
        public double SubTotal()
        {
            return Price * Quantity;
        }
        public override string ToString()
        {
            return (Product?.Name ?? "Unknown")
                + ", $"
                + Price.ToString("F2")
                + ", Quantity: "
                + Quantity
                + ", Subtotal: $"
                + SubTotal().ToString("F2");
        }
    }
}
