using System;
using System.Collections.Generic;
using System.Text;

namespace ex25.Entities
{
    class importedProduct: Product
    {
        public double customsFee { get; set; }
        
        public importedProduct()
        {
        }

        public importedProduct(string name, double price, double customsFee) : base(name, price)
        {
            this.customsFee = customsFee;
        }
        public double totalPrice()
        {
            return Price + customsFee;
        }
        public override string PriceTag()
        {
            return Name + " $ " + (Price + customsFee).ToString("F2") + " (Customs fee: $ " + customsFee.ToString("F2") + ")";
        }
    }
}
