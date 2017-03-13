using Jambo.Core.Entities;
using System;
using System.Collections.Generic;

namespace Jambo.Core.Repositories
{
    public interface IEventoReadOnlyRepository
    {
        IEvento Consultar(Guid idEvento);
        IEnumerable<IEvento> Paginar(int quantidade, int pagina);
        bool PossuiIngressoNoLote(Guid idLote);
    }
}
