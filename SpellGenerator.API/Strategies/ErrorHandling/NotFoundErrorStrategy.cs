using System.Net;
using System;

namespace SpellGenerator.API.Strategies.ErrorHandling
{
    public class NotFoundErrorStrategy : IErrorHandlingStrategy
    {
        public async Task HandleError(HttpContext context, Exception exception, IWebHostEnvironment env)
        {

            var code = 404;

            var result = new
            {
                error = env.IsDevelopment() ? exception.Message : "La ressource demandé, n'a pas été trouvée.",
                stackTrace = env.IsDevelopment() ? exception.StackTrace : null
            };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = code;

            await context.Response.WriteAsJsonAsync(result);
        }
    }
}
