using ALB.Cliente.Domain.Entities;
using ALB.Cliente.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ALB.Cliente.Application.UseCases
{
    public class ClienteGetUseCase : IUseCaseAsync<ClienteEntity, IEnumerable<ClienteEntity>>
    {
        private readonly IClienteRepository clienteRepository;
        private readonly ILogger<ClienteGetUseCase> logger;
        
        public ClienteGetUseCase(IClienteRepository clienteRepository
                               , ILogger<ClienteGetUseCase> logger) 
        {
            this.clienteRepository = clienteRepository;
            this.logger = logger;            
        }

        public async Task<IEnumerable<ClienteEntity>> Execute(ClienteEntity request)
        {
            try
            {
                if (request == null || (string.IsNullOrEmpty(request.Nome) && request.Idade == 0))
                {
                    return await clienteRepository.GetAll();
                }
                else
                {
                    return await clienteRepository.GetWhere(c => (!string.IsNullOrEmpty(request.Nome) && c.Nome.ToUpper().Contains(request.Nome.Trim().ToUpper())) || (request.Idade > 0 && c.Idade == request.Idade));
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw ex;
            }            
        }
    }
}
