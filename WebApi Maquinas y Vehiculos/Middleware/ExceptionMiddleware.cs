using Domain.Core;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace WebApi.Empleados.Middleware
{
    /// <summary>
    /// 
    /// </summary>
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate next;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="next"></param>
        public ExceptionMiddleware(RequestDelegate next)
        {
            this.next = next;
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
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, object ex)
        {
            CenturyError centuryError;
            var exception = (Exception)ex;

            if (ex.GetType() == typeof(CenturyException))
            {
                centuryError = ((CenturyException)ex).CenturyError;
            }
            else
            {
                centuryError = new CenturyError(CenturyError.TipoError.NoControlada,
                    exception.Message,
                    string.Empty);
            }

            var result = JsonConvert.SerializeObject(new { error = centuryError, stacktrace = exception.StackTrace });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = GetStatusCode(centuryError);
            return context.Response.WriteAsync(result);
        }

        private static int GetStatusCode(CenturyError centuryError)
        {
            switch (centuryError.Codigo)
            {
                case CenturyError.TipoError.NoEncontrado:
                    return StatusCodes.Status404NotFound;
                default:
                    return StatusCodes.Status500InternalServerError;
            }
        }
    }
}
