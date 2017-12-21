namespace Jambo.Domain.ServiceBus
{
    using MediatR;
    using System;

    public interface ISubscriber : IDisposable
    {
        void Listen(IMediator mediator);
    }
}
