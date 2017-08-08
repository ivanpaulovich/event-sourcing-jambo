namespace Jambo.Domain.SeedWork
{
    public abstract class Entity : IEntity
    {
        private IServiceBus _serviceBus;

        internal Entity(IServiceBus serviceBus)
        {
            _serviceBus = serviceBus;
        }

        public void AddDomainEvent(IEvent _event)
        {
            _serviceBus.Add(_event);
        }
    }
}
