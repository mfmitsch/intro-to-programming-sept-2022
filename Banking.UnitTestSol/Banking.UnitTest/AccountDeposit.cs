using Banking.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.UnitTest
{
    public class AccountDeposit
    {
        [Fact]
        public void MakingDepositIncreaseTheBalance()
        {
            var account = new BankAccount(new DummyBonusCalculator());
            var openingBalance = account.GetBalance();
            var amountToDeposit = 10.15M;

            account.Deposit(amountToDeposit);
            Assert.Equal(amountToDeposit + openingBalance, account.GetBalance());
        }
    }
}
