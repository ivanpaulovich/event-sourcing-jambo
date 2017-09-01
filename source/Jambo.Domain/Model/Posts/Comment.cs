using System;
using System.Collections.Generic;
using System.Text;

namespace Jambo.Domain.Model.Posts
{
    public class Comment : IEntity
    {
        public Guid Id { get; private set; }
        public string Message { get; private set; }

        public Comment()
        {

        }

        public Comment(string message)
        {
            Id = Guid.NewGuid();
            Message = message;
        }
    }
}
