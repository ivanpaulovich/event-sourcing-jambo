using System;
using System.ComponentModel.DataAnnotations;

namespace Jambo.WebAPI.DTOs
{
    public class Pedido
    {
        [Required]
        public Guid IDEvento { get; set; }

        [Required]
        public Guid IDLote { get; set; }

        [Required]
        public Guid IDCliente { get; set; }
    }
}
