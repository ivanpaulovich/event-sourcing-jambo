using MediatR;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Jambo.Producer.Application.Commands.Blogs
{
    [DataContract]
    public class UpdateBlogUrlCommand : CommandBase, IRequest
    {
        [DataMember]
        public Guid Id { get; private set; }

        [DataMember]
        public string Url { get; private set; }

        public UpdateBlogUrlCommand()
        {

        }

        public UpdateBlogUrlCommand(Guid id, string url) : this()
        {
            Id = id;
            Url = url;
        }
    }
}