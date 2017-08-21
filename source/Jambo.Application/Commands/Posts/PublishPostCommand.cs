using MediatR;
using System.Runtime.Serialization;
using Jambo.Application.Commands;

namespace Jambo.Application.Commands.Posts
{
    [DataContract]
    public class PublishPostCommand : IRequest
    {
        [DataMember]
        public string Url { get; private set; }

        public PublishPostCommand()
        {

        }

        public PublishPostCommand(string url) : this()
        {
            Url = url;
        }
    }
}
