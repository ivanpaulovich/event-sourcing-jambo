using Jambo.Core.Interfaces.Entities;
using System;
using System.Collections.Generic;

namespace Jambo.Infrastructure.EF.Entities
{
    public class Lote : ILote
    {
        public virtual Guid ID { get; set; }
        public virtual Guid IDEvento { get; set; }
        public virtual DateTime DataLimite { get; set; }
        public virtual int Quantidade { get; set; }

        public virtual Evento EventoNavigation { get; set; }
        public virtual ICollection<Pedido> PedidosNavigation { get; set; }
    }
}
