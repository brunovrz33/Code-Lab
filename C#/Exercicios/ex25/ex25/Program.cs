using System;
using System.Collections.Generic;
using System.Globalization;
using ex25.Entities;

Console.Write("Enter the number of products: ");
int n = int.Parse(Console.ReadLine()!);

List<Product> products = new List<Product>();

for (int i = 1; i <= n; i++)
{
    Console.WriteLine($"Product #{i} data: ");
    Console.Write("Common, used or imported (c/u/i)? ");
    char type = char.Parse(Console.ReadLine()!);
    if (type == 'c')
    {
        Console.Write("Name: ");
        string name = Console.ReadLine()!;
        Console.Write("Price: ");
        double price = double.Parse(Console.ReadLine()!, CultureInfo.InvariantCulture);
        Product prod = new CommonProduct(name, price);
        products.Add(prod);
    }
    else if (type == 'u')
    {
        Console.Write("Name: ");
        string name = Console.ReadLine()!;
        Console.Write("Price: ");
        double price = double.Parse(Console.ReadLine()!, CultureInfo.InvariantCulture);
        Console.Write("Manufacture date (DD/MM/YYYY): ");
        DateTime manufactureDate = DateTime.Parse(Console.ReadLine()!);
        Product prod = new UsedProduct(name, price, manufactureDate);
        products.Add(prod);
    }
    else
    {
        Console.Write("Name: ");
        string name = Console.ReadLine()!;
        Console.Write("Price: ");
        double price = double.Parse(Console.ReadLine()!, CultureInfo.InvariantCulture);
        Console.Write("Customs fee: ");
        double customsFee = double.Parse(Console.ReadLine()!, CultureInfo.InvariantCulture);
        Product prod = new importedProduct(name, price, customsFee);
        products.Add(prod);
    }
}

Console.WriteLine();
Console.WriteLine("PRICE TAGS:");
foreach (Product prod in products)
{
    Console.WriteLine(prod.PriceTag());
}