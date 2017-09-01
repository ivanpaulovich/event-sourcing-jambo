using MediatR;
using System.Runtime.Serialization;
using Jambo.Producer.Application.Commands;
using System;
using System.ComponentModel.DataAnnotations;

namespace Jambo.Producer.Application.Commands.Posts
{
    [DataContract]
    public class EnablePostCommand : CommandBase, IRequest
    {
        [Required]
        [DataMember]
        public Guid Id { get; private set; }

        public EnablePostCommand()
        {

        }

        public EnablePostCommand(Guid id) : this()
        {
            Id = id;
        }
    }
}
