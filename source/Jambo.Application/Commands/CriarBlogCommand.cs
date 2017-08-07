using MediatR;
using System.Runtime.Serialization;
using Jambo.Application.Commands;

namespace Jambo.Application.Commands
{
    [DataContract]
    public class CriarBlogCommand: IRequest
    {
        [DataMember]
        public string Url { get; private set; }

        public CriarBlogCommand()
        {

        }

        public CriarBlogCommand(string url) : this()
        {
            Url = url;
        }
    }
}
