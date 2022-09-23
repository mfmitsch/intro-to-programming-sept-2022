using Alba;




namespace Banking.IntegrationTests;
public class AccountResourceTests
{



    [Fact]
    public async Task AccountResourcesReturnsAnOk()
    {
        await using var host = await AlbaHost.For<global::Program>(config => { });

        await host.Scenario(api =>
        {
            api.Get.Url("/accounts");
            api.StatusCodeShouldBeOk(); // response status is a 200
        });
    }
}