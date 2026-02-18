using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;

namespace V2.Admin.Tests;

public class AdminPagesTests
{
    [Fact]
    public async Task PagesIndex_ReturnsSuccessAndExpectedContent()
    {
        await using var factory = new V2AdminWebApplicationFactory();
        using var client = factory.CreateClient();

        var response = await client.GetAsync("/Pages");
        response.EnsureSuccessStatusCode();

        var html = await response.Content.ReadAsStringAsync();
        Assert.Contains("V2 Yönetim Paneli", html);
        Assert.Contains("home", html, StringComparison.OrdinalIgnoreCase);
    }

    [Fact]
    public async Task EditPage_ReturnsSuccess()
    {
        await using var factory = new V2AdminWebApplicationFactory();
        using var client = factory.CreateClient();

        var response = await client.GetAsync("/Pages/Edit/1");
        response.EnsureSuccessStatusCode();
    }

    private sealed class V2AdminWebApplicationFactory : WebApplicationFactory<Program>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseEnvironment("Testing");
            builder.ConfigureAppConfiguration((_, configBuilder) =>
            {
                configBuilder.AddInMemoryCollection(new Dictionary<string, string?>
                {
                    ["Database:Provider"] = "SqlServer"
                });
            });
        }
    }
}
