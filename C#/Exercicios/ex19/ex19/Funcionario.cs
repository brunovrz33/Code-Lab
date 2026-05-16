using System;
using System.Collections.Generic;
using System.Text;

namespace ex19
{
    internal class Funcionario
    {
        public int Cpf { get; private set; }
        public string Nome { get; private set; }
        public double Salario { get; private set; }

        public Funcionario(int cpf, string nome, double salario)
        {
            Cpf = cpf;
            Nome = nome;
            Salario = salario;
        }

        public void AumentarSalario(double percentual)
        {
            Salario += Salario * percentual / 100.0;
        }

        public override string ToString()
        {
            return $"{Cpf}, {Nome}, {Salario:F2}";
        }
    }
}
