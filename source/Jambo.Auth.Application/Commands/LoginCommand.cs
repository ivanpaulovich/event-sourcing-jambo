using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace Jambo.Auth.Application.Commands
{
    [DataContract]
    public class LoginCommand : IRequest
    {
        [Required]
        [DataMember]
        public string Username { get; private set; }

        [Required]
        [DataMember]
        public string Password { get; private set; }

        public LoginCommand()
        {

        }
    }
}
