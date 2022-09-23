using Alba.Security;
using Banking.Api.Adapters;
using Banking.Api.Domain;
using Microsoft.Extensions.DependencyInjection;
using System.Text.RegularExpressions;
using apiModels = Banking.Api.Models;

namespace Banking.IntegrationTests;
public class AddingNewAccounts
{
    [Fact]
    public async Task AddingANewAccount()
    {
        // add a new account through the api.
        // verify we get back:
        // 201 Status Code
        // Location Header with the URI of the new resource
        // And a copy of the resource, with an ID
        // Request it again from the API, but get it's subordinate resource /balance
        // verify it is 5000
        // Given
        var newAccount = new apiModels.AccountCreateRequest { Name = "Sue Jones" };
        var stubbedDate = new DateTime(1969, 4, 20, 23, 59, 00);
        await using var host = await AlbaHost.For<global::Program>(config => {

            
            config.ConfigureServices(sp =>
            {
                var stubbedApi = new Mock<IBonusCalculatorApiAdapter>();
                stubbedApi.Setup(b => b.GetBonusForDepositAsync(It.IsAny<BonusCalculationRequest>())).ReturnsAsync(new BonusCalculationResponse { Amount = 42.23M });
                sp.AddSingleton<IBonusCalculatorApiAdapter>(stubbedApi.Object);

                var stubbedClock = new Mock<ISystemTime>();
                stubbedClock.Setup(c => c.GetCurrent()).Returns(stubbedDate);
                sp.AddTransient<ISystemTime>(s => stubbedClock.Object);

            });
        });

       var result = await host.Scenario(api =>
        {
            api.Post.Json(newAccount).ToUrl("/accounts");
            api.StatusCodeShouldBe(201);
            api.ContentTypeShouldBe("application/json; charset=utf-8");
            api.Header("Location")
            .SingleValueShouldMatch(new Regex(@"^http://localhost/accounts/\w*"));
        });

        var response = result.ReadAsJson<apiModels.AccountSummaryResponse>();
        
        Assert.Equal(newAccount.Name, response?.Name);
        Assert.NotNull(response?.Id);
        var newId = response.Id;

        var balanceResult = await host.Scenario(api =>
        {
            // /accounts/83989389389/balance
            api.Get.Url($"/accounts/{newId}/balance");
            api.StatusCodeShouldBeOk();
            api.ContentTypeShouldBe("application/json; charset=utf-8");
        });

        var balanceResponse = balanceResult.ReadAsJson<apiModels.AccountBalanceResponse>();

        Assert.Equal(5000M, balanceResponse?.Balance);


        var depositToPost = new apiModels.AccountTransactionRequest { Amount = 100M };

        var depositResponse = await host.Scenario(api =>
        {
            api.Post.Json(depositToPost).ToUrl($"/accounts/{newId}/deposits");
            api.StatusCodeShouldBe(201);
            // check the location header, all that jazz... TODO
        });

        var transactionResult = depositResponse.ReadAsJson<apiModels.AccountTransactionResponse>();
        // look at all the properties...

        Assert.Equal(stubbedDate, transactionResult?.PostedAt);
        Assert.Equal(100 + 42.23M, transactionResult?.Amount);
        // POST /accounts/83983983/deposits
        // { "amount": 300 }

        // 201
        // { "transactionId": "i939839", "postedAt": "some date time", "amount": 300, "type": "DEPOSIT" }
    }

}
