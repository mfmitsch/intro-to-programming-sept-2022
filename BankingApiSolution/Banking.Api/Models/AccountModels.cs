namespace Banking.Api.Models;

//{"id": "89898", "name": "Bob Smith" }

public record AccountSummaryResponse
{
    public string Id { get; init; } = string.Empty;
    public string Name { get; init; } = string.Empty;
}


public record AccountCreateRequest
{
    public string Name { get; set; } = string.Empty;
}

public record AccountBalanceResponse
{
    public decimal Balance { get; set; }
}

public record AccountTransactionRequest
{
    public decimal Amount { get; set; }
}

public record AccountTransactionResponse
{
    public string TransactionId { get; set; } = string.Empty;
    public DateTime PostedAt { get; set; }
    public decimal Amount { get; set; }
    public string Type { get; set; } = string.Empty;
}

// { "transactionId": "i939839", "postedAt": "some date time", "amount": 300, "type": "DEPOSIT" }