using MediatR;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Jambo.Application.Commands;

namespace Jambo.Application.Commands
{
    [DataContract]
    public class ExcluirBlogCommand
        : IRequest<bool>
    {
        [DataMember]
        public int Id { get; private set; }

        public ExcluirBlogCommand()
        {

        }

        public ExcluirBlogCommand(int id) : this()
        {
            Id = id;
        }
    }
}
