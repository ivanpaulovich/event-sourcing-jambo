using MediatR;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Jambo.Application.Commands
{
    [DataContract]
    public class AtualizarBlogCommand
        : IRequest<bool>
    {
        [DataMember]
        public int Id { get; private set; }

        [DataMember]
        public string Url { get; private set; }

        [DataMember]
        public int Rating { get; private set; }

        public AtualizarBlogCommand()
        {

        }

        public AtualizarBlogCommand(int id, string url, int rating) : this()
        {
            Id = id;
            Url = url;
            Rating = rating;
        }
    }
}