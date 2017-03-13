using Jambo.Core.Entities;
using Jambo.Core.Repositories;

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
