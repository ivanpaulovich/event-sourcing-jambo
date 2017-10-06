using Jambo.Domain.Model;
using Jambo.Domain.Model.Blogs;
using Jambo.Domain.Model.Posts;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace Jambo.Consumer.Infrastructure.DataAccess
{
    public class MongoContext
    {
        private readonly MongoClient mongoClient;
        private readonly IMongoDatabase database;

        public MongoContext(string connectionString, string databaseName)
        {
            this.mongoClient = new MongoClient(connectionString);
            this.database = mongoClient.GetDatabase(databaseName);
            Map();
        }

        public void DatabaseReset(string databaseName)
        {
           mongoClient.DropDatabase(databaseName);
        }

        public IMongoCollection<Blog> Blogs
        {
            get
            {
                return database.GetCollection<Blog>("Blogs");
            }
        }

        public IMongoCollection<Post> Posts
        {
            get
            {
                return database.GetCollection<Post>("Posts");
            }
        }

        private void Map()
        {
            BsonClassMap.RegisterClassMap<Entity>(cm =>
            {
                cm.MapIdProperty(c => c.Id);
            });

            BsonClassMap.RegisterClassMap<AggregateRoot>(cm =>
            {
                cm.MapProperty(c => c.Version).SetElementName("_version");
            });

            BsonClassMap.RegisterClassMap<Blog>(cm =>
            {
                cm.MapField("url").SetElementName("url");
                cm.MapField("rating").SetElementName("rating");
                cm.MapField("enabled").SetElementName("enabled");
            });

            BsonClassMap.RegisterClassMap<Post>(cm =>
            {
                cm.MapField("title").SetElementName("title");
                cm.MapField("content").SetElementName("content");
                cm.MapField("blogId").SetElementName("blogId");
                cm.MapField("enabled").SetElementName("enabled");
                cm.MapField("published").SetElementName("published");
            });

            BsonClassMap.RegisterClassMap<Comment>(cm =>
            {
                cm.MapField("message").SetElementName("message");
            });
        }
    }
}
