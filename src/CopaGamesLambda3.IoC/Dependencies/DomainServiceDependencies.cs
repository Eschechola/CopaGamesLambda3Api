using CopaGamesLambda3.Services;
using CopaGamesLambda3.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CopaGamesLambda3.IoC.Dependencies
{
    public static class DomainServiceDependencies
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            services.AddScoped<IGameDomainService, GameDomainService>();

            return services;
        }
    }
}
