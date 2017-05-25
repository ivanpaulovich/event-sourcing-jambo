using Autofac;
using Jambo.Domain.AggregatesModel.BuyerAggregate;
using Jambo.InfrastructureDapper.Repositories;
using Jambo.InfrastructureEF;

namespace Jambo.IoC
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

            builder.RegisterType<BuyerReadOnlyRepository>()
                .As<IBuyerReadOnlyRepository>()
                .InstancePerLifetimeScope();
        }
    }
}
