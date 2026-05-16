using System;
using System.Globalization;
using ex15;

Console.Write("Entre com o valor do raio: ");
double raio = double.Parse(Console.ReadLine()!, CultureInfo.InvariantCulture);

double c = Calculadora.Circunferencia(raio);
double v = Calculadora.Volume(raio);

Console.WriteLine("Circunferência: " + c.ToString("F2", CultureInfo.InvariantCulture));
Console.WriteLine("Volume: " + v.ToString("F2", CultureInfo.InvariantCulture));
Console.WriteLine("Valor de PI: " + Calculadora.Pi.ToString("F2", CultureInfo.InvariantCulture));