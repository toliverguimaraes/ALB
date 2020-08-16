using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System.Diagnostics.CodeAnalysis;

namespace ALB.Cliente.Infrastruture.DataBases
{
    [ExcludeFromCodeCoverage]
    public static class DataBaseServiceRegistration
    {
        public static void RegisterSqlDataBase(this IServiceCollection services, IConfiguration configurations ) {
            services.AddDbContext<DbContextBase>(options => 
                options.UseSqlServer(configurations.GetConnectionString("LocalConnection"), optionsBuilder =>
                optionsBuilder.MigrationsAssembly("ALB.Cliente.API"))
            );   
        }
        
    }
}
