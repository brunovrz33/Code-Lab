Console.WriteLine("Qual é a sua idade?");
int idade = int.Parse(Console.ReadLine()!);

if (idade >= 0 && idade <= 12)
{
    Console.WriteLine("Você ainda é criança.");
}
else if (idade >= 13 && idade <= 17)
{
    Console.WriteLine("Você é Adolescente.");
}
else if (idade >= 18 && idade <= 59)
{
    Console.WriteLine("Você já é Adulto!");
}
else
{
    Console.WriteLine("Idade inválida");
}