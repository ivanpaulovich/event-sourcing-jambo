namespace Jambo.Domain.SeedWork
{
    public interface IEntity
    {
        void AddEvent(IEvent _event);
        void RemoveEvent(IEvent _event);
    }
}
