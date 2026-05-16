using System.Globalization;
using ex14;

Aluno a = new Aluno();

Console.Write("Nome: ");
a.Nome = Console.ReadLine()!;

Console.WriteLine("Digite as três notas do aluno:");
a.Nota1 = double.Parse(Console.ReadLine()!, CultureInfo.InvariantCulture);
a.Nota2 = double.Parse(Console.ReadLine()!, CultureInfo.InvariantCulture);
a.Nota3 = double.Parse(Console.ReadLine()!, CultureInfo.InvariantCulture);

Console.WriteLine($"NOTA FINAL = {a.CalcularNotaFinal().ToString("F2", CultureInfo.InvariantCulture)}");
Console.WriteLine(a.VerificarAprovacao());

if (a.CalcularNotaFinal() < 60.0)
{
    Console.WriteLine($"FALTARAM {a.PontosFaltando().ToString("F2", CultureInfo.InvariantCulture)} PONTOS");
}