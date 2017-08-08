namespace Jambo.Domain.SeedWork
{
    public interface IEntity
    {
        void AddDomainEvent(IEvent _event);
    }
}
