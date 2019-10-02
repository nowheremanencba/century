using Newtonsoft.Json;
using System;
using Domain.Core;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Shared
{
    /// <summary>
    /// ApiResponse
    /// </summary>
    public class ApiResponse
    {  
        /// <summary>
        /// Error Property
        /// </summary>
        public CenturyError Error { get; }
        /// <summary>
        /// StackTrace
        /// </summary>
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string StackTrace { get; }
        
        /// <summary>
        /// ApiResponse Constructor
        /// </summary>
        /// <param name="error"></param>
        /// <param name="stackTrace"></param>
        public ApiResponse(CenturyError error , string stackTrace=null)
        {
            Error = error;
            StackTrace = stackTrace;
        }

        private static string GetDefaultMessageForStatusCode(int statusCode)
        {
            switch (statusCode)
            {
                case 404:
                    return "No se encuentra el recurso";
                case 500:
                    return "Ocurrió un error al procesar la operación en el servidor";
                default:
                    return null;
            }
        }
    }
}
