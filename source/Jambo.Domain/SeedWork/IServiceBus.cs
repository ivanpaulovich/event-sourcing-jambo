using Jambo.Domain.Events;
using System;
using System.Threading.Tasks;

namespace Jambo.Domain.SeedWork
{
    public interface IServiceBus : IDisposable
    {
        Task Publish(IEvent _event);
        void AddSubscriber(ProcessDomainEventDelegate subscriber);
        Task Listen();
    }
}
