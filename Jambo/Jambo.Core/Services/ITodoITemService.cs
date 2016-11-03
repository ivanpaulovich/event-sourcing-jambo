using Jambo.Core.Services.Aggregates;

namespace Jambo.Core.Services
{
    public interface ITodoITemService
    {
        ITodoItem Create(ITodoItemDetails addItem);
    }
}
