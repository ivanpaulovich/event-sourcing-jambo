using MediatR;
using System.Runtime.Serialization;
using Jambo.Application.Commands;
using System;
using System.ComponentModel.DataAnnotations;

namespace Jambo.Application.Commands.Posts
{
    [DataContract]
    public class UpdatePostContentCommand : CommandBase, IRequest
    {
        [Required]
        [DataMember]
        public Guid Id { get; private set; }

        [StringLength(100, MinimumLength = 10)]
        [Required]
        [DataMember]
        public string Title { get; private set; }

        [StringLength(100, MinimumLength = 10)]
        [Required]
        [DataMember]
        public string Content { get; private set; }

        public UpdatePostContentCommand()
        {

        }

        public UpdatePostContentCommand(Guid id, string title, string content) : this()
        {
            Id = id;
            Title = title;
            Content = content;
        }
    }
}
