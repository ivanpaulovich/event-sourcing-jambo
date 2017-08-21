using MediatR;
using System.Runtime.Serialization;
using Jambo.Application.Commands;
using System;

namespace Jambo.Application.Commands.Blogs
{
    [DataContract]
    public class CreateBlogCommand: IRequest<Guid>
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
