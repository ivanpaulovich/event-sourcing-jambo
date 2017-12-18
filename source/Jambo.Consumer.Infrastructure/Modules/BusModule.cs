namespace Jambo.Consumer.Infrastructure.Modules
{
    using Autofac;
    using Jambo.Consumer.Infrastructure.ServiceBus;
    using Jambo.Domain.ServiceBus;

    public class BusModule : Module
    {
        public string BrokerList { get; set; }
        public string Topic { get; set; }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Bus>()
                .As<ISubscriber>()
                .WithParameter("brokerList", BrokerList)
                .WithParameter("topic", Topic)
                .SingleInstance();
        }
    }
}
