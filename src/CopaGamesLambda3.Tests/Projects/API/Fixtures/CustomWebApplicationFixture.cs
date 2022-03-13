using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;

namespace CopaGamesLambda3.Tests.Projects.API.Fixtures
{
    public class CustomWebApplicationFixture<TStartup> : WebApplicationFactory<TStartup>
        where TStartup : class
    {
        private const string ENV = "Testing";

        protected override void ConfigureWebHost(IWebHostBuilder builder)
            => builder.UseEnvironment(ENV);
    }
}
