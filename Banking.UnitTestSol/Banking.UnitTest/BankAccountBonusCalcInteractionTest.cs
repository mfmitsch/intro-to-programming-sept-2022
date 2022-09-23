using Banking.Domain;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.UnitTest;

public class BankAccountBonusCalcInteractionTest
{
    private readonly BankAccount _account;
    private readonly decimal _openingBalance;

    public BankAccountBonusCalcInteractionTest()
    {
        _account = new BankAccount(new SuperBonusCalulator());
        _openingBalance = _account.GetBalance();
    }
    [Fact]
    public void UsesBonusCalculator()
    {
        var stubbedBonusCalculator = new Mock<ICalculateAccountBonuses>();

        var account = new BankAccount(stubbedBonusCalculator.Object);
        var openingBalance = account.GetBalance();
        var amountToDeposit = 420M;

        stubbedBonusCalculator.Setup(c => c.GetBonusForDepositOnAccount(openingBalance,
            amountToDeposit)).Returns(69.41M);

        account.Deposit(amountToDeposit);
        Assert.Equal(openingBalance + amountToDeposit + 69.41M, account.GetBalance());
        
    }
}
