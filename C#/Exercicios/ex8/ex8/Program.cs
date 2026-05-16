Console.WriteLine("=== TABUADA ===");
Console.Write("Digite um número: ");
int x = int.Parse(Console.ReadLine()!);

Console.WriteLine();

for (int i = 1; i <= 10; i++)
{
    int resultado = x * i;
    Console.WriteLine($"{x} x {i} = {resultado}");
}