using MediatR;
using System;

namespace Jambo.Domain.SeedWork
{
    public class IntegrationEvent : IRequest
    {
        public IntegrationEvent()
        {
            Id = Guid.NewGuid();
            CreationDate = DateTime.UtcNow;
        }

        public Guid Id { get; }
        public DateTime CreationDate { get; }
    }
}
