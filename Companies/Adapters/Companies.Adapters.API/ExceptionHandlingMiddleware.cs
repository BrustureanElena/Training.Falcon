using System;
using System.Net;
using System.Threading.Tasks;
using Companies.Core.ApplicationServices.Companies.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Companies.Adapters.API
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context, ILogger<ExceptionHandlingMiddleware> logger)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                logger.Log(LogLevel.Error, ex, ex.Message, ex.StackTrace);
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var code = HttpStatusCode.InternalServerError;

            if (IsSameOrSubclass(ex.GetType(), typeof(RequestException)))
            {
                code = HttpStatusCode.Unauthorized;
            }

            context.Response.ContentType = "application/json";
            return Task.FromResult(0);
        }
        
        public static bool IsSameOrSubclass(Type potentialDescendant, Type potentialBase)
        {
            return potentialDescendant.IsSubclassOf(potentialBase) || potentialDescendant == potentialBase;
        }
    }
}
