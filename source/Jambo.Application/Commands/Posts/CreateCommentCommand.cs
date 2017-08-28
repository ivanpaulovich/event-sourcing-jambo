using MediatR;
using System.Runtime.Serialization;
using System;
using System.ComponentModel.DataAnnotations;

namespace Jambo.Application.Commands.Posts
{
    [DataContract]
    public class CreateCommentCommand : IRequest<Guid>
    {
        [Required]
        [DataMember]
        public Guid PostId { get; private set; }

        [StringLength(100, MinimumLength = 10)]
        [Required]
        [DataMember]
        public string Comment { get; private set; }

        public CreateCommentCommand()
        {

        }

        public CreateCommentCommand(Guid postId, string comment) : this()
        {
            PostId = postId;
            Comment = comment;
        }
    }
}
