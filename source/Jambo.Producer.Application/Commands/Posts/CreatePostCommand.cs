using MediatR;
using System.Runtime.Serialization;
using System;
using System.ComponentModel.DataAnnotations;

namespace Jambo.Producer.Application.Commands.Posts
{
    [DataContract]
    public class CreatePostCommand : CommandBase, IRequest<Guid>
    {
        [DataMember]
        public Guid BlogId { get; private set; }

        [DataMember]
        public string Title { get; private set; }

        [DataMember]
        public string Content { get; private set; }

        public CreatePostCommand()
        {

        }

        public CreatePostCommand(Guid blogId, string title, string content) : this()
        {
            BlogId = blogId;
            Title = title;
            Content = content;
        }
    }
}
