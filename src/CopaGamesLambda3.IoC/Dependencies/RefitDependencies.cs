using CopaGamesLambda3.Infrastructure.Communication.Refit;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using System;

namespace CopaGamesLambda3.IoC.Dependencies
{
    public static class RefitDependencies
    {
        public static IServiceCollection AddRefit(this IServiceCollection services, string baseApiUrl)
        {
            services.AddRefitClient<IGameApi>()
                .ConfigureHttpClient(httpClient => httpClient.BaseAddress = new Uri(baseApiUrl));

            return services;
        }
    }
}
