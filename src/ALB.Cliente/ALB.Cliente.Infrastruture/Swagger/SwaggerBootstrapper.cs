using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;
using Microsoft.OpenApi.Models;

namespace ALB.Cliente.Infrastruture.Swagger
{
    [ExcludeFromCodeCoverage]
    public static class SwaggerBootstrapper
    {
        public static void RegisterSwaggerGenerator(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Air Liquide Brasil", Version = "v1" });
            });
        }

        public static void RegisterSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Cliente v1");
            });
        }
    }
}
