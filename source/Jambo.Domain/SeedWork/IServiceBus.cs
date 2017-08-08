using System.Threading.Tasks;

namespace Jambo.Domain.SeedWork
{
    public interface IServiceBus
    {
        void Add(IEvent _event);
        Task Publish();
        Task Listen();
    }
}
