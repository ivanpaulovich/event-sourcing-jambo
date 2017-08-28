using MediatR;
using System.Runtime.Serialization;
using Jambo.Application.Commands;
using System;
using System.ComponentModel.DataAnnotations;

namespace Jambo.Application.Commands.Posts
{
    [DataContract]
    public class DisablePostCommand : IRequest
    {
        [Required]
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
