using System;

namespace Jambo.Domain.Aggregates
{
    public interface IEntity
    {
        Guid Id { get; }
    }
}
