using System;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Companies.Core.ApplicationServices.Companies.Exceptions;

namespace Companies.Core.ApplicationServices
{
    public abstract class BaseRequestHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        public abstract Task<TResponse> InnerHandle(TRequest request);

        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken)
        {
            try
            {
                return InnerHandle(request);
            }
            catch (RequestException)
            {
                throw;
            }
            catch (Exception)
            {
                throw new ServerException();
            }
        }
    }
}
