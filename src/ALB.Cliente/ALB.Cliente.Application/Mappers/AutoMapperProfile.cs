using ALB.Cliente.Application.Models;
using ALB.Cliente.Domain.Entities;
using AutoMapper;
using System.Diagnostics.CodeAnalysis;

namespace ALB.Cliente.Application.Mappers
{
    [ExcludeFromCodeCoverage]
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() {
            CreateMap<ClienteRequest, ClienteEntity>();
            CreateMap<ClienteEntity, ClienteResponse>();
        }
    }
}
