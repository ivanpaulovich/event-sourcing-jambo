using MediatR;
using System.Threading.Tasks;

namespace Jambo.Domain.SeedWork
{
    public interface IServiceBus
    {
        Task Publish(INotification @event);
        Task Listen();
    }
}
