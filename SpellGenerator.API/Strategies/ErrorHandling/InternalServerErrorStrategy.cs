using System;

namespace SpellGenerator.API.Strategies.ErrorHandling
{
    public class InternalServerErrorStrategy : IErrorHandlingStrategy
    {
        public async Task HandleError(HttpContext context, Exception exception, IWebHostEnvironment env)
        {
            var code = 500;

            var result = new
            {
                error = env.IsDevelopment() ? exception.Message : "Le serveur a rencontré une erreur",
                stackTrace = env.IsDevelopment() ? exception.StackTrace : null
            };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = code;

            await context.Response.WriteAsJsonAsync(result);
        }
    }
}
