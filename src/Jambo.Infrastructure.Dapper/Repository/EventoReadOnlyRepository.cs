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
        private readonly string connectionString;

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(connectionString);
            }
        }

        public bool PossuiIngressoNoLote(Guid idEvento, Guid idLote)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = "SELECT Quantidade FROM Lotes "
                           + "WHERE IdLote=@IdLote AND IdEvento=@IdEvento";

                dbConnection.Open();

                return dbConnection.Query<bool>(
                    sQuery, 
                    new { IdLote = idLote, IdEvento = idEvento })
                    .FirstOrDefault();
            }
        }
    }
}
