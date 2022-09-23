namespace Banking.Api.Adapters;

public interface IBonusCalculatorApiAdapter
{
    Task<BonusCalculationResponse?> GetBonusForDepositAsync(BonusCalculationRequest request);
}