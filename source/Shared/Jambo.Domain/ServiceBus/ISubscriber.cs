namespace Jambo.Domain.ServiceBus
{
    using MediatR;
    using System;

    public interface ISubscriber
    {
        void Listen(IMediator mediator);
    }
}
