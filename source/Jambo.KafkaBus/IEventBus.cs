using System.Threading.Tasks;

namespace Jambo.KafkaBus
{
    public interface IEventBus
    {
        Task Publish(IntegrationEvent @event);
    }
}
