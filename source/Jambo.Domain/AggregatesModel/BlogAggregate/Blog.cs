using Jambo.Domain.Events;
using Jambo.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jambo.Domain.AggregatesModel.BlogAggregate
{
    public class Blog : Entity, IAggregateRoot
    {
        public string Url { get; set; }
        public int Rating { get; set; }
        public List<Post> Posts { get; set; }

        protected Blog() { }

        public Blog(int id) { this.Id = id; }

        public Blog(string url)
        {
            this.Url = url;
            this.Rating = 0;

            AddDomainEvent(new BlogCriadoDomainEvent(this));
        }
    }
}
