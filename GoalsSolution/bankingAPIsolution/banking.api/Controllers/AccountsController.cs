using banking.api.Domain;
using banking.api.Models;
using Microsoft.AspNetCore.Mvc;

namespace banking.api.Controllers;

public class AccountsController : ControllerBase
{
    private readonly AccountManager _accountManager;

    public AccountsController(AccountManager accountManager)
    {
        _accountManager = accountManager;
    }



    // GET /accounts

    [HttpGet("/accounts")]
    public async Task<ActionResult> GetAllAccounts()
    {
        CollectionResponse<AccountSummaryResponse> response = await _accountManager.GetAllAccountsAsync();
        return Ok(response); // return a 200 Ok status code.
    }

    // GET /accounts
    [HttpGet("/accounts/{id}", Name = "get-account-by-id")]
    public async Task<ActionResult> GetAccountById(string id)
    {

        AccountSummaryResponse response = await _accountManager.GetAccountByIdAsync(id);

        if (response is null)
        {
            return NotFound();
        }
        else
        {
            return Ok(response);
        }
    }

    [HttpPost("/accounts")]
    public async Task<ActionResult> AddAnAccount([FromBody] AccountCreateRequest request)
    {
        // validate it.
        // if bad, return 400
        // save it to the database or whatever
        // Return a 201 Created Status Code
        // Return a Location header with the URI of the brand new thing (Account)
        // And give them a copy of what they would get if they did a get request on that location header.
        //var response = new AccountSummaryResponse
        //{
        //    Id = Guid.NewGuid().ToString(),
        //    Name = request.Name
        //};
        AccountSummaryResponse response = await _accountManager.CreateAccountAsync(request);

        return CreatedAtRoute("get-account-by-id", new { id = response.Id }, response);

    }
    [HttpGet("/account")]
    public async Task<ActionResult> GetAccountBalance(string accountNumber)
    {
        AccountBalanceResponse balance = await _accountManager.GetBalanceForAccountAsync(accountNumber);
        if (balance is null)
        {
            return NotFound();
        }
        else
        {
            return Ok(balance);
        }
    }

    [HttpPost("/accounts/{accountNumber}/deposits")]
    public async Task<ActionResult> AddDeposit([FromBody] AccountTransactionRequest deposit, string accountNumber)
    {



        AccountTransactionResponse? response = await _accountManager.DepositAsync(accountNumber, deposit);
        if (response is null)
        {
            return NotFound();
        }
        else
        {
            return Ok(response);
        }
    }
}