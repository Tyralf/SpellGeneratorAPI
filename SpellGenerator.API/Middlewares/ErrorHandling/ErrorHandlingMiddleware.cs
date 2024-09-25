using System.Net;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using SpellGenerator.API.Strategies.ErrorHandling;

namespace SpellGenerator.API.Middlewares.ErrorHandling
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;
        private readonly IWebHostEnvironment _env;
        private readonly Dictionary<Type, IErrorHandlingStrategy> _strategies;

        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger, IWebHostEnvironment env)
        {
            _next = next;
            _logger = logger;
            _env = env;
            _strategies = new Dictionary<Type, IErrorHandlingStrategy>
            {
                { typeof(Exception), new InternalServerErrorStrategy() },
                { typeof(KeyNotFoundException), new NotFoundErrorStrategy() },
                { typeof(NullReferenceException), new InternalServerErrorStrategy() },
                { typeof(InvalidOperationException), new InternalServerErrorStrategy() }
            };
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context); // Appel du prochain middleware dans la chaîne
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            _logger.LogError(exception, "An error occurred.");

            var exceptionType = exception.GetType();

            if (_strategies.TryGetValue(exceptionType, out var strategy))
            {
                await strategy.HandleError(context, exception, _env);
            }
            else
            {
                await _strategies[typeof(Exception)].HandleError(context, exception, _env);
            }
        }

    }
}
