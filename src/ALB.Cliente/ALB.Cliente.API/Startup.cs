using ALB.Cliente.Application.Mappers;
using ALB.Cliente.Infrastruture.DataBases;
using ALB.Cliente.Infrastruture.Diagnostics;
using ALB.Cliente.Infrastruture.IoC;
using ALB.Cliente.Infrastruture.Mapper;
using ALB.Cliente.Infrastruture.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ALB.Cliente.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            Registry.RegisterServices(services);
            services.RegisterSqlDataBase(Configuration);
            services.RegisterSwaggerGenerator();
            services.AddHealthCheckService();
            services.RegisterAutoMapper<AutoMapperProfile>();
            services.AddCors();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.RegisterHealthCheck();
            app.RegisterSwagger();
            app.UseCors(cors => cors.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
