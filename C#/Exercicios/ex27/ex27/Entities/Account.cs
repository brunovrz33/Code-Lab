using System;
using System.Collections.Generic;
using System.Text;

namespace ex27.Entities
{
    class Account
    {
        public int Integer { get; private set; }
        public string? Holder { get; private set; }
        public double Balance { get; private set; }
        public double WithdrawLimit { get; private set; }

        public Account()
        {
        }
        public Account(int integer, string holder, double balance, double withdrawLimit)
        {
            Integer = integer;
            Holder = holder;
            Balance = balance;
            WithdrawLimit = withdrawLimit;
        }

        public void Withdraw(double amount)
        {
            if (amount > WithdrawLimit)
            {
                throw new DomainException("The amount exceeds withdraw limit");
            }
            if (amount > Balance)
            {
                throw new DomainException("Not enough balance");
            }
            Balance -= amount;
        }
    }
}
