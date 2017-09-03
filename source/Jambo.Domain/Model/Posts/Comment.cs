using System;
using System.Collections.Generic;
using System.Text;

namespace Jambo.Domain.Model.Posts
{
    public class Comment : Entity
    {
        private string message;

        public string Message
        {
            get
            {
                return message;
            }
        }

        private Comment()
        {

        }

        public Comment(string message)
        {
            this.message = message;
        }
    }
}
