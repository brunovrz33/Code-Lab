using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using employee_salary_filter.Entities;
class Program
{
    static void Main(string[] args)
    {
        Console.Write("Enter full file path: ");
        string filePath = Console.ReadLine()!;

        if (!File.Exists(filePath))
        {
            Console.WriteLine("File not found.");
            return;
        }

        List<Employee> employees = new List<Employee>();

        string[] lines = File.ReadAllLines(filePath);
        foreach (string line in lines)
        {
            string[] parts = line.Split(',');
            if (parts.Length == 3)
            {
                string? name = parts[0].Trim();
                string? email = parts[1].Trim();
                if (double.TryParse(parts[2].Trim(), System.Globalization.NumberStyles.Any,
                    System.Globalization.CultureInfo.InvariantCulture, out double salary))
                {
                    employees.Add(new Employee(name, email, salary));
                }
            }
        }

        Console.Write("Enter salary: ");
        if (!double.TryParse(Console.ReadLine(), System.Globalization.NumberStyles.Any,
            System.Globalization.CultureInfo.InvariantCulture, out double minSalary))
        {
            Console.WriteLine("Invalid value.");
            return;
        }

        // Emails dos funcionários com salário superior ao valor informado, em ordem alfabética
        Console.WriteLine($"Email of people whose salary is more than {minSalary:F2}:");
        var filteredEmails = employees
            .Where(e => e.Email != null && e.Salary > minSalary)
            .OrderBy(e => e.Email)
            .Select(e => e.Email!);

        foreach (string email in filteredEmails)
        {
            Console.WriteLine(email);
        }

        // Soma dos salários dos funcionários cujo nome começa com 'M'
        double sumSalaryM = employees
            .Where(e => e.Name != null && e.Name.StartsWith("M", StringComparison.OrdinalIgnoreCase))
            .Sum(e => e.Salary);

        Console.WriteLine($"Sum of salary of people whose name starts with 'M': {sumSalaryM:F2}");
    }
}