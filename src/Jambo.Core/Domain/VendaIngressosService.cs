using Jambo.Core.Interfaces.Domain;
using Jambo.Core.Interfaces.Aggregates;
using Jambo.Core.Interfaces.Entities;
using Jambo.Core.Exceptions;
using Jambo.Core.Interfaces.Repository;
using System;

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

        public void EmitirIngressoParaCliente(IPedidoIngresso pedidoIngresso, Guid idCliente)
        {
            if (eventoReadOnlyRepository.PossuiIngressoNoLote(
                pedidoIngresso.IDLote))
            {
                pedidoIngresso.Emitir(idCliente);

                IPedido pedido = entityFactory.CriarEntity<IPedido>();

                pedido.ID = pedidoIngresso.Identificador;
                pedido.IDLote = pedidoIngresso.IDLote;
                pedido.IDCliente = pedidoIngresso.IDCliente;
                pedido.DataEmissao = pedidoIngresso.DataEmissao;

                pedidoReadOnlyRepository.Incluir(pedido);
            }
            else
            {
                throw new JamboException(12, "Ingressos Esgotados");
            }
        }
    }
}
