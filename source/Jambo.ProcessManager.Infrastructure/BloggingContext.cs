using Jambo.Domain.AggregatesModel.BlogAggregate;
using Jambo.Domain.SeedWork;
using MongoDB.Driver;
using System.Threading;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace Jambo.ProcessManager.Infrastructure
{
    public class BloggingContext : IUnitOfWork
    {
        private readonly IMongoDatabase _database;
        public IMongoCollection<Blog> Blogs { get; set; }
        public IMongoCollection<Post> Posts { get; set; }

        private readonly Queue<IEvent> _domainEvents;
        private readonly IServiceBus _serviceBus;

        public BloggingContext(string connectionString, string database, IServiceBus serviceBus)
        {
            MongoClient mongoClient = new MongoClient(connectionString);
            _database = mongoClient.GetDatabase(database);

            _serviceBus = serviceBus;
            _domainEvents = new Queue<IEvent>();
        }

        public async Task Add(IEvent _event)
        {
            await Task.Run(() => _domainEvents.Enqueue(_event));
        }

        public async Task SaveChanges()
        {
            while (_domainEvents.Count > 0)
            {
                IEvent _event = _domainEvents.Dequeue();
                await _serviceBus.Publish(_event);
            }
        }

        public void Dispose()
        {
            _serviceBus.Dispose();
        }
    }
}
