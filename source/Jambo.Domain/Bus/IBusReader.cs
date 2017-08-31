using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jambo.Domain.ServiceBus
{
    public interface IBusReader : IDisposable
    {
        EventReceivedDelegate OnEventReceived { get; set; }
        void Listen();
    }
}
