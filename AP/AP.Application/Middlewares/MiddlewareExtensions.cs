using Microsoft.AspNetCore.Builder;

namespace AP.Application.Middlewares
{
    public static class MiddlewareExtensions
    {
        //public static IApplicationBuilder UseCachePage(this IApplicationBuilder builder)
        //{
        //    return builder.UseMiddleware<CachePageMiddleware>();
        //}

        public static IApplicationBuilder Use301Middleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<Modify301ResponseMiddleware>();
        }
    }
}