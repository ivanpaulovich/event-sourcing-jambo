using Autofac;
using Jambo.Producer.Application.Queries;
using Jambo.Domain.Model.Blogs;
using Jambo.Domain.Model.Posts;
using Jambo.Infrastructure;
using Jambo.Infrastructure.Repositories;
using Jambo.Infrastructure.Repositories.Blogs;
using Jambo.Infrastructure.Repositories.Posts;

namespace Jambo.Producer.IoC
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
            builder.Register(c => new BlogQueries(connectionString, database))
                .As<IBlogQueries>();

            builder.Register(c => new PostQueries(connectionString, database))
                .As<IPostQueries>();

            builder.Register(c => new MongoContext(connectionString, database))
                .As<MongoContext>().SingleInstance();

            builder.RegisterType<BlogReadOnlyRepository>()
                .As<IBlogReadOnlyRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<PostReadOnlyRepository>()
                .As<IPostReadOnlyRepository>()
                .InstancePerLifetimeScope();
        }
    }
}
