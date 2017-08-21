using MediatR;
using System.Runtime.Serialization;
using Jambo.Application.Commands;

namespace Jambo.Application.Commands.Posts
{
    [DataContract]
    public class UpdateContentCommand : IRequest
    {
        [DataMember]
        public string Url { get; private set; }

        public UpdateContentCommand()
        {

        }

        public UpdateContentCommand(string url) : this()
        {
            Url = url;
        }
    }
}
