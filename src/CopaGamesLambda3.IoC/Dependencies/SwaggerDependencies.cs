using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace CopaGamesLambda3.IoC.Dependencies
{
    public static class SwaggerDependencies
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CopaGamesLambda3.API", Version = "v1" });
            });

            return services;
        }
    }
}
