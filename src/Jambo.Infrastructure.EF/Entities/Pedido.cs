using Jambo.Core.Interfaces.Entities;
using System;

namespace Jambo.Infrastructure.EF.Entities
{
    public class Pedido : IPedido
    {
        public Guid ID { get; set; }
        public Guid IDLote { get; set; }
        public Guid IDCliente { get; set; }
        public DateTime DataEmissao { get; set; }

        public virtual Lote LoteNavigation { get; set; }
    }
}
