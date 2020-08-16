using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ALB.Cliente.Domain.Interfaces
{
    public interface IUseCaseAsync<TRequest>
    {
        Task Execute(TRequest request);
    }
    public interface IUseCaseAsync<TRequest, TResponse>
    {
        Task<TResponse> Execute(TRequest request);
    }

    public interface IUseCaseDataAsync<TRequest,TKey>
    {
        Task Insert(TRequest request);
        Task Update(TRequest request);
        Task Delete(TKey request);
    }
}
