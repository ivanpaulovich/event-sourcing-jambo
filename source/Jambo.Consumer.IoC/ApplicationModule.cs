using Autofac;
using Jambo.Domain.Model.Blogs;
using Jambo.Domain.Model.Posts;
using Jambo.Consumer.Infrastructure;
using Jambo.Consumer.Infrastructure.Repositories;
using Jambo.Consumer.Infrastructure.Repositories.Blogs;
using Jambo.Consumer.Infrastructure.Repositories.Posts;

namespace Jambo.Consumer.IoC
{
    public class ApplicationModule : Module
    {
        public readonly string _connectionString;
        public readonly string _database;

        public ApplicationModule(string connectionString, string database)
        {
            _connectionString = connectionString;
            _database = database;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new MongoContext(_connectionString, _database))
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
