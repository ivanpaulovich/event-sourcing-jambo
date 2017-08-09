using MediatR;
using System;
using System.Runtime.Serialization;

namespace Jambo.Application.Commands
{
    [DataContract]
    public class AtualizarBlogCommand : IRequest
    {
        [DataMember]
        public Guid Id { get; private set; }

        [DataMember]
        public string Url { get; private set; }

        [DataMember]
        public int Rating { get; private set; }

        public AtualizarBlogCommand()
        {

        }

        public AtualizarBlogCommand(Guid id, string url, int rating) : this()
        {
            Id = id;
            Url = url;
            Rating = rating;
        }
    }
}