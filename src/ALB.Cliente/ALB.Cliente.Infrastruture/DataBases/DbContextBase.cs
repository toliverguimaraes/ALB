using ALB.Cliente.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace ALB.Cliente.Infrastruture.DataBases
{
    [ExcludeFromCodeCoverage]
    public class DbContextBase : DbContext
    {
        DbSet<ClienteEntity> Clientes { get; set; }
        public DbContextBase(DbContextOptions<DbContextBase> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.ApplyConfiguration(new ClienteEntityConfigurations());
        }
    }
}
