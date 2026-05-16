Console.WriteLine("Entre com seu nome completo:");
string nome = Console.ReadLine()!;

Console.WriteLine("Quantos quartos tem na sua casa?");
int quartos = int.Parse(Console.ReadLine()!);

Console.WriteLine("Entre com o preço de um produto:");
double preco = double.Parse(Console.ReadLine()!);

Console.WriteLine("Entre com seu último nome, idade e alutra (mesma linha):");
string[] v = Console.ReadLine()!.Split(' ');

string ultimoNome = v[0];
int idade = int.Parse(v[1]);
double altura = double.Parse(v[2]);

Console.WriteLine(nome);
Console.WriteLine(quartos);
Console.WriteLine(preco.ToString("F2"));
Console.WriteLine(ultimoNome);
Console.WriteLine(idade);
Console.WriteLine(altura);