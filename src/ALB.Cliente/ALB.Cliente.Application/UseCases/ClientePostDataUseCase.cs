using ALB.Cliente.Domain.Entities;
using ALB.Cliente.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace ALB.Cliente.Application.UseCases
{
    public class ClientePostDataUseCase : IUseCaseDataAsync<ClienteEntity,Guid>
    {
        private readonly IClienteRepository clienteRepository;
        private readonly ILogger<ClientePostDataUseCase> logger;

        public ClientePostDataUseCase(IClienteRepository clienteRepository
            , ILogger<ClientePostDataUseCase> logger)
        {
            this.clienteRepository = clienteRepository;
            this.logger = logger;
        }

        public async Task Insert(ClienteEntity request)
        {
            try
            {
                request.Id = Guid.NewGuid();
                request.Validate();

                if (request.Valid)
                {
                    await clienteRepository.Insert(request);
                }
                else
                {
                    throw new Exception(request.ShowNotification());
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex,ex.Message);
                throw ex;
            }
            
        }
        public async Task Update(ClienteEntity request)
        {
            try
            {
                request.Validate();

                if (request.Valid)
                {
                    await clienteRepository.Update(request);
                }
                else
                {                   
                    throw new Exception(request.ShowNotification());
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw ex;
            }
        }
        public async Task Delete(Guid id)
        {
            try
            {
                await clienteRepository.Delete(c => c.Id == id);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw ex;
            }            
        }
    }
}
