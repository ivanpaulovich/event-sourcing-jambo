using System;

namespace Jambo.Core.Interfaces.Aggregates
{
    public interface IAggregateFactory
    {
        T CriarAggregate<T>();
    }
}
