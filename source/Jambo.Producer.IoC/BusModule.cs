using Autofac;
using Jambo.Domain.ServiceBus;
using Jambo.Infrastructure;
using Jambo.Bus.Kafka;

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
            IBusWriter serviceBus = new Jambo.Bus.Kafka.Bus(_connectionString, _topic);
            builder.Register(c => serviceBus).As<IBusWriter>().SingleInstance();
        }
    }
}
