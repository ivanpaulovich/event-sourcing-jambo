using Jambo.Core.Interfaces.Aggregates;
using System;
using Jambo.Core.Entities;
using Jambo.Core.ValueTypes;

namespace Jambo.Core.Aggregates
{
    public class PedidoIngresso : IPedidoIngresso
    {
        public IPedido Pedido { get; private set; }
        public ILote Lote { get; private set; }
        public ICliente Cliente { get; private set; }
        public DateTime DataEmissao { get; private set; }

        public void Reservar(ILote lote)
        {
            Lote = lote;
        }

        public void Emitir(ICliente cliente)
        {
            Pedido.ID = Guid.NewGuid();
            Cliente.ID = cliente.ID;
            DataEmissao = DateTime.Now;
        }
    }
}
