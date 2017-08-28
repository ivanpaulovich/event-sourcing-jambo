using MediatR;
using System.Runtime.Serialization;
using Jambo.Application.Commands;
using System;
using System.ComponentModel.DataAnnotations;

namespace Jambo.Application.Commands.Blogs
{
    [DataContract]
    public class CreateBlogCommand: IRequest<Guid>
    {
        [StringLength(100, MinimumLength = 10)]
        [Required]
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
