using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jambo.Core.Infrastructure.Entities
{
    public interface IEntityFactory
    {
        IMessageRecord CreateMessageRecord(int roomID, string authorName, string text);
        IRoomRecord CreateRoomRecord(string name);
    }
}
