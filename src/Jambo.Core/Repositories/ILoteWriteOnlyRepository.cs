using Jambo.Core.Entities;

namespace Jambo.Core.Repositories
{
    public interface ILoteWriteOnlyRepository
    {
        void Criar(ILote lote);
        void Atualizar(ILote lote);
    }
}
