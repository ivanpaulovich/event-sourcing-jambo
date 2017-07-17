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

        public Blog(string url, int rating)
        {
            this.Url = url;
            this.Rating = rating;

            AddDomainEvent(new BlogCriadoDomainEvent(this));
        }
    }
}
