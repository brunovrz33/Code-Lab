using System;
using System.Collections.Generic;
using System.Text;

namespace ex26.Entities
{
 class LegalEntity : Taxpayer
    {
        public int NumEmployees { get; set; }
        public override double CalculateTax()
        {
            double rate = NumEmployees > 10 ? 0.14 : 0.16;
            return AnnualIncome * rate;
        }
    }
}
