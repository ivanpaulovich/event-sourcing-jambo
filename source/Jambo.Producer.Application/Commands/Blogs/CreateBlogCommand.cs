using MediatR;
using System.Runtime.Serialization;
using Jambo.Producer.Application.Commands;
using System;
using System.ComponentModel.DataAnnotations;

namespace Jambo.Producer.Application.Commands.Blogs
{
    [DataContract]
    public class CreateBlogCommand : CommandBase, IRequest<Guid>
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
