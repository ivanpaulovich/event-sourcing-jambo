using Jambo.Core.Entities;
using Jambo.Core.ValueTypes;
using System;

namespace Jambo.Core.Interfaces.Aggregates
{
    public interface IPedidoIngresso
    {
        IPedido Pedido { get; }
        ILote Lote { get; }
        ICliente Cliente { get; }
        DateTime DataEmissao { get; }

        void Reservar(ILote lote);
        void Emitir(ICliente cliente);
    }
}
