using Jambo.Domain.Model.Blogs;
using Jambo.Domain.Model.Posts;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Jambo.Producer.Application.Queries
{
    public class PostQueries : IPostQueries
    {
        private readonly IMongoDatabase _database;
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

        public PostQueries(string connectionString, string database)
        {
            MongoClient mongoClient = new MongoClient(connectionString);
            _database = mongoClient.GetDatabase(database);
        }

        public async Task<dynamic> GetPostAsync(Guid id)
        {
            return await Posts.Find(e => e.Id == id).SingleAsync();
        }

        public async Task<IEnumerable<dynamic>> GetPostsAsync(Guid blogId)
        {
            return await Posts.Find(e => e.BlogId == blogId).ToListAsync();
        }
    }
}
