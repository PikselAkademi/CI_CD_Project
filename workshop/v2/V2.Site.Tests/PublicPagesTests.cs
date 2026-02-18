using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;

namespace V2.Site.Tests;

public class PublicPagesTests
{
    [Fact]
    public async Task PublicPages_ReturnSuccess()
    {
        await using var factory = new V2SiteWebApplicationFactory();
        using var client = factory.CreateClient();

        var home = await client.GetAsync("/");
        var about = await client.GetAsync("/Home/About");
        var contact = await client.GetAsync("/Home/Contact");

        home.EnsureSuccessStatusCode();
        about.EnsureSuccessStatusCode();
        contact.EnsureSuccessStatusCode();
    }

    [Fact]
    public async Task HomePage_ContainsSeededTitle()
    {
        await using var factory = new V2SiteWebApplicationFactory();
        using var client = factory.CreateClient();

        var response = await client.GetAsync("/");
        response.EnsureSuccessStatusCode();

        var html = await response.Content.ReadAsStringAsync();
        Assert.Contains("Ana Sayfa", html);
    }

    private sealed class V2SiteWebApplicationFactory : WebApplicationFactory<Program>
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
