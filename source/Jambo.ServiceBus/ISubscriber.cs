using MediatR;
using System;

namespace Jambo.ServiceBus
{
    public interface ISubscriber : IDisposable
    {
        void Listen(IMediator mediator);
    }
}
