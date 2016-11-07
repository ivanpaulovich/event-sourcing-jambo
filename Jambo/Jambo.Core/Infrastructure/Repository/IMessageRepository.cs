using Jambo.Core.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jambo.Core.Infrastructure.Repository
{
    public interface IMessageRepository
    {
        IEnumerable<IMessageRecord> GetMessagesForRoomID(int roomID);

        void AddMessageToRoom(int roomID, string authorName, string text);
    }
}
