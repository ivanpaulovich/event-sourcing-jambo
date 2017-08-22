using MediatR;
using System;
using System.Runtime.Serialization;

namespace Jambo.Application.Commands.Blogs
{
    [DataContract]
    public class UpdateBlogUrlCommand : IRequest
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