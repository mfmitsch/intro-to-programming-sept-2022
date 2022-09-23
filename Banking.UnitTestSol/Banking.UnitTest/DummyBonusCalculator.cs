using Banking.Domain;

public class DummyBonusCalculator : ICalculateAccountBonuses
{
    public decimal GetBonusForDepositOnAccount(decimal balance, decimal ammountToDeposit)
    {
        return 0;
    }
}