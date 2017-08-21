using MediatR;
using System.Runtime.Serialization;
using Jambo.Application.Commands;

namespace Jambo.Application.Commands.Posts
{
    [DataContract]
    public class HidePostCommand : IRequest
    {
        [DataMember]
        public string Url { get; private set; }

        public HidePostCommand()
        {

        }

        public HidePostCommand(string url) : this()
        {
            Url = url;
        }
    }
}
