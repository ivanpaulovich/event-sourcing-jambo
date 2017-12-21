using MediatR;
using System.Runtime.Serialization;
using Jambo.Producer.Application.Commands;
using System;

namespace Jambo.Producer.Application.Commands.Posts
{
    [DataContract]
    public class PublishPostCommand : CommandBase, IRequest
    {
        [DataMember]
        public Guid Id { get; private set; }

        public PublishPostCommand()
        {

        }

        public PublishPostCommand(Guid id) : this()
        {
            Id = id;
        }
    }
}
