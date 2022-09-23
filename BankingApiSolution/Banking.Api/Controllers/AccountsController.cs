using Banking.Api.Domain;
using Banking.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Banking.Api.Controllers;

[Produces("application/json")]
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
    [HttpGet("/accounts/{id}", Name ="get-account-by-id")]
    public async Task<ActionResult> GetAccountById(string id)
    {
        
        AccountSummaryResponse? response = await _accountManager.GetAccountByIdAsync(id);

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

        AccountSummaryResponse response = await _accountManager.CreateAccountAsync(request);

        return CreatedAtRoute("get-account-by-id", new { id = response.Id }, response);

    }

    [HttpGet("/accounts/{accountNumber}/balance")]
    public async Task<ActionResult> GetAccountBalance(string accountNumber)
    {
        //var balance = new AccountBalanceResponse { Balance = 42 };
        AccountBalanceResponse? balance = await _accountManager.GetBalanceForAccountAsync(accountNumber);
       if(balance is null)
        {
            return NotFound();
        } else
        {
            return Ok(balance);
        }
    }

    [HttpPost("/accounts/{accountNumber}/deposits")]
    public async Task<ActionResult> AddDeposit([FromBody] AccountTransactionRequest deposit, string accountNumber)
    {

        AccountTransactionResponse? response = await _accountManager.DepositAsync(accountNumber, deposit);
        if(response is null)
        {
            return NotFound();
        } else
        {
            return StatusCode(201, response);
        }
    }

  
}
