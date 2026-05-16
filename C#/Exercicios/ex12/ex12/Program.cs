using ex12;
using System.Globalization;

Retangulo p = new Retangulo();

Console.WriteLine("Entre a largura e altura do retângulo:");

p.Largura = double.Parse(Console.ReadLine()!, CultureInfo.InvariantCulture);
p.Altura = double.Parse(Console.ReadLine()!, CultureInfo.InvariantCulture);

double perimetro = 2 * (p.Largura + p.Altura);
double diagonal = Math.Sqrt(Math.Pow(p.Largura, 2.0) + Math.Pow(p.Altura, 2.0));

Console.WriteLine("AREA = " + p.Area());
Console.WriteLine("PERIMETRO = " + p.Perimetro());
Console.WriteLine("DIAGONAL = " + p.Diagonal());