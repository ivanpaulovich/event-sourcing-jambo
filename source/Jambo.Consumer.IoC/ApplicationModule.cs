using Autofac;
using Jambo.Application.Queries;
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
        public readonly string _connectionString;
        public readonly string _database;

        public ApplicationModule(string connectionString, string database)
        {
            _connectionString = connectionString;
            _database = database;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new BlogQueries(_connectionString, _database))
                .As<IBlogQueries>();

            builder.Register(c => new PostQueries(_connectionString, _database))
                .As<IPostQueries>();

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
