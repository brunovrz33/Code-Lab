using System;
using System.Collections.Generic;
using System.Globalization;
using ex26.Entities;

namespace ex26
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Taxpayer> taxpayers = new List<Taxpayer>();

            Console.Write("Enter the number of taxpayers: ");
            int n = int.Parse(Console.ReadLine()!);
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Taxpayer #{i} data:");
                Console.Write("Individual or legal entity (i/l)? ");
                char type = char.Parse(Console.ReadLine()!.ToLower());
                Console.Write("Name: ");
                string name = Console.ReadLine()!;
                Console.Write("Annual income: ");
                double annualIncome = double.Parse(Console.ReadLine()!, CultureInfo.InvariantCulture);
                if (type == 'i')
                {
                    Console.Write("Health expenditures: ");
                    double healthExpenses = double.Parse(Console.ReadLine()!, CultureInfo.InvariantCulture);
                    taxpayers.Add(new IndividualPerson { Name = name, AnnualIncome = annualIncome, HealthExpenses = healthExpenses });
                }
                else
                {
                    Console.Write("Number of employees: ");
                    int numEmployees = int.Parse(Console.ReadLine()!);
                    taxpayers.Add(new LegalEntity { Name = name, AnnualIncome = annualIncome, NumEmployees = numEmployees });
                }
            }
            Console.WriteLine("\nTAXES PAID:");
            foreach (var taxpayer in taxpayers)
            {
                Console.WriteLine($"{taxpayer.Name}: $ {taxpayer.CalculateTax().ToString("F2", CultureInfo.InvariantCulture)}");
            }

            Console.WriteLine();

            double totalTaxes = 0;
            foreach (var taxpayer in taxpayers)
            {
                totalTaxes += taxpayer.CalculateTax();
            }
            Console.WriteLine($"TOTAL TAXES: $ {totalTaxes.ToString("F2", CultureInfo.InvariantCulture)}");
        }
    }
}