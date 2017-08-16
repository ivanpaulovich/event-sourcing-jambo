using Jambo.Domain.AggregatesModel.BlogAggregate;
using MongoDB.Driver;

namespace Jambo.Infrastructure
{
    public class MongoContext
    {
        private readonly IMongoDatabase _database;

        public MongoContext(string connectionString, string database)
        {
            MongoClient mongoClient = new MongoClient(connectionString);
            mongoClient.DropDatabase(database);
            _database = mongoClient.GetDatabase(database);
        }

        public IMongoCollection<Blog> Blogs
        {
            get
            {
                return _database.GetCollection<Blog>("Blogs");
            }
        }

        public IMongoCollection<Post> Posts
        {
            get
            {
                return _database.GetCollection<Post>("Posts");
            }
        }
    }
}
