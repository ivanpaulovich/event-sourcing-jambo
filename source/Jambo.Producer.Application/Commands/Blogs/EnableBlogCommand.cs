using MediatR;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Jambo.Producer.Application.Commands;
using System.ComponentModel.DataAnnotations;

namespace Jambo.Producer.Application.Commands.Blogs
{
    [DataContract]
    public class EnableBlogCommand : CommandBase, IRequest
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
