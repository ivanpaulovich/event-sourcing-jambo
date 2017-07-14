using System;
using System.Collections.Generic;
using System.Text;

namespace JamboTaskList.Domain.AggregatesModel.BlogAggregate
{
    public class Blog
    {
        public int BlogId { get; set; }
        public string Url { get; set; }
        public int Rating { get; set; }
        public List<Post> Posts { get; set; }
    }
}
