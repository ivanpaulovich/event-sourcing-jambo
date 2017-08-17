using MediatR;
using System.Runtime.Serialization;
using Jambo.Application.Commands;

namespace Jambo.Application.Commands
{
    [DataContract]
    public class CreatePostCommand : IRequest
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
