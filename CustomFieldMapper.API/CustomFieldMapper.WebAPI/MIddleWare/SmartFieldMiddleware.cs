using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using SmartFieldMapper.BusinessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartFieldMapper.WebAPI.MIddleWare
{
    /// <summary>
    /// Smart   Field Middleware
    /// </summary>
    public class SmartFieldMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly List<string> exceptionPath = new List<string>() { "/swagger/v0/swagger.json"};
        /// <summary>
        /// basic Middleware Constructor
        /// </summary>
        /// <param name="next"></param>
        public SmartFieldMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        /// <summary>
        /// Invoke
        /// </summary>
        /// <param name="context"></param>
        /// <param name="apiHeaders"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context, IApiHeaders apiHeaders)
        {
            if (exceptionPath.IndexOf(context.Request.Path.ToString().ToLower()) == -1)
            {
                var BPC = context.Request.Headers?.FirstOrDefault(x => x.Key.Equals("BPC", StringComparison.InvariantCultureIgnoreCase)).Value.ToString();
                if (string.IsNullOrEmpty(BPC))
                {
                    context.Response.StatusCode = 401;
                    await context.Response.WriteAsync(
                        "Access to API is denied, BPC Header is missing.");

                    return;
                }
                else
                {
                    long bpc = 0;
                    if (long.TryParse(BPC, out bpc))
                    {
                        apiHeaders.BPC = bpc;
                    }
                    else
                    {
                        await context.Response.WriteAsync(
                        "Access to API is denied, Invalid BPC.");
                    }
                }
            }
            await _next(context);
        }
    }
}
