using Dapper;
using Jambo.Core.Interfaces.Entities;
using Jambo.Core.Interfaces.Repositories;
using Jambo.Infrastructure.Dapper.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Jambo.Infrastructure.Dapper.Repositories
{
    public class EventoReadOnlyRepository : RepositoryBase, IEventoReadOnlyRepository
    {
        public EventoReadOnlyRepository(
            IRepositorySettings repositorySettings)
            : base(repositorySettings)
        {
        }

        public IEvento Consultar(Guid idEvento)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery =
                    @"SELECT * FROM Eventos
                    WHERE Id=@IdEvento";

                dbConnection.Open();

                return dbConnection.Query<Evento>(
                    sQuery,
                    new { IdEvento = idEvento }).FirstOrDefault();
            }
        }

        public IEnumerable<IEvento> Paginar(int quantidade, int pagina)
        {
            throw new NotImplementedException();
        }

        public bool PossuiIngressoNoLote(Guid idLote)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery =
                    @"SELECT (Quantidade - 
	                    (SELECT Count(*) FROM Pedidos 
		                    WHERE IdLote=Pedidos.IDLote)) As QuantidadeDisponivel
	                    FROM Lotes
                    WHERE Id=@IdLote";

                dbConnection.Open();

                return dbConnection.Query<int>(
                    sQuery, 
                    new { IdLote = idLote })
                    .FirstOrDefault() > 0;
            }
        }
    }
}
