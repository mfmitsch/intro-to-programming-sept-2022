namespace Banking.Domain;

public class BankAccount
{

    private decimal _balance = 5000M; //JFHCI
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
        if (AccountHasAvailableFunds(amountToWithdraw))
        {
            _balance -= amountToWithdraw;
        }
        else
        {
            throw new OverdraftException();
        }
    }

    private bool AccountHasAvailableFunds(decimal amountToWithdraw)
    {
        return amountToWithdraw <= _balance;
    }
}
