using MongoDB.Bson.Serialization.Attributes;

namespace banking.api.Domain;

public class AccountEntity
{
    [BsonElement("_id")]
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;

    public decimal Balance { get; set; }
}
