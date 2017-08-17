using MediatR;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Jambo.Application.Commands;

namespace Jambo.Application.Commands
{
    [DataContract]
    public class DisableBlogCommand : IRequest
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
