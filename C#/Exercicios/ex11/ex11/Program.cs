using ex11;
using System.Globalization;
Console.WriteLine("Entre com as medidas do triângulo X:");

Triangulo x, y;

x = new Triangulo();
y = new Triangulo();

 x.A = double.Parse(Console.ReadLine()!, CultureInfo.InvariantCulture);
x.B = double.Parse(Console.ReadLine()!, CultureInfo.InvariantCulture);
 x.C = double.Parse(Console.ReadLine()!, CultureInfo.InvariantCulture);

Console.WriteLine("Entre com as medidas do triângulo Y:");

 y.A = double.Parse(Console.ReadLine()!, CultureInfo.InvariantCulture);
 y.B = double.Parse(Console.ReadLine()!, CultureInfo.InvariantCulture);
y.C = double.Parse(Console.ReadLine()!, CultureInfo.InvariantCulture);

double areaX = x.area();
double areaY = y.area();

Console.WriteLine("Área de X:" + areaX.ToString("F4", CultureInfo.InvariantCulture));
Console.WriteLine("Área de Y:" + areaY.ToString("F4", CultureInfo.InvariantCulture));

if (areaX > areaY)
{
    Console.WriteLine("Área de X é maior.");
}
else
{
    Console.WriteLine("Área de Y é maior.");
}