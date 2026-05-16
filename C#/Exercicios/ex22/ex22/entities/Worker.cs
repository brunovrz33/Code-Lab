using System;
using System.Collections.Generic;
using System.Text;
using ex22.enums;

namespace ex22.entities
{
    class Worker
    {
        public string Name { get; set; }
        public WorkLevel Level { get; set; }
        public double baseSalary { get; set; }
        public Departament Departament { get; set; }

        public Worker()
        {
        }

        public Worker(string name, WorkLevel level, double baseSalary, Departament departament)
        {
            this.Name = name;
            this.Level = level;
            this.baseSalary = baseSalary;
            this.Departament = departament;
        }

        public List<HourContract> Contracts { get; set; } = new List<HourContract>();
        public void addContract(HourContract contract)
        {
            Contracts.Add(contract);
        }
        public void removeContract(HourContract contract)
        {
            Contracts.Remove(contract);
        }
        public double income(int year, int month)
        {
            double sum = baseSalary;
            foreach (HourContract contract in Contracts)
            {
                if (contract.date.Year == year && contract.date.Month == month)
                {
                    sum += contract.totalValue();
                }
            }
            return sum;
        }
    }
}
