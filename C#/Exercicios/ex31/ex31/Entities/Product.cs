using System;
using System.Collections.Generic;
using System.Text;

namespace ex31.Entities
{
    using System;

    namespace ex31.Entities
    {
        class Product : IComparable<Product>
        {
            public string Name { get; set; }
            public double Price { get; set; }

            public Product(string name, double price)
            {
                Name = name;
                Price = price;
            }

            public int CompareTo(Product? other)
            {
                if (other == null) return 1;    
                return this.Price.CompareTo(other.Price);
            }

            public override string ToString()
            {
                return $"{Name}, {Price:F2}";
            }
        }
    }
    }