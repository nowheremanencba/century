using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Shared
{
    /// <summary>
    /// Class ApiOkResponse
    /// </summary>
    public class ApiOkResponse
    {
        /// <summary>
        /// property Result
        /// </summary>
        public object Result { get; }

        /// <summary>
        /// ApiOkResponse Constructor       
        /// </summary>
        /// <param name="result"></param>
        public ApiOkResponse(object result) {
            Result = result;
        }
    }
}
