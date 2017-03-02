using System;

namespace Jambo.Core.Interfaces.Aggregates
{
    public interface IPedidoIngresso
    {
        Guid Identificador { get; }
        Guid IDEvento { get; }
        Guid IDLote { get; }
        Guid IDCliente { get; }
        DateTime DataEmissao { get; }

        void Reservar(Guid idEvento, Guid idLote);
        void Emitir(Guid idCliente);
    }
}
