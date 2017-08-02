using Autofac;
using Jambo.Application.Queries;
using Jambo.Domain.AggregatesModel.BlogAggregate;
using Jambo.Infrastructure.Repositories;
using Jambo.KafkaBus;

namespace Jambo.API.IoC
{
    public class BusModule : Module
    {
        public string ConnectionString { get; }

        public BusModule(string connectionString)
        {
            ConnectionString = connectionString;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new EventBus(ConnectionString)).As<IEventBus>();
        }
    }
}
