using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter contract data");

        Console.Write("Number: ");
        int number = int.Parse(Console.ReadLine()!);

        Console.Write("Date (dd/MM/yyyy): ");
        DateTime contractDate = DateTime.ParseExact(Console.ReadLine()!, "dd/MM/yyyy", CultureInfo.InvariantCulture);

        Console.Write("Contract value: ");
        double contractValue = double.Parse(Console.ReadLine()!, CultureInfo.InvariantCulture);

        Console.Write("Enter number of installments: ");
        int installments = int.Parse(Console.ReadLine()!);

        double installmentBase = contractValue / installments;

        Console.WriteLine("Installments:");

        for (int i = 1; i <= installments; i++)
        {
            DateTime dueDate = contractDate.AddMonths(i);
            double withInterest = installmentBase * (1.0 + 0.01 * i);
            double withFee = withInterest * 1.02;
            Console.WriteLine($"{dueDate:dd/MM/yyyy} - {withFee:F2}");
        }
    }
}