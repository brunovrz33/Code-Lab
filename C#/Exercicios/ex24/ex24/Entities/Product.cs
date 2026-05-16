using System;
using System.Collections.Generic;
using System.Text;

namespace ex24.Entities
{
    class Product
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
    }
}
