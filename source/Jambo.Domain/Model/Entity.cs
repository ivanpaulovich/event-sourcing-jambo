using System;
using System.Collections.Generic;
using System.Text;

namespace Jambo.Domain.Model
{
    public class Entity : IEntity
    {
        public Guid Id { get; protected set; }

        public Entity()
        {
            Id = Guid.NewGuid();
        }
    }
}
