namespace Jambo.Producer.Infrastructure.Modules
{
    using Autofac;
    using Jambo.Domain.Model.Blogs;
    using Jambo.Domain.Model.Posts;
    using Jambo.Producer.Infrastructure.DataAccess;
    using Jambo.Producer.Infrastructure.DataAccess.Repositories.Blogs;
    using Jambo.Producer.Infrastructure.DataAccess.Repositories.Posts;

    public class ApplicationModule : Module
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MongoContext>()
                .As<MongoContext>()
                .WithParameter("connectionString", ConnectionString)
                .WithParameter("databaseName", DatabaseName)
                .SingleInstance();

            builder.RegisterType<BlogReadOnlyRepository>()
                .As<IBlogReadOnlyRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<PostReadOnlyRepository>()
                .As<IPostReadOnlyRepository>()
                .InstancePerLifetimeScope();
        }
    }
}
