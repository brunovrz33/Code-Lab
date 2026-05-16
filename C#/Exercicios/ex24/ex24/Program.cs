using System;
using System.Collections.Generic;
using System.Globalization;
using ex24.Entities;
using ex24.Enum;

Console.WriteLine("Enter CLient Date: ");
Console.Write("Name: ");
string name = Console.ReadLine()!;
Console.Write("Email: ");
string email = Console.ReadLine()!;
Console.Write("Birth date (DD/MM/YYYY): ");
DateTime birthDate = DateTime.ParseExact(Console.ReadLine()!, "dd/MM/yyyy", CultureInfo.InvariantCulture);
Console.WriteLine("Enter order date: ");
Console.Write("Status: ");
string status = Console.ReadLine()!;
Console.Write("How many items to this order? ");
int n = int.Parse(Console.ReadLine()!);

OrderStatus orderStatus = Enum.Parse<OrderStatus>(status, true);
Order order = new Order(DateTime.Now, orderStatus, new Client(name, email, birthDate));

for  (int i = 1;  i <= n; i++)
{
    Console.WriteLine($"Enter #{i} item data: ");
    Console.Write("Product name: ");
    string productName = Console.ReadLine()!;
    Console.Write("Product price: ");
    double productPrice = double.Parse(Console.ReadLine()!, CultureInfo.InvariantCulture);
    Console.Write("Quantity: ");
    int quantity = int.Parse(Console.ReadLine()!);
    Product product = new Product(productName, productPrice);
    OrderItem orderItem = new OrderItem(productPrice, quantity, product);
    order.AddItem(orderItem);
}

Console.WriteLine();
Console.WriteLine("ORDER SUMMARY:");
Console.WriteLine(order);