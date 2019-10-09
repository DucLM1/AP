using AP.Infrastructure.Caching.Configs;
using AP.Infrastructure.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.IO.Compression;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AP.Application.Middlewares
{
    public class CachePageMiddleware
    {
        private const string StreamFilterName = "mStreamFilterForCachePage";
        private static readonly object lockedObject = new object();
        private static readonly string _excludePatterns = AppSettings.Get("Cache:CachePage:ExcludedPathPattern", "");
        private static readonly string cacheKeyPrefix = AppSettings.Get("Cache:CachePage:KeyPrefix", "");
        //private readonly ICached _cacheClient;
        //private readonly ILogger _logger;
        private readonly RequestDelegate next;

        private string _device = "desktop";

        public CachePageMiddleware(RequestDelegate next, ILoggerFactory logger)
        {
            var config = AppSettings.Get<RedisConfig>("Cache:Redis:Page");
            //_cacheClient = new RedisCached(config);
            //_logger = logger.CreateLogger("CachePageMiddleware");
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            //_logger.LogInformation($"Cache Page Mode:{AppSettings.Get<bool>("Cache:CachePage:Used")}");
            if (!AppSettings.Get<bool>("Cache:CachePage:Used"))
                await next(context);
            else
                await ResolveRequestCache(context);
        }

        #region private methods

        private async Task ResolveRequestCache(HttpContext context)
        {
            var rawUrl = $"{context.Request.Host.Value}{context.Request.Path.Value}";
            //_logger.LogInformation($"Start cache page - url = {rawUrl}");
            //_device = DetectDevice.Instance.BrowserIsMobile(context) ? "mobile" : "desktop";

            if (ValidContent(context))
            {
                var keyCache = GenCacheKey(context);

                var content = await _cacheClient.GetAsync(keyCache, context);
                //_logger.LogInformation($"Get cache result:{!string.IsNullOrEmpty(content)} url = {rawUrl}");
                if (!string.IsNullOrWhiteSpace(content))
                {
                    context.Response.ContentType = "text/html; charset=utf-8";
                    //context.CompleteRequest();
                    context.Response.Headers.Add("X-Cache-Hit", "true");
                    context.Response.Headers.Add("X-Cache-Url", rawUrl);
                    context.Response.Headers.Add("X-Cache-Device", _device);

                    //context = EncodeBodyContent(context);
                    //_logger.LogInformation($"Cache hit url = {rawUrl}");
                    await context.Response.WriteAsync(content);
                }
                else
                {
                    #region update cache
                    //_logger.LogInformation($"Cache not hit - url = {rawUrl}");
                    var mStreamFilter = context.Response.Body;

                    try
                    {
                        using (var memStream = new MemoryStream())
                        {
                            context.Response.Body = memStream;

                            await next.Invoke(context);

                            memStream.Position = 0;
                            var responseBody = new StreamReader(memStream).ReadToEnd();

                            memStream.Position = 0;

                            await memStream.CopyToAsync(mStreamFilter);

                            if (!string.IsNullOrWhiteSpace(responseBody))
                            {
                                content = BasicCompression(responseBody);
                                //_logger.LogInformation($"context.Response.ContentType.Contains = {context.Response.ContentType.Contains("text/html")} - url = {rawUrl}");
                                //add cache page
                                if (context.Response.ContentType.Contains("text/html"))
                                {
                                    //var context = new HttpContextWrapper(mApplication.Context);

                                    var route = context.GetRouteData();
                                    var controllerName = "";
                                    var actionName = "";
                                    if (route?.Values.Count > 0)
                                    {
                                        route.Values.TryGetValue("controller", out object controllerNameObj);
                                        controllerName = controllerNameObj.ToStringEx();

                                        route.Values.TryGetValue("action", out object actionNameObj);
                                        actionName = actionNameObj.ToStringEx();
                                        //_logger.LogInformation($"controllerName = {controllerName} actionName = {actionName} - url = {rawUrl}");
                                        if (!string.IsNullOrEmpty(rawUrl) && !string.IsNullOrEmpty(controllerName) &&
                                            !string.IsNullOrEmpty(actionName))
                                        {
                                            try
                                            {
                                                var settings = CacheSettings.GetCurrentSettings(context);
                                                var pageConfig =
                                                    settings.GetPageSetting(string.Concat("/", controllerName, "/",
                                                        actionName));
                                                //_logger.LogInformation($"pageConfig.FilePath = {pageConfig.FilePath} - url = {rawUrl}");
                                                if (pageConfig.FilePath != null)
                                                // Do not use "await" because this do not need waiting
                                                {
                                                    _cacheClient.SetAsync(keyCache, content,
                                                        (int)pageConfig.CacheExpire / 60);
                                                    //_logger.LogInformation($"Set cache page - url = {rawUrl}");
                                                }
                                            }
                                            catch (Exception ex)
                                            {
                                                //_logger.LogInformation($"Exception- {ex} - url = {rawUrl}");
                                            }

                                        }
                                    }
                                }
                            }
                        }
                    }
                    finally
                    {
                        context.Response.Body = mStreamFilter;

                        mStreamFilter.Close();
                        mStreamFilter.Dispose();
                    }

                    #endregion
                }
            }
            else
            {
                //_logger.LogInformation($"Not valid!");
                await next.Invoke(context);
            }
        }

        private HttpContext EncodeBodyContent(HttpContext context)
        {
            try
            {
                //gzip
                //context.Response.Headers.Add("Accept-Encoding", "gzip");

                context.Response.Headers.Add("Accept-Encoding", "gzip");

                string acceptedTypes = context.Request.Headers["Accept-Encoding"]; // gzip, deflate, br

                // if we couldn't find the header, bail out 
                if (acceptedTypes == null)
                    return context;

                // Current response stream
                using (var baseStream = context.Response.Body)
                {
                    // If there are more than one possibility offered by the browser default to the preffered one from the web.config 
                    // If nothing is specified in the web.config default to GZip 
                    acceptedTypes = acceptedTypes.ToLower();

                    if (acceptedTypes.Contains("gzip") || acceptedTypes.Contains("x-gzip") ||
                        acceptedTypes.Contains("*"))
                    {
                        context.Response.Body = new GZipStream(baseStream, CompressionMode.Compress);
                        //This won't show up in a trace log but if you use fiddler or nikhil kothari's web dev helper BHO you can see it appended 
                        context.Response.Headers.Add("Content-Encoding", "gzip");
                    }
                    else if (acceptedTypes.Contains("deflate"))
                    {
                        context.Response.Body = new DeflateStream(baseStream, CompressionMode.Compress);
                        //This won't show up in a trace log but if you use fiddler or nikhil kothari's web dev helper BHO you can see it appended 
                        context.Response.Headers.Add("Content-Encoding", "deflate");
                    }
                }
            }
            catch (Exception ex)
            {
                //Logger.ErrorLog(ex);
            }

            return context;
        }

        private string GenCacheKey(HttpContext context)
        {
            //string url = $"{context.Request.Host.Value}{context.Request.Path.Value}";
            var path = $"{context.Request.Path.Value}";
            var deviceType = context.FromMobile() ? "mobile" : "desktop";
            try
            {
                _device = DetectDevice.Instance.BrowserIsMobile(context) ? "mobile" : "desktop";

                //_device = string.Concat(_device, ":", AppSettings.Instance.GetString("CacheByDomain", "OnDesktop"));

                if (string.IsNullOrEmpty(path) || path.Equals("/"))
                    path = "home";

                path = path.TrimStart('/').Replace("/", "-");
                //string specialCharactersInURL = url.IndexOf("?") == -1? string.Empty: url.Substring(url.IndexOf("?"));
                //specialCharactersInURL = Regex.Replace(specialCharactersInURL, "[`~!@#$%^&*()_|+-=?;'\"<>{}[]]", string.Empty).Replace("\"", "-");
            }
            catch
            {
                if (path.Equals("/"))
                    path = "home";

                path = path.TrimStart('/').Replace("/", ":");
            }

            var cacheKey = string.Format(
                "{0}{1}{2}:{3}",
                cacheKeyPrefix,
                path,
                context.Request.QueryString.Value,
                deviceType
            );
            return cacheKey;
        }

        private bool ValidStatus(int status)
        {
            return status == 200;
        }

        private bool ValidContent(HttpContext context)
        {
            #region Do not cache "notfoud" page, css|js|image dynamic links

            var rawUrl = $"{context.Request.Host.Value}{context.Request.Path.Value}";

            var patternMatchContainUrl = @"(notfound|login|404|WIS|content|images|logo|well-know|rss|wp)";
            var regexMatchContainUrl =
                new Regex(patternMatchContainUrl, RegexOptions.IgnoreCase | RegexOptions.Singleline);
            var matchContainUrl = regexMatchContainUrl.Match(rawUrl);
            if (matchContainUrl.Success) return false;

            #endregion

            #region Do not cache status-code

            var statusResponse = context.Response.StatusCode;
            if (!ValidStatus(statusResponse)) return false;

            var method = context.Request.Method;
            if (method.ToLower().Equals("post")) return false;

            var patternMatchExtension =
                @"\.(txt|css|js|ico|jpg|jpeg|png|bmp|gif|eot|ttf|woff|woff2|aspx|xml|html|mp4|mp3|ico|map|config)$";
            var regexMatchExtensionUrl =
                new Regex(patternMatchExtension, RegexOptions.IgnoreCase | RegexOptions.Singleline);
            var matchExtension = regexMatchExtensionUrl.Match(rawUrl);
            if (matchExtension.Success) return false;

            #endregion

            #region Exclude links in config

            if (!string.IsNullOrWhiteSpace(_excludePatterns))
            {
                regexMatchExtensionUrl = new Regex(_excludePatterns, RegexOptions.IgnoreCase | RegexOptions.Singleline);
                matchExtension = regexMatchExtensionUrl.Match(rawUrl);
                return !matchExtension.Success;
            }

            #endregion

            return true;
        }

        private string BasicCompression(string content)
        {
            var newContent = content;

            // shorten multiple whitespace sequences
            newContent = Regex.Replace(newContent, ">\\s{2,}<", "><",
                RegexOptions.Singleline | RegexOptions.IgnoreCase);
            // strip whitespaces after tags, except space
            newContent = Regex.Replace(newContent, "\\>[^\\S]+", "> ",
                RegexOptions.Singleline | RegexOptions.IgnoreCase);
            // strip whitespaces before tags, except space
            newContent = Regex.Replace(newContent, "[^\\S ]+\\<", " <",
                RegexOptions.Singleline | RegexOptions.IgnoreCase);
            // shorten multiple whitespace sequences
            //newContent = Regex.Replace(newContent, ">(\\s){2,}<", ">$1<", RegexOptions.Singleline | RegexOptions.IgnoreCase);
            // Remove HTML comments
            newContent = Regex.Replace(newContent, "<!--(.|\\s)*?-->", "",
                RegexOptions.Singleline | RegexOptions.IgnoreCase);

            return newContent;
        }

        #endregion
    }
}