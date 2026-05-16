using System;
using System.Collections.Generic;
using System.Text;

namespace ex22.entities
{
    class HourContract
    {
        public DateTime date { get; set; }
        public double valuePerHour { get; set; }
        public double hours { get; set; }

        public HourContract()
        {
        }
        public HourContract(DateTime date, double valuePerHour, double hours)
        {
            this.date = date;
            this.valuePerHour = valuePerHour;
            this.hours = hours;
        }
        public double totalValue()
        {
            return valuePerHour * hours;
        }
    }
}