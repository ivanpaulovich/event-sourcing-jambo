using MediatR;
using System;

namespace Jambo.Domain.ServiceBus
{
    public interface ISubscriber : IDisposable
    {
        void Listen(IMediator mediator);
    }
}
