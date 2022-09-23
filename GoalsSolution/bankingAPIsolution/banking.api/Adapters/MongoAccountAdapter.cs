using MongoDB.Driver;
using banking.api.Domain;

namespace banking.api.Adapters;

public class MongoAccountAdapter
{
    public IMongoCollection<AccountEntity> Accounts { get; set; }

    public MongoAccountAdapter(string connectionString)
    {
        var client = new MongoClient(connectionString);
        var database = client.GetDatabase("banking");
        Accounts = database.GetCollection<AccountEntity>("accounts");
    }
}
