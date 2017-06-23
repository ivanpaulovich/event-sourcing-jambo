using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Jambo.Application.Commands;

namespace Jambo.API.Controllers
{
    [Route("api/[controller]")]
    public class OrdersController : Controller
    {
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {

            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        //[Route("new")]
        //[HttpPost]
        //public async Task<IActionResult> CreateOrder()//[FromBody]CreateOrderCommand command, [FromHeader(Name = "x-requestid")] string requestId)
        //{
        //    CreateOrderCommand command = new CreateOrderCommand();

        //    bool commandResult = await _mediator.Send(command);

        //    return commandResult ? (IActionResult)Ok() : (IActionResult)BadRequest();

        //}
    }
}
