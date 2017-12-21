using MediatR;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Jambo.Producer.Application.Commands;

namespace Jambo.Producer.Application.Commands.Blogs
{
    [DataContract]
    public class DisableBlogCommand : CommandBase, IRequest
    {
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
