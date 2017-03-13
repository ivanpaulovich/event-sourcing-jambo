using System;
using Jambo.Core.Interfaces.Aggregates;

namespace Jambo.Core.Domain
{
    public interface IVendaIngressosService
    {
        void EmitirIngressoParaCliente(IPedidoIngresso pedidoIngresso);
    }
}
