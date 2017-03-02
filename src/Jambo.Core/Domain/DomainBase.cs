using Jambo.Core.Interfaces.Entities;
using Jambo.Core.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jambo.Core.Domain
{
    public class DomainBase
    {
        protected readonly IEntityFactory entityFactory;

        protected readonly IEventoReadOnlyRepository eventoReadOnlyRepository;
        protected readonly ILoteReadOnlyRepository loteReadOnlyRepository;
        protected readonly IPedidoWriteOnlyRepository pedidoReadOnlyRepository;

        public DomainBase(
            IEntityFactory entityFactory,
            IEventoReadOnlyRepository eventoReadOnlyRepository,
            ILoteReadOnlyRepository loteReadOnlyRepository,
            IPedidoWriteOnlyRepository pedidoReadOnlyRepository)
        {
            this.entityFactory = entityFactory;

            this.eventoReadOnlyRepository = eventoReadOnlyRepository;
            this.loteReadOnlyRepository = loteReadOnlyRepository;
            this.pedidoReadOnlyRepository = pedidoReadOnlyRepository;
        }
    }
}
