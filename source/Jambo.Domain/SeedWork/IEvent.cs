using MediatR;
using System;

namespace Jambo.Domain.SeedWork
{
    public interface IEvent : INotification
    {
        Guid AggregateRootId { get; set; }
        int Version { get; set; }
    }
}
