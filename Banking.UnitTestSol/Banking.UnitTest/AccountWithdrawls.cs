using Banking.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Banking.UnitTest
{
    public class AccountWithdrawls
    {
        private readonly BankAccount _account;
        private readonly decimal _openingBalance;

        public AccountWithdrawls()
        {
            _account = new BankAccount(new DummyBonusCalculator());
            _openingBalance = _account.GetBalance();
        }
        [Fact]
        public void WithdrawlingMoneyDecreasesBalance()
        {
            var account = new BankAccount(new DummyBonusCalculator());
            var openingBalance = account.GetBalance();
            var amountToWithdraw = 10M;

            account.Withdraw(amountToWithdraw);

            Assert.Equal(openingBalance - amountToWithdraw, account.GetBalance());
        }

        [Fact]
        public void UsersCanWithdrawFullBalance()
        {


            _account.Withdraw(_openingBalance);

            Assert.Equal(0, _account.GetBalance());
        }

        [Fact]
        public void OverdraftDoesNotDecreaseBalance()
        {

            var amountToWithdraw = _openingBalance + .01M;

            try
            {
                _account.Withdraw(amountToWithdraw);
            }
            catch (OverdraftException)
            {

                // Swallow!
            }
            finally
            {

                Assert.Equal(_openingBalance, _account.GetBalance());

            }
        }

        [Fact]
        public void OverdraftThrowsAnException()
        {


            Assert.Throws<OverdraftException>(() =>
                 _account.Withdraw(_openingBalance + 1)
            );
        }
    }
}
