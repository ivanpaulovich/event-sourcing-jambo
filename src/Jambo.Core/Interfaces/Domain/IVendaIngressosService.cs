using System;
using Jambo.Core.Interfaces.Aggregates;

namespace Jambo.Core.Interfaces.Domain
{
    public interface IVendaIngressosService
    {
        void EmitirIngressoParaCliente(IPedidoIngresso pedidoIngresso, Guid idCliente);
    }
}
