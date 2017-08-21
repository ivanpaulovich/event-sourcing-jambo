using MediatR;
using System.Runtime.Serialization;
using Jambo.Application.Commands;

namespace Jambo.Application.Commands.Posts
{
    [DataContract]
    public class DisablePostCommand : IRequest
    {
        [DataMember]
        public string Url { get; private set; }

        public DisablePostCommand()
        {

        }

        public DisablePostCommand(string url) : this()
        {
            Url = url;
        }
    }
}
