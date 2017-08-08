namespace Jambo.Domain.SeedWork
{
    public interface IEntity
    {
        void Attach(IServiceBus observer);
        void Detach(IServiceBus observer);
        void Notify();
        void AddDomainEvent(IEvent _event);
        void RemoveDomainEvent(IEvent _event);
    }
}
