using MediatR;
using System.Runtime.Serialization;
using Jambo.Application.Commands;
using System;

namespace Jambo.Application.Commands.Posts
{
    [DataContract]
    public class PublishPostCommand : IRequest
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
