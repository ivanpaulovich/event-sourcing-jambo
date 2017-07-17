using Jambo.Domain.AggregatesModel.BlogAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jambo.Domain.Events
{
    public class PostCriadoDomainEvent: INotification
    {
        public Post Post { get; private set; }

        public PostCriadoDomainEvent(Post post)
        {
            Post = post;
        }
    }
}
