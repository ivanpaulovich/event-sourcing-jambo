using Jambo.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jambo.Core.Interfaces.Entities;
using Jambo.Infrastructure.EF.Entities;

namespace Jambo.Infrastructure.EF.Repositories
{
    public class EventoWriteOnlyRepository : RepositoryBase, IEventoWriteOnlyRepository
    {
        public EventoWriteOnlyRepository(VendasContext vendasContext)
            :base(vendasContext)
        {

        }

        public void Atualizar(IEvento evento)
        {
            vendasContext.Eventos.Attach((Evento)evento);

            vendasContext.Entry(evento).Property(x => x.Titulo).IsModified = true;
            vendasContext.Entry(evento).Property(x => x.Descricao).IsModified = true;
            vendasContext.Entry(evento).Property(x => x.DataRealizacao).IsModified = true;
        }

        public void Criar(IEvento evento)
        {
            vendasContext.Eventos.Add((Evento)evento);
        }
    }
}
