using Jambo.Core.Services.Aggregates;
using System.Collections.Generic;

namespace Jambo.Core.Services
{
    public interface IRoomReaderService
    {
        IEnumerable<IRoom> GetAllRooms();

        IEnumerable<IMessage> GetRoomMessages(int roomID);
    }
}
