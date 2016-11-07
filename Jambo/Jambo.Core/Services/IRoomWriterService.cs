using Jambo.Core.Services.Aggregates;

namespace Jambo.Core.Services
{
    public interface ITodoItemService
    {
        void CreateRoom(IRoom room);

        void AddMessage(IMessage message);
    }
}
