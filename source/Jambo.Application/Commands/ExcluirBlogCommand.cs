using MediatR;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Jambo.Application.Commands;

namespace Jambo.Application.Commands
{
    [DataContract]
    public class ExcluirBlogCommand : IRequest
    {
        [DataMember]
        public Guid Id { get; private set; }

        public ExcluirBlogCommand()
        {

        }

        public ExcluirBlogCommand(Guid id) : this()
        {
            Id = id;
        }
    }
}
