using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Domain
{
    public class BankAccount
    {
        private decimal _balance = 5000M;
        public void Deposit(decimal amountToDeposit)
        {
            _balance += amountToDeposit;
        }

        public decimal GetBalance()
        {
            return _balance;
        }

        public void Withdraw(decimal amountToWithdraw)
        {
            if (amountToWithdraw > _balance) return;
            _balance -= amountToWithdraw;
        }
    }
}
