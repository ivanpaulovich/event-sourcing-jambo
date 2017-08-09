using Autofac;
using Jambo.Domain.SeedWork;
using Jambo.Infrastructure;
using Jambo.KafkaBus;

namespace Jambo.API.IoC
{
    public class ServiceBusModule : Module
    {
        private readonly string _connectionString;
        private readonly string _topic;

        public ServiceBusModule(string connectionString, string topic)
        {
            _connectionString = connectionString;
            _topic = topic;
        }

        protected override void Load(ContainerBuilder builder)
        {
            IServiceBus serviceBus = new ServiceBus(_connectionString, _topic);

            builder.Register(c => serviceBus).As<IServiceBus>().SingleInstance();
            builder.Register(c => new MessagingContext(serviceBus)).As<MessagingContext>().SingleInstance();
        }
    }
}
