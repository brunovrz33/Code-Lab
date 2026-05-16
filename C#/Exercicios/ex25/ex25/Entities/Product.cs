using System;
using System.Collections.Generic;
using System.Text;

namespace ex25.Entities
{
    abstract class Product
    {
        public string Name { get; set; } = string.Empty;
        public double Price { get; set; }
        public Product()
        {
        }
        public Product(string name, double price)
        {
            Name = name;
            Price = price;
        }
        public abstract string PriceTag();
    }
}