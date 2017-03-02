using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jambo.Core.Interfaces.Repository
{
    public interface IEventoReadOnlyRepository
    {
        bool PossuiIngressoNoLote(Guid iDEvento, Guid iDLote);
    }
}
