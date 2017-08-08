using Autofac;
using Jambo.Domain.SeedWork;
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
            builder.Register(c => new ServiceBus(_connectionString, _topic)).As<IServiceBus>().SingleInstance();
        }
    }
}
