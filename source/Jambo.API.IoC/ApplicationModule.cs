using Autofac;
using Jambo.Application.Queries;
using Jambo.Domain.AggregatesModel.BlogAggregate;
using Jambo.Domain.SeedWork;
using Jambo.Infrastructure;
using Jambo.Infrastructure.Repositories;

namespace Jambo.API.IoC
{
    public class ApplicationModule : Module
    {
        public string QueriesConnectionString { get; }

        public ApplicationModule(string qconstr)
        {
            QueriesConnectionString = qconstr;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new BlogQueries(QueriesConnectionString))
                .As<IBlogQueries>();

            builder.RegisterType<BlogEventRepository>()
                .As<IBlogEventRepository>()
                .InstancePerLifetimeScope();
        }
    }
}
