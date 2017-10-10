using Jambo.Producer.Application.Queries;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using System.Threading.Tasks;

namespace Jambo.Producer.Infrastructure.Queries
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

        public PostQueries(string connectionString, string databaseName)
        {
            MongoClient mongoClient = new MongoClient(connectionString);
            this.database = mongoClient.GetDatabase(databaseName);
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
