using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking.Domain;

public interface ICalculateAccountBonuses
{
    decimal GetBonusForDepositOnAccount(decimal balance,decimal amount);
}
