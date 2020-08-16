using ALB.Cliente.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ALB.Cliente.UnitTests.Util
{
    public class BuilderCliente
    {
        public Task<IEnumerable<ClienteEntity>> GetBuildEntityAsync(int count, Guid? key) {
            return Task.FromResult(this.GetBuildEntity(count, key));
        }

        public IEnumerable<ClienteEntity> GetBuildEntity(int count, Guid? key) {

            var result = new List<ClienteEntity>();
            for (int i = 0; i < count; i++)
            {
                result.Add(new ClienteEntity { Id = Guid.NewGuid(), Nome = "teste " + count.ToString(), Idade = new Random().Next(18, 99) });
            }
            if (key != null ) {
                result.Add(GetBuildEntity(key.Value).Result);
            }
            return result;
        }

        public Task<ClienteEntity> GetBuildEntity(Guid key)
        {            
            return Task.FromResult(new ClienteEntity { Id = key, Nome = "teste ", Idade = new Random().Next(18, 99) });
        }
    }
}
