namespace Banking.Api.Adapters;

public class BonusCalculatorApiAdapter : IBonusCalculatorApiAdapter
{

    private readonly HttpClient _client;

    public BonusCalculatorApiAdapter(HttpClient client)
    {
        _client = client;
    }


    public async Task<BonusCalculationResponse?> GetBonusForDepositAsync(BonusCalculationRequest request)
    {
        var response = await _client.PostAsJsonAsync("/bonus-calculations", request);

        response.EnsureSuccessStatusCode(); // This is weird. If it isn't a 200-299, it blows up here.

        var responseObject = await response.Content.ReadFromJsonAsync<BonusCalculationResponse>();

        return responseObject;
    }
}


public record BonusCalculationResponse
{
    public decimal Amount { get; set; }
}

public record BonusCalculationRequest
{
    public decimal Balance { get; set; }
    public decimal AmountOfDeposit { get; set; }

    public string AccountNumber { get; set; } = string.Empty;
}