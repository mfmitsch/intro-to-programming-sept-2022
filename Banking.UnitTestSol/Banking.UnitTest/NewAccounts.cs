using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Banking.Domain;

namespace Banking.UnitTest
{
    public class NewAccounts
    {
        [Fact]
        public void HaveCorrectOpeningBalance() 
        {
            var account = new BankAccount();

            decimal balance = account.GetBalance();

            Assert.Equal(5000, balance);
        }
    }
}
