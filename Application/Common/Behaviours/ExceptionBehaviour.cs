using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Behaviours
{
    public class ExceptionBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
         where TRequest : MediatR.IRequest<TResponse>
    {
        private readonly ILogger<TRequest> _logger;

        public ExceptionBehaviour(ILogger<TRequest> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var response = default(TResponse);

            try
            {
                response = await next();
            }
            catch (Exception e)
            {
                var name = typeof(TRequest).Name;
                _logger.LogError($"Request Exception: {name}, Exception: {e.Message} ({e.InnerException?.Message}) {request}");

                ExceptionDispatchInfo.Capture(e).Throw();
            }
            return response;
        }
    }
}