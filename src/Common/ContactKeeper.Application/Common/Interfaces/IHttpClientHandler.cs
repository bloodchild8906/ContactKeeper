using System.Threading;
using System.Threading.Tasks;
using ContactKeeper.Application.Common.Models;
using ContactKeeper.Domain.Enums;

namespace ContactKeeper.Application.Common.Interfaces
{
    public interface IHttpClientHandler
    {
        Task<ServiceResult<TResult>> GenericRequest<TRequest, TResult>(string clientApi, string url,
            CancellationToken cancellationToken,
            MethodType method = MethodType.Get,
            TRequest requestEntity = null)
            where TResult : class where TRequest : class;
    }
}