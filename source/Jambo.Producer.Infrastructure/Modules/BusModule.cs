using Autofac;
using Jambo.Domain.ServiceBus;
using Jambo.Producer.Infrastructure.ServiceBus;

namespace Jambo.Producer.Infrastructure.Modules
{
    public class BusModule : Module
    {
        private readonly string brokerList;
        private readonly string topic;

        public BusModule(string brokerList, string topic)
        {
            this.brokerList = brokerList;
            this.topic = topic;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Bus>()
                .As<IPublisher>()
                .WithParameter("brokerList", brokerList)
                .WithParameter("topic", topic)
                .SingleInstance();
        }
    }
}
