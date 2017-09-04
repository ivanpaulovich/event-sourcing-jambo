using System;
using System.Collections.Generic;
using System.Text;

namespace Jambo.Domain.Model.Posts
{
    public class Comment : Entity
    {
        private Content message;

        public Content Message
        {
            get
            {
                return message;
            }
        }

        private Comment()
        {

        }

        public Comment(Content message)
        {
            this.message = message;
        }
    }
}
