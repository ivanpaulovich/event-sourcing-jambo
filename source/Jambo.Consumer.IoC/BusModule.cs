using Autofac;
using Jambo.Domain.ServiceBus;
using Jambo.Infrastructure;

namespace Jambo.Consumer.IoC
{
    public class BusModule : Module
    {
        private readonly string _connectionString;
        private readonly string _topic;
        private readonly EventReceivedDelegate _proccessDomainEvent;

        public BusModule(string connectionString, string topic, EventReceivedDelegate proccessDomainEvent)
        {
            _connectionString = connectionString;
            _topic = topic;
            _proccessDomainEvent = proccessDomainEvent;
        }

        protected override void Load(ContainerBuilder builder)
        {
            IBusReader serviceBus = new Jambo.Bus.Kafka.Bus(_connectionString, _topic);
            serviceBus.OnEventReceived = _proccessDomainEvent;
            serviceBus.Listen();

            builder.Register(c => serviceBus).As<IBusReader>().SingleInstance();
        }
    }
}
