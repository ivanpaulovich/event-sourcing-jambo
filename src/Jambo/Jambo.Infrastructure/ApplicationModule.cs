using Autofac;
using Jambo.Domain.AggregatesModel.BuyerAggregate;
using Jambo.Data.EF.Repositories;

namespace Jambo.Infrastructure
{
    public class ApplicationModule
        : Autofac.Module
    {

        public string QueriesConnectionString { get; }

        public ApplicationModule(string qconstr)
        {
            QueriesConnectionString = qconstr;

        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BuyerWriteOnlyRepository>()
                .As<IBuyerWriteOnlyRepository>()
                .InstancePerLifetimeScope();
        }
    }
}
