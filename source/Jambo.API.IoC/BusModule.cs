using Autofac;
using Jambo.Application.Queries;
using Jambo.Domain.AggregatesModel.BlogAggregate;
using Jambo.Domain.SeedWork;
using Jambo.Infrastructure.Repositories;
using Jambo.InMemoryBus;
using System.Threading.Tasks;

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
            builder.RegisterType<EventBus>().As<IEventBus>().SingleInstance();
            //builder.Register(c => new EventBus("10.17.12.46:32774", "blogs")).As<IEventBus>().SingleInstance();
        }
    }
}
