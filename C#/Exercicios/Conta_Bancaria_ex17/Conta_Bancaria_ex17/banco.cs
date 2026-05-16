using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Conta_Bancaria_ex17
{
    class Banco
    {
        public int numeroConta { get; private set; }
        public string nomeTitular { get; set; }
        public double saldo { get; private set; }
        public Banco(int numeroConta, string nomeTitular)
        {
            this.numeroConta = numeroConta;
            this.nomeTitular = nomeTitular;
            this.saldo = 0.0;
        }
        public Banco (int numeroConta, string nomeTitular, double depositoInicial)
        {
            this.numeroConta = numeroConta;
            this.nomeTitular = nomeTitular;
            deposito(depositoInicial);
        }
        public void deposito(double valor)
        {
            saldo += valor;
        }
        public void saque(double valor)
        {
            saldo -= valor + 5.0;
        }
        public override string ToString()
        {
            return "Conta "
                + numeroConta
                + ", Titular: "
                + nomeTitular
                + ", Saldo: $ "
                + saldo.ToString("F2");
        }
    }
}