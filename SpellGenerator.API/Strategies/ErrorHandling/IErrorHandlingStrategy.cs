using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SpellGenerator.API.Strategies.ErrorHandling
{
    public interface IErrorHandlingStrategy
    {
        Task HandleError(HttpContext context, Exception ex, IWebHostEnvironment env);
    }
}
