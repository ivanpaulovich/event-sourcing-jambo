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
    public class DisableBlogCommand : IRequest
    {
        [Required]
        [DataMember]
        public Guid Id { get; private set; }

        public DisableBlogCommand()
        {

        }

        public DisableBlogCommand(Guid id) : this()
        {
            Id = id;
        }
    }
}
