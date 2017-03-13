using Jambo.Core.Interfaces.Aggregates;
using Jambo.Core.Exceptions;
using System;
using Jambo.Core.Entities;
using Jambo.Core.Repositories;

namespace Jambo.Core.Domain
{
    public class VendaIngressosService : DomainBase, IVendaIngressosService
    {
        public VendaIngressosService(
            IEntityFactory entityFactory,
            IEventoReadOnlyRepository eventoReadOnlyRepository,
            ILoteReadOnlyRepository loteReadOnlyRepository,
            IPedidoWriteOnlyRepository pedidoReadOnlyRepository) : base(
                entityFactory,
                eventoReadOnlyRepository,
                loteReadOnlyRepository,
                pedidoReadOnlyRepository)
        {
                
        }

        public void EmitirIngressoParaCliente(IPedidoIngresso pedidoIngresso)
        {
            if (!eventoReadOnlyRepository.PossuiIngressoNoLote(pedidoIngresso.Lote.ID))
                throw new DomainException(12, "Ingressos Esgotados");

            pedidoIngresso.Emitir(pedidoIngresso.Cliente);

            pedidoReadOnlyRepository.Incluir(pedidoIngresso.Pedido);
        }
    }
}
