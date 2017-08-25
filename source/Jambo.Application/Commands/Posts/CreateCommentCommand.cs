using MediatR;
using System.Runtime.Serialization;
using System;

namespace Jambo.Application.Commands.Posts
{
    [DataContract]
    public class CreateCommentCommand : IRequest<Guid>
    {
        [DataMember]
        public Guid PostId { get; private set; }

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
