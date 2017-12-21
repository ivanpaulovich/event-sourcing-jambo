namespace Jambo.Consumer.Infrastructure.Modules
{
    using Autofac;
    using Jambo.Domain.Model.Blogs;
    using Jambo.Domain.Model.Posts;
    using Jambo.Consumer.Infrastructure.DataAccess.Repositories.Blogs;
    using Jambo.Consumer.Infrastructure.DataAccess.Repositories.Posts;
    using Jambo.Consumer.Infrastructure.DataAccess;

    public class ApplicationModule : Module
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }

        protected override void Load(ContainerBuilder builder)
        {
            MongoContext mongoContext = new MongoContext(ConnectionString, DatabaseName);
            mongoContext.DatabaseReset(DatabaseName);

            builder.Register(c => mongoContext)
                .As<MongoContext>().SingleInstance();

            builder.RegisterType<BlogReadOnlyRepository>()
                .As<IBlogReadOnlyRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<BlogWriteOnlyRepository>()
                .As<IBlogWriteOnlyRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<PostReadOnlyRepository>()
                .As<IPostReadOnlyRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<PostWriteOnlyRepository>()
                .As<IPostWriteOnlyRepository>()
                .InstancePerLifetimeScope();
        }
    }
}
