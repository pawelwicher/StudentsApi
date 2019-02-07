using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Students
{
    public static class CorsConfigurator
    {
        private const string CorsPolicyName = "Students.Api";
        private const string FrontendOriginUrl = "FrontendOriginUrl";

        public static IServiceCollection AddCors(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            var frontendOriginUrl = configuration[FrontendOriginUrl];

            return serviceCollection.AddCors(o => o.AddPolicy(CorsPolicyName, corsBuilder =>
            {
                corsBuilder.WithOrigins(frontendOriginUrl)
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials();
            }));
        }

        public static IApplicationBuilder AddCors(this IApplicationBuilder applicationBuilder)
        {
            return applicationBuilder.UseCors(CorsPolicyName);
        }
    }
}
