using System;
using Jambo.Core.Interfaces.Entities;
using Jambo.Core.Interfaces.Repository;
using Jambo.Infrastructure.EF.Entities;

namespace Jambo.Infrastructure.EF.Repository
{
    public class PedidoWriteOnlyRepository : RepositoryBase, IPedidoWriteOnlyRepository
    {
        public PedidoWriteOnlyRepository(VendasContext vendasContext)
            :base(vendasContext)
        {

        }

        public void Incluir(IPedido pedido)
        {
            vendasContext.Pedidos.Add((Pedido)pedido);
        }
    }
}
