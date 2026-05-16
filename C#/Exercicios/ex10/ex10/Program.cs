using System.Net.Http.Headers;

Console.WriteLine("===SISTEMA DE SALARIO====");
Console.WriteLine("Dados do primeiro funcionário:");

Console.Write("Nome: ");
string nome1 = Console.ReadLine()!;
Console.Write("Salário:");
double salario1 = double.Parse(Console.ReadLine()!);

Console.WriteLine("Dados da segunda pessoa:");

Console.Write("Nome: ");
string nome2 = Console.ReadLine()!;
Console.Write("Salário:");
double salario2 = double.Parse(Console.ReadLine()!);

double media = (salario1 + salario2) / 2;
Console.WriteLine("A média salarial dos dois funcionários é de:" + media);