using MediatR;
using System.Runtime.Serialization;
using Jambo.Application.Commands;

namespace Jambo.Application.Commands
{
    [DataContract]
    public class CreateBlogCommand: IRequest
    {
        [DataMember]
        public string Url { get; private set; }

        public CreateBlogCommand()
        {

        }

        public CreateBlogCommand(string url) : this()
        {
            Url = url;
        }
    }
}
