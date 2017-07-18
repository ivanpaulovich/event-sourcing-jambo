using MediatR;
using System.Runtime.Serialization;

namespace Jambo.Application.Commands
{
    [DataContract]
    public class AtualizarBlogCommand : IRequest<bool>
    {
        [DataMember]
        public string Url { get; private set; }

        [DataMember]
        public int Rating { get; private set; }

        public AtualizarBlogCommand()
        {

        }

        public AtualizarBlogCommand(string url, int rating) : this()
        {
            Url = url;
            Rating = rating;
        }
    }
}
