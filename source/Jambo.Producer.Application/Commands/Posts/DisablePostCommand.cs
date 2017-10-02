using MediatR;
using System.Runtime.Serialization;
using Jambo.Producer.Application.Commands;
using System;
using System.ComponentModel.DataAnnotations;

namespace Jambo.Producer.Application.Commands.Posts
{
    [DataContract]
    public class DisablePostCommand : CommandBase, IRequest
    {
        [DataMember]
        public Guid Id { get; private set; }

        public DisablePostCommand()
        {

        }

        public DisablePostCommand(Guid id) : this()
        {
            Id = id;
        }
    }
}
