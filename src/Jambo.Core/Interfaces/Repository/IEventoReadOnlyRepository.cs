using Jambo.Core.Interfaces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jambo.Core.Interfaces.Repository
{
    public interface IEventoReadOnlyRepository
    {
        IEvento Consultar(Guid idEvento);
        IEnumerable<IEvento> Paginar(int quantidade, int pagina);
        bool PossuiIngressoNoLote(Guid idLote);
    }
}
