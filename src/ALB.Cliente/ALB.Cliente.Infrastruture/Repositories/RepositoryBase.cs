using ALB.Cliente.Domain.Interfaces;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using ALB.Cliente.Domain.Entities;
using System.Linq;

namespace ALB.Cliente.Infrastruture.Repositories
{
    [ExcludeFromCodeCoverage]
    public class RepositoryBase<TEntity, Tkey> : IRepositoryBase<TEntity, Tkey> where TEntity : Entity<Tkey>
    {
        private readonly DbContext dbContext;
        private readonly DbSet<TEntity> dbSet;
        public RepositoryBase(DbContext dbContext) {
            this.dbContext = dbContext;
            dbSet = dbContext.Set<TEntity>();
        }

        public async Task Delete(Func<TEntity, bool> predicate)
        {
            dbSet.Where(predicate).ToList().ForEach(del => dbSet.Remove(del));
            await dbContext.SaveChangesAsync();
        }

        public async Task<TEntity> Get(dynamic key)
        {
            return await dbSet.FindAsync(key);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await dbSet.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetWhere(Func<TEntity, bool> predicate)
        {            
            var resultado = await GetAll();
            return resultado.Where(predicate).ToList();
        }

        public async Task Insert(TEntity entity)
        {
            dbSet.Add(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task Update(TEntity entity)
        {
            dbContext.Entry(entity).State = EntityState.Modified;
            await dbContext.SaveChangesAsync();
        }
    }
}
