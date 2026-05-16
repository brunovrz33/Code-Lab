using System.Globalization;
using ex16;

Console.Write("Qual é a cotação do dólar? ");
double cotacao = double.Parse(Console.ReadLine()!, CultureInfo.InvariantCulture);

Console.Write("Quantos dólares você vai comprar? ");
double dolares = double.Parse(Console.ReadLine()!, CultureInfo.InvariantCulture);

double total = ConversorDeMoeda.Converter(cotacao, dolares);

Console.WriteLine($"Valor a ser pago em reais = {total.ToString("F2", CultureInfo.InvariantCulture)}");