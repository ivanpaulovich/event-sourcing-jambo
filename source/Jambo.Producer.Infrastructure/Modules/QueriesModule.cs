namespace Jambo.Producer.Infrastructure.Modules
{
    using Autofac;
    using Jambo.Producer.Application.Queries;
    using Jambo.Producer.Infrastructure.Queries;

    public class QueriesModule : Module
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BlogQueries>()
                .As<IBlogQueries>()
                .WithParameter("connectionString", ConnectionString)
                .WithParameter("databaseName", DatabaseName)
                .SingleInstance();

            builder.RegisterType<PostQueries>()
                .As<IPostQueries>()
                .WithParameter("connectionString", ConnectionString)
                .WithParameter("databaseName", DatabaseName)
                .SingleInstance();
        }
    }
}
