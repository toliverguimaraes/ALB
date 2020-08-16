using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using ALB.Cliente.Application.Models;
using ALB.Cliente.Domain.Entities;
using ALB.Cliente.Domain.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ALB.Cliente.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly ILogger<ClienteController> _logger;
        private readonly IUseCaseAsync<ClienteEntity, IEnumerable<ClienteEntity>> getClientUseCaseAsync;
        private readonly IUseCaseAsync<string, ClienteEntity> getbycodeClientUseCaseAsync;
        private readonly IUseCaseDataAsync<ClienteEntity,Guid> postDataClienteUseCaseAsync;
        private readonly IMapper mapper;
        public ClienteController(ILogger<ClienteController> logger
            , IUseCaseAsync<ClienteEntity, IEnumerable<ClienteEntity>> getClientUseCaseAsync
            , IUseCaseAsync<string, ClienteEntity> getbycodeClientUseCaseAsync
            , IUseCaseDataAsync<ClienteEntity, Guid> postDataClienteUseCaseAsync
            , IMapper mapper)
        {
            _logger = logger;
            this.getClientUseCaseAsync = getClientUseCaseAsync;
            this.getbycodeClientUseCaseAsync = getbycodeClientUseCaseAsync;
            this.postDataClienteUseCaseAsync = postDataClienteUseCaseAsync;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ClienteResponse>> GetAllClients()
        {
            return mapper.Map<IEnumerable<ClienteResponse>>(await getClientUseCaseAsync.Execute(null));
        }
        [HttpGet("byFilter")]
        public async Task<IEnumerable<ClienteResponse>> GetClientsbyFilter([FromQuery] ClienteRequest parameters)
        {
            if (string.IsNullOrEmpty(parameters.id))
            {
                return mapper.Map<IEnumerable<ClienteResponse>>(await getClientUseCaseAsync.Execute(mapper.Map<ClienteEntity>(parameters)));
            }
            else {
                throw new WebException("Consulta por id utilizar rota byKey", WebExceptionStatus.RequestCanceled);
            }            
        }
        [HttpGet("byKey")]
        public async Task<ClienteResponse> GetClientbyKey(string key)
        {
            return mapper.Map<ClienteResponse>(await getbycodeClientUseCaseAsync.Execute(key));
        }
        [HttpPost]
        public async Task Inserir([FromQuery] ClienteRequest cliente)
        {
            await postDataClienteUseCaseAsync.Insert(mapper.Map<ClienteEntity>(cliente));
            _logger.LogDebug("Usuário inserido: " + cliente.nome.ToString());
        }
        [HttpPut]
        public async Task Atualizar([FromQuery] ClienteRequest cliente)
        {
            await postDataClienteUseCaseAsync.Update(mapper.Map<ClienteEntity>(cliente));
            _logger.LogDebug("Usuário atualizado: " + cliente.id.ToString());
        }
        [HttpDelete]
        public async Task Remover([FromQuery] Guid clienteId)
        {
            await postDataClienteUseCaseAsync.Delete(clienteId);
            _logger.LogDebug("Usuário removido: " + clienteId.ToString());
        }
    }
}
