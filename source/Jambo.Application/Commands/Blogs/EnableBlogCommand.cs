using MediatR;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Jambo.Application.Commands;

namespace Jambo.Application.Commands.Blogs
{
    [DataContract]
    public class EnableBlogCommand : IRequest
    {
        [DataMember]
        public Guid Id { get; private set; }

        public EnableBlogCommand()
        {

        }

        public EnableBlogCommand(Guid id) : this()
        {
            Id = id;
        }
    }
}
