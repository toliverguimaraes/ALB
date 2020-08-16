using ALB.Cliente.Domain.Entities;
using ALB.Cliente.Domain.Interfaces;
using ALB.Cliente.Infrastruture.DataBases;
using System;
using System.Diagnostics.CodeAnalysis;

namespace ALB.Cliente.Infrastruture.Repositories
{
    [ExcludeFromCodeCoverage]
    public class ClienteRepository : RepositoryBase<ClienteEntity,Guid>, IClienteRepository
    {        
        public ClienteRepository(DbContextBase dbContext) : base(dbContext) { }
    }
}
