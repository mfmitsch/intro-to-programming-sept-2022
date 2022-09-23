using banking.api.Adapters;
using banking.api.Models;
using MongoDB.Driver;

namespace banking.api.Domain;

public class AccountManager
{
    private readonly MongoAccountAdapter _adapter;

    public AccountManager(MongoAccountAdapter adapter)
    {
        _adapter = adapter;
    }

    public async Task<CollectionResponse<AccountSummaryResponse>> GetAllAccountsAsync()
    {

        var accountsProjection = Builders<AccountEntity>.Projection.Expression(a => new AccountSummaryResponse { Id = a.Id, Name = a.Name });

        var data = await _adapter.Accounts.Find(_ => true).Project(accountsProjection).ToListAsync();
        var response = new CollectionResponse<AccountSummaryResponse>
        {
            Data = data
        };
        return response;
    }

    public async Task<AccountSummaryResponse?> GetAccountByIdAsync(string id)
    {

        var accountsProjection = Builders<AccountEntity>.Projection.Expression(a => new AccountSummaryResponse { Id = a.Id, Name = a.Name });
        var filter = Builders<AccountEntity>.Filter.Where(a => a.Id == id);
        var response = await _adapter.Accounts.Find(filter).Project(accountsProjection).SingleOrDefaultAsync();
        return response;
    }

    public async Task<AccountSummaryResponse> CreateAccountAsync(AccountCreateRequest request)
    {
        var accountEntity = new AccountEntity
        {
            Id = Guid.NewGuid().ToString(),
            Name = request.Name,
            Balance = 5000M
        };

        await _adapter.Accounts.InsertOneAsync(accountEntity);

        var response = new AccountSummaryResponse
        {
            Id = accountEntity.Id,
            Name = accountEntity.Name
        };
        return response;

    }

    public async Task<AccountBalanceResponse?> GetBalanceForAccountAsync(string accountNumber)
    {
        var filter = Builders<AccountEntity>.Filter.Where(a => a.Id == accountNumber);
        var balanceProjection = Builders<AccountEntity>.Projection.Expression(a => new AccountBalanceResponse { Balance = a.Balance });
        return await _adapter.Accounts.Find(filter).Project(balanceProjection).SingleOrDefaultAsync();
    }
}