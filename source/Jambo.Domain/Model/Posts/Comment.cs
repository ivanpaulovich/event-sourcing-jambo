using System;
using System.Collections.Generic;
using System.Text;

namespace Jambo.Domain.Model.Posts
{
    public class Comment : IEntity
    {
        public Guid Id { get; set; }
        public string Message { get; set; }

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
