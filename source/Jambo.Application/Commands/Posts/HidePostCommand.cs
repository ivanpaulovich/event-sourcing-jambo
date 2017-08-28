using MediatR;
using System.Runtime.Serialization;
using Jambo.Application.Commands;
using System;
using System.ComponentModel.DataAnnotations;

namespace Jambo.Application.Commands.Posts
{
    [DataContract]
    public class HidePostCommand : IRequest
    {
        [Required]
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
