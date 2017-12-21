using MediatR;
using System.Runtime.Serialization;
using Jambo.Producer.Application.Commands;
using System;

namespace Jambo.Producer.Application.Commands.Posts
{
    [DataContract]
    public class UpdatePostContentCommand : CommandBase, IRequest
    {
        [DataMember]
        public Guid Id { get; private set; }

        [DataMember]
        public string Title { get; private set; }

        [DataMember]
        public string Content { get; private set; }

        public UpdatePostContentCommand()
        {

        }

        public UpdatePostContentCommand(Guid id, string title, string content) : this()
        {
            Id = id;
            Title = title;
            Content = content;
        }
    }
}
