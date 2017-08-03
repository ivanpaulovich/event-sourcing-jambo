using System.Threading.Tasks;

namespace Jambo.Domain.SeedWork
{
    public interface IEventBus
    {
        Task Publish(IntegrationEvent @event);
    }
}
