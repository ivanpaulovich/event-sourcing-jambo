using Jambo.Core.Services.Aggregates;

namespace Jambo.Core.Services
{
    public interface ITodoItemService
    {
        ITodoItem Create(ITodoItemDetails addItem);
    }
}
