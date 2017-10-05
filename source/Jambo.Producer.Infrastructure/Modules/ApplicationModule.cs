using Autofac;
using Jambo.Domain.Model.Blogs;
using Jambo.Domain.Model.Posts;
using Jambo.Producer.Infrastructure;
using Jambo.Producer.Infrastructure.DataAccess;
using Jambo.Producer.Infrastructure.DataAccess.Repositories;
using Jambo.Producer.Infrastructure.DataAccess.Repositories.Blogs;
using Jambo.Producer.Infrastructure.DataAccess.Repositories.Posts;

namespace Jambo.Producer.Infrastructure.Modules
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
