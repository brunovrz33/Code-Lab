using System;
using System.Collections.Generic;
using System.Text;

namespace ex26.Entities
{
    class Taxpayer
    {
        public string? Name { get; set; }
        public double AnnualIncome { get; set; }
        public virtual double CalculateTax() => 0;
    }
}
