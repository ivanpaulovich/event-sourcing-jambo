using System;
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

        public async Task<string> Index()
        {
            CreateOrderCommand command = new CreateOrderCommand();
            bool commandResult = await _mediator.Send(command);

            return DateTime.Now.ToString();
        }
    }
}
