using Jambo.Domain.AggregatesModel.BuyerAggregate;
using MediatR;
using System;

namespace Jambo.Application.Commands
{
    public class CreateOrderCommandHandler
        : IRequestHandler<CreateOrderCommand, bool>
    {
        private readonly IBuyerWriteOnlyRepository _orderRepository;
        private readonly IMediator _mediator;

        public CreateOrderCommandHandler(IMediator mediator, IBuyerWriteOnlyRepository orderRepository)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public bool Handle(CreateOrderCommand message)
        {
            throw new NotImplementedException();
        }
    }
}
