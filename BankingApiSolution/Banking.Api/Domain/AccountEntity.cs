using MongoDB.Bson.Serialization.Attributes;

namespace Banking.Api.Domain;

public class AccountEntity
{
    [BsonElement("_id")]
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;

    public decimal Balance { get; set; }

    public List<Transaction> Transactions { get; set; } = new();
}


public class Transaction
{
    public string TransactionId { get; set; } = string.Empty;
    public DateTime PostedAt { get; set; }
    public decimal Amount { get; set; }
    public string Type { get; set; } = string.Empty;
}