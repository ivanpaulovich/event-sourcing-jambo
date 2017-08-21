using MediatR;
using System.Runtime.Serialization;
using Jambo.Application.Commands;
using System;

namespace Jambo.Application.Commands.Posts
{
    [DataContract]
    public class CreatePostCommand : IRequest<Guid>
    {
        [DataMember]
        public string Url { get; private set; }

        public CreatePostCommand()
        {

        }

        public CreatePostCommand(string url) : this()
        {
            Url = url;
        }
    }
}
