using System;
using System.Collections.Generic;
using System.Text;

namespace ex25.Entities
{
    class CommonProduct : Product
    {
        public CommonProduct()
        {
        }

        public CommonProduct(string name, double price) : base(name, price)
        {
        }

        public override string PriceTag()
        {
            return Name + " $ " + Price.ToString("F2");
        }
    }
}
