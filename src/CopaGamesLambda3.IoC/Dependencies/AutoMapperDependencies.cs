using CopaGamesLambda3.IoC.Profiles;
using Microsoft.Extensions.DependencyInjection;

namespace CopaGamesLambda3.IoC.Dependencies
{
    public static class AutoMapperDependencies
    {
        public static IServiceCollection AddMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(GameProfile));

            return services;
        }
    }
}
