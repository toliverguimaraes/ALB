using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace ALB.Cliente.Infrastruture.Mapper
{
    [ExcludeFromCodeCoverage]
    public static class AutoMapperBootstrapper
    {
        public static void RegisterAutoMapper<TProfile>(this IServiceCollection services) where TProfile : Profile, new() {
            var autoMapper = new MapperConfiguration(c => c.AddProfile<TProfile>());
            services.AddSingleton(autoMapper.CreateMapper());
        }
    }
}
