using System.Globalization;

var produto1 ="Computador";
var produto2 ="Mesa de escritorio";

byte idade = 30;
int codigo = 5290;
char genero = 'M';

double preco1 = 2100.0;
double preco2 = 650.0;
double medida = 53.234567;

Console.WriteLine("Produtos:\n");
Console.WriteLine($"{produto1}, cujo preço é ${preco1:F2}");
Console.WriteLine($"{produto2}, cujo preço é ${preco2:F2}\n");

Console.WriteLine($"Registro: {idade} anos de idade, código {codigo} e gênero: {genero}\n");

Console.WriteLine($"Medida com oito casas decimais: {medida}");
Console.WriteLine($"Arredondado (três casas decimais): {medida.ToString("F3")}");
Console.WriteLine($"Separador decimal invariant culture: {medida.ToString("F3", CultureInfo.InvariantCulture)}");