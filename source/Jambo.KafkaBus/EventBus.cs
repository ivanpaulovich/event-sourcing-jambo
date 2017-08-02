using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Jambo.KafkaBus
{
    public class EventBus : IEventBus
    {
        public EventBus(string connectionString)
        {

        }

        public async Task Publish(IntegrationEvent @event)
        {
            await Task.Delay(2);
        }
    }
}
