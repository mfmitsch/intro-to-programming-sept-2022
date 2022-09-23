using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using apiModels = banking.api.Models;

namespace Banking.IntegrationTests;

public class AddingANewAccount
{
    [Fact]
    public async Task AddNewAccount()
    {
        var newAccount = new apiModels.AccountCreateRequest { Name = "Sue Jones" };
        await using var host = await AlbaHost.For<global::Program>(config => { });
        var result = await host.Scenario(api => {
            api.Post.Json(newAccount).ToUrl("/accounts"); api.StatusCodeShouldBe(201); api.ContentTypeShouldBe("application/json; charset=utf-8"); api.Header("Location").SingleValueShouldMatch(new Regex(@"^http://localhost/accounts/\w*"));

        });
        var response = result.ReadAsJson<apiModels.AccountSummaryResponse>();
        Assert.Equal(newAccount.Name, response?.Name);
        Assert.NotNull(response?.Id);
        var newId = response?.Id;
        var balanceResult = await host.Scenario(api => { api.Get.Url($"/accounts/{newId}/balance"); api.StatusCodeShouldBeOk(); });
    }
}
