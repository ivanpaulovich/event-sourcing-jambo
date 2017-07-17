using Jambo.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jambo.Domain.AggregatesModel.BlogAggregate
{
    public class Post : Entity
    {
        public string Title { get; set; }
        public string Content { get; set; }

        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}
