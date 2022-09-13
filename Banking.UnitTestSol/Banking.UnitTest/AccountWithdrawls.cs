using Banking.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.UnitTest
{
    public class AccountWithdrawls
    {
        [Fact]
        public void WithdrawlingMoneyDecreasesBalance()
        {
            var account = new BankAccount();
            var openingBalance = account.GetBalance();
            var amountToWithdraw = 10M;

            account.Withdraw(amountToWithdraw);

            Assert.Equal(openingBalance - amountToWithdraw, account.GetBalance());
        }

        [Fact]
        public void OverdraftIsRejected()
        {
            var account = new BankAccount();
            var openingBalance = account.GetBalance();
            var amountToWithdraw = openingBalance + 0.01M;

            account.Withdraw(amountToWithdraw);

            Assert.Equal(openingBalance, account.GetBalance());
        }
    }
}
