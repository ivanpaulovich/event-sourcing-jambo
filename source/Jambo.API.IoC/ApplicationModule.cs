using Autofac;
using Jambo.Application.Queries;
using Jambo.Domain.SeedWork;

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

            builder.RegisterType<EntityFactory>()
                .As<IEntityFactory>().AsImplementedInterfaces();
        }
    }
}
