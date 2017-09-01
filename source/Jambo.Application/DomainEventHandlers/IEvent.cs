using Jambo.Domain.ServiceBus;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jambo.Application.DomainEventHandlers
{
    public interface IEvent<T> : IRequest<T>
        where T : DomainEvent
    {

    }
}
