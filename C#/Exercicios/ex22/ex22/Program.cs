using System;
using System.Globalization;
using ex22.entities;
using ex22.enums;

Console.Write("Enter department's name: ");
string deptName = Console.ReadLine()!;
Console.Write("Name: ");
string name = Console.ReadLine()!;
Console.Write("Level (Junior/MidLevel/Senior): ");
WorkLevel level  = Enum.Parse<WorkLevel>(Console.ReadLine()!);
Console.Write("Base salary: ");
double baseSalary = double.Parse(Console.ReadLine()!, CultureInfo.InvariantCulture);

Departament departament = new Departament(deptName);
Worker worker = new Worker(name, level, baseSalary, departament);

Console.Write("How many contracts to this worker? ");
int n = int.Parse(Console.ReadLine()!);

for (int i = 1;  i <= n; i++)
{
    Console.WriteLine($"Enter #{i} contract data:");
    Console.Write("Date (DD/MM/YYYY): ");
    DateTime date = DateTime.Parse(Console.ReadLine()!);
    Console.Write("Value per hour: ");
    double valuePerHour = double.Parse(Console.ReadLine()!, CultureInfo.InvariantCulture);
    Console.Write("Duration (hours): ");
    double hours = double.Parse(Console.ReadLine()!, CultureInfo.InvariantCulture);
    HourContract contract = new HourContract(date, valuePerHour, hours);
    worker.addContract(contract);
}
Console.WriteLine();
Console.Write("Enter month and year to calculate income (MM/YYYY): ");
string monthAndYear = Console.ReadLine()!;
int month = int.Parse(monthAndYear.Substring(0, 2));
int year = int.Parse(monthAndYear.Substring(3));
Console.WriteLine("Name: " + worker.Name);
Console.WriteLine("Departament: " + worker.Departament.Name);
Console.WriteLine("Income for " + monthAndYear + ": " + worker.income(year, month).ToString("F2", CultureInfo.InvariantCulture));
