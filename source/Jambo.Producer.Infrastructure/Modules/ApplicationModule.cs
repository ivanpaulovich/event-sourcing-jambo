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
        public readonly string databaseName;

        public ApplicationModule(string connectionString, string databaseName)
        {
            this.connectionString = connectionString;
            this.databaseName = databaseName;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MongoContext>()
                .As<MongoContext>()
                .WithParameter("connectionString", connectionString)
                .WithParameter("databaseName", databaseName)
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
