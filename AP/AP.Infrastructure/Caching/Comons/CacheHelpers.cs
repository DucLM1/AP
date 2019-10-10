using Microsoft.AspNetCore.Http;

namespace AP.Infrastructure.Caching.Comons
{
    public class CacheHelpers
    {
        public static bool IsRequestClearCache(HttpContext context = null)
        {
            if (context == null) return false;

            if (context.Request != null && !string.IsNullOrWhiteSpace(context.Request.Headers["User-Agent"].ToString()))
                return context.Request.Headers["User-Agent"].ToString().Contains("refreshcache")
                       || !string.IsNullOrWhiteSpace(context.Request.Headers["wis-refreshcache"].ToString()) &&
                       context.Request.Headers["wis-refreshcache"] == "refreshcache";
            return false;
        }
    }
}