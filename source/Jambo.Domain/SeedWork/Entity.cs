using System;
using System.Collections.Generic;

namespace Jambo.Domain.SeedWork
{
    public abstract class Entity : IEntity
    {
        public Guid Id { get; private set; }

        public Entity()
        {
            Id = Guid.NewGuid();
        }

        public Entity(Guid id)
        {
            Id = id;
        }
    }
}
