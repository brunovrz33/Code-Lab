Console.WriteLine("\n---Sistema Escolar---");
Console.WriteLine("Quais foram as suas notas esse Trimestre?");

double nota1 = double.Parse(Console.ReadLine()!);
double nota2 = double.Parse(Console.ReadLine()!);
double nota3 = double.Parse(Console.ReadLine()!);
double nota4 = double.Parse(Console.ReadLine()!);

var media = (nota1 + nota2 + nota3 + nota4) / 4;

if (media >= 7)
{
    Console.WriteLine("Aluno Aprovado!");
    Console.WriteLine($"Sua média foi {media}. ");
}
else if (media <7 && media >= 4)
{
    Console.WriteLine("Aluno de Recuperação!");
    Console.WriteLine($"Sua média foi {media}. ");
}
else
{
    Console.WriteLine("Aluno Reprovado!");
    Console.WriteLine($"Sua média foi {media}. ");
}