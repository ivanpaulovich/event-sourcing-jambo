namespace Jambo.Auth.Application.Commands
{
    using System.ComponentModel.DataAnnotations;
    using System.Runtime.Serialization;

    [DataContract]
    public class LoginCommand
    {
        [Required]
        [DataMember]
        public string Username { get; set; }

        [Required]
        [DataMember]
        public string Password { get; set; }
    }
}
