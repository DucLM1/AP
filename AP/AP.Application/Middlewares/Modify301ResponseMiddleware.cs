using Microsoft.AspNetCore.Http;
using System.Net;
using System.Threading.Tasks;

namespace AP.Application.Middlewares
{
    public class Modify301ResponseMiddleware
    {
        private readonly RequestDelegate _next;

        public Modify301ResponseMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await _next(context);
            if (context.Response.StatusCode == (int)HttpStatusCode.MovedPermanently)
            {
                context.Response.Headers.Add("Cache-Control", "no-cache");
            }
        }
    }
}