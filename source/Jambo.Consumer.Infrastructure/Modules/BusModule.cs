using Autofac;
using Jambo.Consumer.Infrastructure.ServiceBus;
using Jambo.Domain.ServiceBus;
using MediatR;

namespace Jambo.Consumer.Infrastructure.Modules
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
            builder.Register(c => new Config(connectionString, topic)).As<Config>().SingleInstance();
            builder.RegisterType<Bus>().As<ISubscriber>().SingleInstance();
        }
    }
}
