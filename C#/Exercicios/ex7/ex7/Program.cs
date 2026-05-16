Console.WriteLine("Quantos números você quer digitar?");
int x = int.Parse(Console.ReadLine()!);

int soma = 0;

for (int i = 1; i <= x; i++)
{
    Console.WriteLine($"Digite o valor {i}:");
    int valor = int.Parse(Console.ReadLine()!);

    soma += valor;
}

Console.WriteLine("A soma dos valores é: " + soma);