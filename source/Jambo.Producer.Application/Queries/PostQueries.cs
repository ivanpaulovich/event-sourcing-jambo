using Jambo.Domain.Model.Blogs;
using Jambo.Domain.Model.Posts;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using System.Threading.Tasks;

namespace Jambo.Producer.Application.Queries
{
    public class PostQueries : IPostQueries
    {
        private readonly IMongoDatabase database;

        public IMongoCollection<ExpandoObject> Posts
        {
            get
            {
                return database.GetCollection<ExpandoObject>("Posts");
            }
        }

        public PostQueries(string connectionString, string database)
        {
            MongoClient mongoClient = new MongoClient(connectionString);
            this.database = mongoClient.GetDatabase(database);
        }

        public async Task<ExpandoObject> GetPostAsync(Guid id)
        {
            return await Posts.Find(Builders<ExpandoObject>.Filter.Eq("_id", id)).SingleAsync();
        }

        public async Task<IEnumerable<ExpandoObject>> GetPostsAsync(Guid blogId)
        {
            return await Posts.Find(Builders<ExpandoObject>.Filter.Eq("blogId", blogId)).ToListAsync();
        }
    }
}
