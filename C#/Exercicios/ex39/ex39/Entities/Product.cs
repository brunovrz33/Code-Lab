using System;
using System.Collections.Generic;
using System.Text;

namespace ex39.Entities
{
    class Product
    {
        public string? Name { get; set; }
        public int Id { get; set; }
        public double Price { get; set; }
        public Category? Category { get; set; } = null;

        public Product()
        {
        }
        public Product(string? name, int id, double price, Category? category = null)
        {
            Name = name;
            Id = id;
            Price = price;
            Category = category;
        }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Price: {Price}, Category: {Category?.Name}";
        }
    }
}
