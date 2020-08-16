using ALB.Cliente.Domain.Entities;
using ALB.Cliente.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace ALB.Cliente.Application.UseCases
{
    public class ClienteGetbyCodeUseCase : IUseCaseAsync<string, ClienteEntity>
    {
        private readonly IClienteRepository clienteRepository;
        private readonly ILogger<ClienteGetbyCodeUseCase> logger;
        
        public ClienteGetbyCodeUseCase(IClienteRepository clienteRepository
            , ILogger<ClienteGetbyCodeUseCase> logger) 
        {
            this.clienteRepository = clienteRepository;
            this.logger = logger;            
        }

        public async Task<ClienteEntity> Execute(string request)
        {
            try
            {
                if (!string.IsNullOrEmpty(request))
                {
                    if (Guid.TryParse(request, out Guid guid))
                    {
                        return await clienteRepository.Get(guid);
                    }
                    else
                    {                        
                        throw new Exception("Código informado não é um GUID válido.");
                    }
                }
                else
                {
                    throw new Exception("Código não informado.");
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
