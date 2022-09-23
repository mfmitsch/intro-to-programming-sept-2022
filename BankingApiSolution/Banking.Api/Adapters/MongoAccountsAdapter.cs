using Banking.Api.Domain;
using MongoDB.Driver;

namespace Banking.Api.Adapters;

public class MongoAccountsAdapter
{

    public  IMongoCollection<AccountEntity> Accounts { get; private set; }

	public MongoAccountsAdapter(string connectionString)
	{
		var client = new MongoClient(connectionString);
		var database = client.GetDatabase("banking");
		Accounts = database.GetCollection<AccountEntity>("accounts");
	}
}
