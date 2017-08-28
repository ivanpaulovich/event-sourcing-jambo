using Jambo.Application.Commands;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jambo.Web.Filters
{
    public class CorrelationFilter : ActionFilterAttribute
    {
        private Guid correlationId;

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ActionArguments.ContainsKey("command"))
                return;

            CommandBase command = context.ActionArguments["command"] as CommandBase;

            if (command == null)
                return;

            if (context.HttpContext.Request.Headers.ContainsKey("correlationid"))
                correlationId = Guid.Parse(context.HttpContext.Request.Headers["correlationid"]);
            else
                correlationId = Guid.NewGuid();

            command.CorrelationId = correlationId;
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);

            context.HttpContext.Response.Headers.Add("correlationid", correlationId.ToString());
        }
    }
}
