using CopaGamesLambda3.Application.Interfaces;
using CopaGamesLambda3.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CopaGamesLambda3.IoC.Dependencies
{
    public static class ApplicationServicesDependencies
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IGameApplicationService, GameApplicationService>();

            return services;
        }
    }
}
