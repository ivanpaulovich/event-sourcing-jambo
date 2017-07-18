using MediatR;
using System.Runtime.Serialization;

namespace Jambo.Application.Commands
{
    [DataContract]
    public class ExcluirBlogCommand : IRequest<bool>
    {
        [DataMember]
        public int Id { get; private set; }

        public ExcluirBlogCommand()
        {

        }
    }
}
