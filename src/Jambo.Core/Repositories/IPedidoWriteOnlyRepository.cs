using Jambo.Core.Entities;

namespace Jambo.Core.Repositories
{
    public interface IPedidoWriteOnlyRepository
    {
        void Incluir(IPedido pedido);
    }
}
