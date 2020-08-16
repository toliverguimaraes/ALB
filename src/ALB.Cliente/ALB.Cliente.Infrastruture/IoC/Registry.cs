using ALB.Cliente.Application.UseCases;
using ALB.Cliente.Domain.Entities;
using ALB.Cliente.Domain.Interfaces;
using ALB.Cliente.Infrastruture.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace ALB.Cliente.Infrastruture.IoC
{
    [ExcludeFromCodeCoverage]
    public static class Registry
    {
        public static void RegisterServices(this IServiceCollection services) {

            #region UseCases

            services.AddTransient<IUseCaseAsync<ClienteEntity, IEnumerable<ClienteEntity>>, ClienteGetUseCase>();
            services.AddTransient<IUseCaseAsync<string, ClienteEntity>, ClienteGetbyCodeUseCase>();
            services.AddTransient<IUseCaseDataAsync<ClienteEntity, Guid>, ClientePostDataUseCase>();

            #endregion

            #region Repositories

            services.AddTransient<IClienteRepository, ClienteRepository>();

            #endregion
        }
    }
}
