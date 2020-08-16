using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace ALB.Cliente.Infrastruture.Diagnostics
{
    [ExcludeFromCodeCoverage]
    public static class HealthCheckBootstrapper
    {
        public static void AddHealthCheckService(this IServiceCollection services) {
            services.AddHealthChecks();
        }
        public static void RegisterHealthCheck(this IApplicationBuilder app)
        {
            app.UseHealthChecks("/healthcheck");
        }
    }
}
