using Jambo.Domain.Model.Blogs;
using Jambo.Domain.Model.Posts;
using MongoDB.Driver;

namespace Jambo.Infrastructure
{
    public class MongoContext
    {
        private readonly IMongoDatabase database;

        public MongoContext(string connectionString, string database)
        {
            MongoClient mongoClient = new MongoClient(connectionString);
            mongoClient.DropDatabase(database);
            this.database = mongoClient.GetDatabase(database);
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
    }
}
