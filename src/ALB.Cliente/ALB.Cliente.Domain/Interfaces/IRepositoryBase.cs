using ALB.Cliente.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ALB.Cliente.Domain.Interfaces
{
    public interface IRepositoryBase<TEntity, TKey>
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<IEnumerable<TEntity>> GetWhere(Func<TEntity,bool> predicate);
        Task<TEntity> Get(dynamic key);
        Task Update(TEntity entity);
        Task Insert(TEntity entity);
        Task Delete(Func<TEntity, bool> predicate);
    }
}
