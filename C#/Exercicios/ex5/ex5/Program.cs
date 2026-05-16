var senha = 1234;
int Tentativa;

do {
    Console.WriteLine("\nDigite a senha:");
    Tentativa = int.Parse(Console.ReadLine()!);
    if (senha != Tentativa)
        Console.WriteLine("Senha incorreta, tente novamente");
} while (senha != Tentativa);
Console.WriteLine("Acesso Aprovado!");