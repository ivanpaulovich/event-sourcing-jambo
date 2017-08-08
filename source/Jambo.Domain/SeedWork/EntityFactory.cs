using System;

namespace Jambo.Domain.SeedWork
{
    public class EntityFactory : IEntityFactory
    {
        private readonly IServiceBus _serviceBus;

        public EntityFactory(IServiceBus serviceBus)
        {
            _serviceBus = serviceBus;
        }

        public T Create<T>() where T: IEntity
        {
            T entity = Activator.CreateInstance<T>();
            entity.Attach(_serviceBus);

            return entity;
        }
    }
}
