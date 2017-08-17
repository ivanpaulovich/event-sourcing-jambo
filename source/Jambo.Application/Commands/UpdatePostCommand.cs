using MediatR;
using System.Runtime.Serialization;
using Jambo.Application.Commands;

namespace Jambo.Application.Commands
{
    [DataContract]
    public class UpdatePostCommand : IRequest
    {
        [DataMember]
        public string Url { get; private set; }

        public UpdatePostCommand()
        {

        }

        public UpdatePostCommand(string url) : this()
        {
            Url = url;
        }
    }
}
