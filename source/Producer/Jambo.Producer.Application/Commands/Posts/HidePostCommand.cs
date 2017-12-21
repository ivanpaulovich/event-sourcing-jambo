using MediatR;
using System.Runtime.Serialization;
using Jambo.Producer.Application.Commands;
using System;

namespace Jambo.Producer.Application.Commands.Posts
{
    [DataContract]
    public class HidePostCommand : CommandBase, IRequest
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
