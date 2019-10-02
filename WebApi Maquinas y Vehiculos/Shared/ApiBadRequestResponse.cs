using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Shared
{
    /// <summary>
    /// Class ApiBadRequestResponse
    /// </summary>
    public class ApiBadRequestResponse : ApiResponse
    {   
        /// <summary>
        /// Errors
        /// </summary>
        public IEnumerable<string> Errors { get; }

        /// <summary>
        /// ApiBadRequestResponse
        /// </summary>
        /// <param name="modelState"></param>
        public ApiBadRequestResponse(ModelStateDictionary modelState)
            : base(null)
        {
            if (modelState.IsValid)
            {
                throw new ArgumentException("ModelState must be invalid", nameof(modelState));
            }

            Errors = modelState.SelectMany(x => x.Value.Errors)
                .Select(x => x.ErrorMessage).ToArray();
        }
    }
}
