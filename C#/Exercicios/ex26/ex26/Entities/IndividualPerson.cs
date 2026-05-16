using System;
using System.Collections.Generic;
using System.Text;

namespace ex26.Entities
{
    class IndividualPerson : Taxpayer
    {
        public double HealthExpenses { get; set; }

        public override double CalculateTax()
        {
            double tax = AnnualIncome < 20000 ? AnnualIncome * 0.15 : AnnualIncome * 0.25;
            tax -= HealthExpenses * 0.50;
            return Math.Max(tax, 0);
        }
    }
}
