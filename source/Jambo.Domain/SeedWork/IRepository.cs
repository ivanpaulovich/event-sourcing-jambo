namespace Jambo.Domain.SeedWork
{
    public interface IRepository<T> where T : IAggregateRoot
    {
        IServiceBus ServiceBus { get; }
    }
}
