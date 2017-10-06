using Autofac;
using Jambo.Consumer.Infrastructure.ServiceBus;
using Jambo.Domain.ServiceBus;
using MediatR;

namespace Jambo.Consumer.Infrastructure.Modules
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
                .As<ISubscriber>()
                .WithParameter("brokerList", brokerList)
                .WithParameter("topic", topic)
                .SingleInstance();
        }
    }
}
