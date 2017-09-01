using Autofac;
using Jambo.ServiceBus;
using Jambo.ServiceBus.Kafka;

namespace Jambo.Producer.IoC
{
    public class BusModule : Module
    {
        private readonly string connectionString;
        private readonly string topic;

        public BusModule(string connectionString, string topic)
        {
            this.connectionString = connectionString;
            this.topic = topic;
        }

        protected override void Load(ContainerBuilder builder)
        {
            IBusWriter serviceBus = new Bus(connectionString, topic);
            builder.Register(c => serviceBus).As<IBusWriter>().SingleInstance();
        }
    }
}
