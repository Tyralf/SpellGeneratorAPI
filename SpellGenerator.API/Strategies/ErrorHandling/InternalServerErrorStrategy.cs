using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace SpellGenerator.API.Strategies.ErrorHandling
{
    public class InternalServerErrorStrategy : IErrorHandlingStrategy
    {
        public async Task HandleError(HttpContext context, Exception exception, IWebHostEnvironment env)
        {
            var code = 500;

            // Simplification du formatage de la stack trace
            var formattedStackTrace = env.IsDevelopment() ? exception.StackTrace : null;

            var result = new
            {
                error = env.IsDevelopment() ? exception.Message : "Le serveur a rencontré une erreur.",
                stackTrace = formattedStackTrace
            };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = code;

            await context.Response.WriteAsJsonAsync(result);
        }
    }
}
