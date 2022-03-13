using CopaGamesLambda3.API;
using CopaGamesLambda3.Tests.Projects.API.Fixtures;
using Xunit;

namespace CopaGamesLambda3.Tests.Projects.API.Collections
{
    [CollectionDefinition("Web application factory collection")]
    public class WebApplicationFactoryCollection : ICollectionFixture<CustomWebApplicationFixture<Startup>>
    {
    }
}
