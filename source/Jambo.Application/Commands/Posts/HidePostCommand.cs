using MediatR;
using System.Runtime.Serialization;
using Jambo.Application.Commands;
using System;

namespace Jambo.Application.Commands.Posts
{
    [DataContract]
    public class HidePostCommand : IRequest
    {
        [DataMember]
        public Guid Id { get; private set; }

        public HidePostCommand()
        {

        }

        public HidePostCommand(Guid id) : this()
        {
            Id = id;
        }
    }
}
