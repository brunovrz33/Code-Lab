using System.Globalization;
using ex19;

Console.Write("Quantos funcionários serão cadastrados? ");
int n = int.Parse(Console.ReadLine()!);

List<Funcionario> lista = new List<Funcionario>();

for (int i = 1; i <= n; i++)
{
    Console.WriteLine($"\nDados do {i}º funcionário:");

    Console.Write("CPF: ");
    int cpf = int.Parse(Console.ReadLine()!);

    while (lista.Exists(f => f.Cpf == cpf))
    {
        Console.Write("CPF já existente! Digite outro: ");
        cpf = int.Parse(Console.ReadLine()!);
    }

    Console.Write("Nome: ");
    string nome = Console.ReadLine()!;

    Console.Write("Salário: ");
    double salario = double.Parse(Console.ReadLine()!, CultureInfo.InvariantCulture);

    lista.Add(new Funcionario(cpf, nome, salario));
}

Console.Write("\nDigite o CPF do funcionário que terá aumento: ");
int cpfBusca = int.Parse(Console.ReadLine()!);

Funcionario? func = lista.Find(f => f.Cpf == cpfBusca);

if (func != null)
{
    Console.Write("Digite a porcentagem de aumento: ");
    double porcentagem = double.Parse(Console.ReadLine()!, CultureInfo.InvariantCulture);
    func.AumentarSalario(porcentagem);
}
else
{
    Console.WriteLine("CPF INEXISTENTE");
}

Console.WriteLine("\nListagem atualizada de funcionários:");
foreach (Funcionario f in lista)
{
    Console.WriteLine(f);
}