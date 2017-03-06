using System;
using Jambo.Core.Interfaces.Entities;
using System.Collections.Generic;

namespace Jambo.Infrastructure.Dapper.Entities
{
    public class Pedido : IPedido
    {
        public Guid ID { get; set; }
        public Guid IDLote { get; set; }
        public Guid IDCliente { get; set; }
        public DateTime DataEmissao { get; set; }
    }
}
