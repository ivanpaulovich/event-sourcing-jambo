using Jambo.Core.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jambo.Core.Infrastructure.Repository
{
    public interface ITodoItemRepository
    {
        void Add(ITodoItem item);
        IEnumerable<ITodoItem> GetAll();
        ITodoItem Find(string key);
        ITodoItem Remove(string key);
        void Update(ITodoItem item);
    }
}
