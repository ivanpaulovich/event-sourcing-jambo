using System;
using System.Threading.Tasks;

namespace Jambo.Domain.SeedWork
{
    public interface IServiceBus : IDisposable
    {
        Task Publish(IEvent _event);
        Task Listen();
    }
}
