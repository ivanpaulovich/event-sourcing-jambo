using MediatR;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Jambo.Application.Commands;
using System.ComponentModel.DataAnnotations;

namespace Jambo.Application.Commands.Blogs
{
    [DataContract]
    public class EnableBlogCommand : CommandBase, IRequest
    {
        [Required]
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
