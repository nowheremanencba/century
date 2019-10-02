using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Shared
{
    /// <summary>
    /// Class ErrorWrappingMiddleware
    /// </summary>
    public class ErrorWrappingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorWrappingMiddleware> _logger;

        /// <summary>
        /// ErrorWrappingMiddleware Constructor
        /// </summary>
        /// <param name="next"></param>
        /// <param name="logger"></param>
        public ErrorWrappingMiddleware(RequestDelegate next, ILogger<ErrorWrappingMiddleware> logger)
        {
            _next = next;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception)
            {
                //_logger.LogError(EventIds.GlobalException, ex, ex.Message);

                context.Response.StatusCode = 500;
            }

            if (!context.Response.HasStarted)
            {
                context.Response.ContentType = "application/json";

                //var response = new ApiResponse(context.Response.StatusCode, "");
                var response = new ApiResponse(null, "");

                var json = JsonConvert.SerializeObject(response);

                await context.Response.WriteAsync(json);
            }
        }
    }
}
