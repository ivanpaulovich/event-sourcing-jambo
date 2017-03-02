using Jambo.Core.Interfaces.Aggregates;
using System;

namespace Jambo.Core.Aggregates
{
    public class PedidoIngresso : IPedidoIngresso
    {
        public Guid Identificador { get; private set; }
        public Guid IDEvento { get; private set; }
        public Guid IDCliente { get; private set; }
        public Guid IDLote { get; private set; }
        public DateTime DataEmissao { get; private set; }

        public void Reservar(Guid idEvento, Guid idLote)
        {
            IDEvento = idEvento;
            IDLote = idLote;
        }

        public void Emitir(Guid idCliente)
        {
            Identificador = Guid.NewGuid();
            IDCliente = idCliente;
            DataEmissao = DateTime.Now;
        }
    }
}
