using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using SCG.DIST.WEBCOMPLAINT.SHAREDKERNEL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCG.DIST.WEBCOMPLAINT.SHAREDKERNEL.Filters
{
    public class ValidationFailedResult : ObjectResult
    {
        public ValidationFailedResult(ModelStateDictionary modelState)
        : base(ResponseResult<List<string>>.Fail(modelState))
        {
            StatusCode = StatusCodes.Status400BadRequest;
        }
    }
}
