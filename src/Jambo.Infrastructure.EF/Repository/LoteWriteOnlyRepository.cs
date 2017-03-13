using Jambo.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jambo.Core.Interfaces.Entities;
using Jambo.Infrastructure.EF.Entities;

namespace Jambo.Infrastructure.EF.Repositories
{
    public class LoteWriteOnlyRepository : RepositoryBase, ILoteWriteOnlyRepository
    {
        public LoteWriteOnlyRepository(VendasContext vendasContext)
            :base(vendasContext)
        {

        }

        public void Atualizar(ILote Lote)
        {
            vendasContext.Lotes.Attach((Lote)Lote);

            vendasContext.Entry(Lote).Property(x => x.Quantidade).IsModified = true;
            vendasContext.Entry(Lote).Property(x => x.DataLimite).IsModified = true;
        }

        public void Criar(ILote Lote)
        {
            vendasContext.Lotes.Add((Lote)Lote);
        }
    }
}
