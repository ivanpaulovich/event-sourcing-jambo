using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jambo.Core.Infrastructure.Entities
{
    public interface ITodoItem
    {
        string Key { get; set; }
        string Name { get; set; }
        bool IsComplete { get; set; }
    }
}
