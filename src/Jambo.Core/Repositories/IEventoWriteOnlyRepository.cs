using Jambo.Core.Entities;

namespace Jambo.Core.Repositories
{
    public interface IEventoWriteOnlyRepository
    {
        void Criar(IEvento evento);
        void Atualizar(IEvento evento);
    }
}
