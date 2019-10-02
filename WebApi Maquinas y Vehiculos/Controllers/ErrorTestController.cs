using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Shared;

namespace WebApi.Controllers
{
    /// <summary>
    /// Controller ErrorTest
    /// </summary>
    public class ErrorTestController
    {
        /// <summary>
        /// Get Error 
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        [HttpGet("error/{code}")]
        public IActionResult Error(int code)
        {
            //return new ObjectResult(new ApiResponse(code));
            return null;
        }
    }
}
