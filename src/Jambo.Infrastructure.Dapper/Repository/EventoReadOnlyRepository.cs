using System;
using Jambo.Core.Interfaces.Repository;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Linq;

namespace Jambo.Infrastructure.Dapper.Repository
{
    public class EventoReadOnlyRepository : IEventoReadOnlyRepository
    {
        protected readonly IRepositorySettings repositorySettings;

        public EventoReadOnlyRepository(IRepositorySettings repositorySettings)
        {
            this.repositorySettings = repositorySettings;
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(repositorySettings.ConnectionString);
            }
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
