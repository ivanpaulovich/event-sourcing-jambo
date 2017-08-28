using Jambo.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Jambo.Web.Filters
{
    public class DomainExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception.GetType() == typeof(BlogDomainException))
            {
                string json = JsonConvert.SerializeObject(context.Exception.Message);

                context.Result = new BadRequestObjectResult(json);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }
        }
    }
}
