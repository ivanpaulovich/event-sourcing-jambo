using Jambo.Core.Domain;
using Jambo.Core.Interfaces.Aggregates;
using Jambo.Core.Interfaces.Applications;
using Jambo.Core.Interfaces.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Jambo.Application
{
    public class VendaIngressosApplication : ApplicationBase, IVendaIngressosApplication
    {
        public VendaIngressosApplication(
            IUnitOfWork unitOfWork,
            IAggregateFactory aggregateFactory,
            IVendaIngressosService vendaIngressosService)
            : base(unitOfWork, aggregateFactory, vendaIngressosService)
        {

        }

        public void RealizarPedido(Guid idPedido, Guid idLote, Guid idCliente)
        {
            IPedidoIngresso pedido = aggregateFactory.Criar<IPedidoIngresso>();
            vendaIngressosService.EmitirIngressoParaCliente()
        }
    }
}
