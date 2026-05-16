using System;
using ex27.Entities;
using System.Globalization;
using System.Collections.Generic;

try
{
    Console.WriteLine("Enter account data:");
    Console.Write("Number: ");
    int integer = int.Parse(Console.ReadLine()!);
    Console.Write("Holder: ");
    string holder = Console.ReadLine()!;
    Console.Write("Initial balance: ");
    double balance = double.Parse(Console.ReadLine()!, CultureInfo.InvariantCulture);
    Console.Write("Withdraw limit: ");
    double withdrawLimit = double.Parse(Console.ReadLine()!, CultureInfo.InvariantCulture);

    Account account = new Account(integer, holder, balance, withdrawLimit);

    Console.WriteLine();
    Console.Write("Enter amount for withdraw: ");
    double amount = double.Parse(Console.ReadLine()!, CultureInfo.InvariantCulture);
    account.Withdraw(amount);
    Console.WriteLine($"New balance: {account.Balance.ToString("F2", CultureInfo.InvariantCulture)}");

}
catch (DomainException e)
{
    Console.WriteLine($"Withdraw error: {e.Message}");
}
catch (FormatException e)
{
    Console.WriteLine($"Format error: {e.Message}");
}
catch (Exception e)
{
    Console.WriteLine($"Unexpected error: {e.Message}");
}