using ALB.Cliente.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ALB.Cliente.Domain.Interfaces
{
    public interface IClienteRepository : IRepositoryBase<ClienteEntity, Guid> { }
}
