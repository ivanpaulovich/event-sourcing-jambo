using Autofac;
using Jambo.ServiceBus;
using Jambo.Producer.Infrastructure;
using Jambo.ServiceBus.Kafka;

namespace Jambo.Producer.IoC
{
    public class BusModule : Module
    {
        private readonly string _connectionString;
        private readonly string _topic;

        public BusModule(string connectionString, string topic)
        {
            _connectionString = connectionString;
            _topic = topic;
        }

        protected override void Load(ContainerBuilder builder)
        {
            IBusWriter serviceBus = new Bus(_connectionString, _topic);
            builder.Register(c => serviceBus).As<IBusWriter>().SingleInstance();
        }
    }
}
