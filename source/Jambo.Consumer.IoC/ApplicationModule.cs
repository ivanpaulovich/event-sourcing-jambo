using Autofac;
using Jambo.Domain.Model.Blogs;
using Jambo.Domain.Model.Posts;
using Jambo.Infrastructure;
using Jambo.Infrastructure.Repositories;
using Jambo.Infrastructure.Repositories.Blogs;
using Jambo.Infrastructure.Repositories.Posts;

namespace Jambo.Consumer.IoC
{
    public class ApplicationModule : Module
    {
        public readonly string connectionString;
        public readonly string database;

        public ApplicationModule(string connectionString, string database)
        {
            this.connectionString = connectionString;
            this.database = database;
        }

        protected override void Load(ContainerBuilder builder)
        {
            MongoContext mongoContext = new MongoContext(connectionString, database);
            mongoContext.DatabaseReset(database);

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
