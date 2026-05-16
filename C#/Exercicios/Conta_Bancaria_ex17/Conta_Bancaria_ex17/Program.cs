using System.Globalization;
using System;
using System.Collections.Generic;
using Conta_Bancaria_ex17;

Console.WriteLine("===CONTA BANCÁRIA===");

Console.Write("\nEntre com o número da conta:");
int numeroConta = int.Parse(Console.ReadLine()!);
Console.Write("\nEntre com o titular da conta:");
string nomeTitular = Console.ReadLine()!;
Console.Write("Haverá depósito inicial (s/n) ?");
char resposta = Console.ReadLine()!.Trim().ToLower()[0];

Banco conta;

if (resposta == 's')
{
    Console.Write("\nEntre com o valor do depósito inicial:");
    double depositoInicial = double.Parse(Console.ReadLine()!, CultureInfo.InvariantCulture);
    conta = new(numeroConta, nomeTitular, depositoInicial);

    Console.WriteLine("\nDados da conta:");
    Console.WriteLine(conta);
}
else
{
    conta = new(numeroConta, nomeTitular);
}
Console.Write("Entre com um valor para depósito: ");
double valorDeposito = double.Parse(Console.ReadLine()!, CultureInfo.InvariantCulture);
conta.deposito(valorDeposito);

Console.WriteLine("\nDados da conta atualizados:");
Console.WriteLine(conta);

Console.Write("Entre com um valor para saque:");
double valorSaque = double.Parse(Console.ReadLine()!, CultureInfo.InvariantCulture);
conta.saque(valorSaque);

Console.WriteLine("\nDados da conta atualizados:");
Console.WriteLine(conta);