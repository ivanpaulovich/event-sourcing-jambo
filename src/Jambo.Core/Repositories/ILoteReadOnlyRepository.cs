using Jambo.Core.Entities;
using System;
using System.Collections.Generic;

namespace Jambo.Core.Repositories
{
    public interface ILoteReadOnlyRepository
    {
        ILote Consultar(Guid idLote);
        IEnumerable<ILote> Listar();
    }
}
